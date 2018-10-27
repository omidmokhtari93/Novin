using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Web.Services;
using rijndael;

namespace Novin
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {
        private readonly SqlConnection _cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["novin"].ConnectionString);
        private const string InitVector = "F4568dgbdfgtt444";
        private const string Key = "rdf48JH4";
        [WebMethod]
        public string Authentication(string username, string password)
        {
            if (AdminLogin(username, password))
            {
                return new JavaScriptSerializer().Serialize(new { flag = 1, message = "license.aspx" });
            }
            if (CheckLicense())
            {
                return new JavaScriptSerializer().Serialize(new { flag = 0, message = "! لطفا با پشتیبان نرم افزار تماس بگیرید" });
            }
            _cnn.Open();
            var selectUser = new SqlCommand("select id , password , permit , usrlevel  from admin where username = '" + username.Trim() + "' ", _cnn);
            var rd = selectUser.ExecuteReader();
            if (!rd.Read()) return new JavaScriptSerializer().Serialize(new { flag = 0, message = "! نام کاربری یا رمز عبور اشتباه است" });
            var permit = Convert.ToInt32(rd["permit"]);
            var userId = Convert.ToInt32(rd["id"]);
            var userLevel = Convert.ToInt32(rd["usrlevel"]);
            var userPassword = rd["password"].ToString();
            if (permit == 0)
            {
                return new JavaScriptSerializer().Serialize(new { flag = 0, message = "! حساب کاربری شما غیرفعال است" });
            }
            var re = new RijndaelEnhanced(Key, InitVector);
            var decPass = re.Decrypt(userPassword);
            if (decPass != password.Trim()) return new JavaScriptSerializer().Serialize(new { flag = 0, message = "! نام کاربری یا رمز عبور اشتباه است" });
            var ticket = new FormsAuthenticationTicket(1, username.Trim(), DateTime.Now,
                DateTime.Now.AddMinutes(60), false, userId + "," + userLevel);
            var cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName,
                FormsAuthentication.Encrypt(ticket));
            HttpContext.Current.Response.Cookies.Add(cookie1);
            return new JavaScriptSerializer().Serialize(new { flag = 1, message = "admn/excel.aspx" });
        }
        public bool CheckLicense()
        {
            try
            {
                var path = Server.MapPath("bin/License.bls");
                var date = File.ReadAllText(path);
                var rijn = new RijndaelEnhanced(Key, InitVector);
                var expdate = ShamsiCalendar.Shamsi2Miladi(rijn.Decrypt(date));
                var today = DateTime.Now;
                return expdate <= today;
            }
            catch
            {
                return true;
            }
        }

        public bool AdminLogin(string username, string password)
        {
            if (username.Trim() != "administrator" || password.Trim() != "Borna7257048") return false;
            var adminTicket = new FormsAuthenticationTicket(1, username.Trim(), DateTime.Now,
                DateTime.Now.AddMinutes(60), false, "administrator");
            var adminCookie = new HttpCookie(FormsAuthentication.FormsCookieName,
                FormsAuthentication.Encrypt(adminTicket));
            HttpContext.Current.Response.Cookies.Add(adminCookie);
            return true;
        }

        [WebMethod]
        public string SendUserAndPass(string email, string phone)
        {
            _cnn.Open();
            var selectuserinfo = new SqlCommand("select username , password , name from admin where " +
                                                       "tell ='" + phone + "' AND email='" + email.Trim() + "' ", _cnn);
            var rd = selectuserinfo.ExecuteReader();
            if (!rd.Read())
                return new JavaScriptSerializer().Serialize(
                    new {flag = 0, message = "!هیچ کاربری با مشخصات فوق یافت نشد"});
            var forgottenUsername = rd["username"].ToString();
            var re = new RijndaelEnhanced(Key, InitVector);
            var forgottenPassword = re.Decrypt(rd["password"].ToString());
            var nameAndFamily = rd["name"].ToString();
            try
            {
                var mail = new MailMessage();
                mail.To.Add(email);
                mail.From = new MailAddress("borna.assistanse@gmail.com", "اطلاعات حساب کاربری", System.Text.Encoding.UTF8);
                mail.Subject = "بازیابی نام کاربری و رمز عبور";
                mail.SubjectEncoding = Encoding.UTF8;
                var formBody = File.ReadAllText(HttpContext.Current.Server.MapPath("~/Content/forgetPasswordForm.html"));
                formBody = formBody.Replace("#nameAndFamily#", nameAndFamily);
                formBody = formBody.Replace("#username#", forgottenUsername);
                formBody = formBody.Replace("#password#", forgottenPassword);
                mail.Body = formBody;
                mail.BodyEncoding = Encoding.UTF8;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;
                var client = new SmtpClient
                {
                    Credentials = new System.Net.NetworkCredential("borna.assistanse@gmail.com", "Omid1993"),
                    Port = 587,
                    Host = "smtp.gmail.com",
                    EnableSsl = true
                };
                client.Send(mail);
                return new JavaScriptSerializer().Serialize(new { flag = 1, message = ".نام کاربری و رمز عبور به ایمیل شما ارسال گردید" });
            }
            catch
            {
                return new JavaScriptSerializer().Serialize(new { flag = 0, message = "!خطا در ارسال ایمیل" });
            }
        }

        [WebMethod]
        public void SaveBimeInfo(List<BimeInfo> data)
        {
            _cnn.Open();
            var re = new Regex(@"([^0-9]+)(\d+)");
            for (var i = 2; i < data.Count; i++)
            {
                var result = re.Match(data[i].Person);
                var name = result.Groups[1].Value;
                var removePlace = name.Length - 3;
                name = name.Remove(removePlace, 2);
                var total = data[i].Total.Replace(",", "");
                var code = Convert.ToInt32(result.Groups[2].Value);
                if (data[i].Status != "تأييد شده") continue;
                var ins = new SqlCommand("if (select count(id) from bimeinfo where idcode = " + Convert.ToInt32(data[i].IdCode) + ") > 0 Begin select null End " +
                                         "Else Begin INSERT INTO [dbo].[bimeinfo]([idcode],[type],[name],[code],[total],[date])VALUES" +
                                         "(" + Convert.ToInt32(data[i].IdCode) + ",N'" + data[i].Type + "',N'" + name.Trim() + "'," + code + "," +
                                         "" + Convert.ToInt32(total) + ",'" + data[i].Date + "')End", _cnn);
                ins.ExecuteNonQuery();
            }
        }
    }
}
