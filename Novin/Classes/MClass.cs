using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Novin
{
    public class Authentication
    {
        public static bool IsAuthenticated()
        {
            var httpcontext = HttpContext.Current.Response;
            httpcontext.Cache.SetCacheability(HttpCacheability.NoCache);
            httpcontext.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            httpcontext.Cache.SetNoStore();
            try
            {
                var identity = (FormsIdentity)HttpContext.Current.User.Identity;
                var userData = identity.Ticket.UserData.Split(",".ToCharArray());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void ClearAuthentication()
        {
            var context = HttpContext.Current;
            var limit = context.Request.Cookies.Count;
            for (var i = 0; i < limit; i++)
            {
                var cookieName = context.Request.Cookies[i].Name;
                var aCookie = new HttpCookie(cookieName) { Expires = DateTime.Now.AddDays(-1) };
                context.Response.Cookies.Add(aCookie);
            }
        }
    }
    public class BimeInfo
    {
        public string IdCode { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string Person { get; set; }
        public string Total { get; set; }
        public string Date { get; set; }
    }

    public class CustomerInformation
    {

    }
}