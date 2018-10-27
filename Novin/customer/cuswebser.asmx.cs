using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Web.Services;
using rijndael;

namespace Novin.customer
{
    /// <summary>
    /// Summary description for cuswebser
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class cuswebser : System.Web.Services.WebService
    {
        private readonly SqlConnection _cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["novin"].ConnectionString);
        private const string InitVector = "F4568dgbdfgtt444";
        private const string Key = "rdf48JH4";

        [WebMethod]
        public string CusAuthenticate(string username, string password)
        {
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
    }
}
