using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using rijndael;

namespace Novin.Class
{
    public class Authentication
    {
        public static bool IsAuthenticated()
        {
            ClearCache();
            try
            {
                var identity = (FormsIdentity)HttpContext.Current.User.Identity;
                var userData = identity.Ticket.UserData.Split(",".ToCharArray());
                return !IsAdminUser(userData);
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static bool IsAdminUser(string[] userData)
        {
            var cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["novin"].ConnectionString);
            const string initVector = "F4568dgbdfgtt444";
            const string key = "rdf48JH4";
            var re = new RijndaelEnhanced(key, initVector);
            cnn.Open();
            var select = new SqlCommand("select username , password from admin",cnn);
            var r = select.ExecuteReader();
            if (!r.Read()) return true;
            var username = r["username"].ToString();
            var password = r["password"].ToString();
            password = re.Decrypt(password);
            cnn.Close();
            return username != userData[0] || password != userData[1];
        }

        public static void ClearAuthentication()
        {
            ClearCache();
            var context = HttpContext.Current;
            var limit = context.Request.Cookies.Count;
            for (var i = 0; i < limit; i++)
            {
                var cookieName = context.Request.Cookies[i].Name;
                var aCookie = new HttpCookie(cookieName) { Expires = DateTime.Now.AddDays(-1) };
                context.Response.Cookies.Add(aCookie);
            }
        }

        public static void ClearCache()
        {
            var httpcontext = HttpContext.Current.Response;
            httpcontext.Cache.SetCacheability(HttpCacheability.NoCache);
            httpcontext.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            httpcontext.Cache.SetNoStore();
        }
    }
}