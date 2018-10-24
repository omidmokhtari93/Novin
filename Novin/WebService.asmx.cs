using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
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
                return new JavaScriptSerializer().Serialize(new { flag = 1, message = "admin.aspx" });
            }
            if (CheckLicense())
            {
                return new JavaScriptSerializer().Serialize(new { flag = 0, message = "! لطفا با پشتیبان نرم افزار تماس بگیرید" });
            }
            _cnn.Open();
            var selectUser = new SqlCommand("select id , password , permit , usrlevel  from users where username = '" + username.Trim() + "' ", _cnn);
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
            return new JavaScriptSerializer().Serialize(new { flag = 1, message = "welcome.aspx" });
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
            var selectuserinfo = new SqlCommand("select username , password , name from users where " +
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
    }
}
