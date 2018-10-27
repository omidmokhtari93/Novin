using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using rijndael;

namespace Novin
{
    public partial class license : System.Web.UI.Page
    {
        private const string InitVector = "F4568dgbdfgtt444";
        private const string Key = "rdf48JH4";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var identity = (FormsIdentity)Context.User.Identity;
                var i = identity.Ticket.UserData;
                if (i.Trim() != "administrator")
                {
                    Response.Redirect("adminn.aspx");
                }
                var path = Server.MapPath("bin/License.bls");
                var date = File.ReadAllText(path);
                try
                {
                    var rijn = new RijndaelEnhanced(Key, InitVector);
                    lbl.Text = rijn.Decrypt(date);
                }
                catch
                {
                    // ignored
                }
            }
            catch (Exception)
            {
                Response.Redirect("adminn.aspx");
            }
        }

        protected void OnClick(object sender, EventArgs e)
        {
            var re = new RijndaelEnhanced(Key, InitVector);
            var date = re.Encrypt(txt.Value);
            var path = Server.MapPath("bin/License.bls");
            File.WriteAllLines(path, new[] { date });
            date = File.ReadAllText(path);
            lbl.Text = re.Decrypt(date);
        }

        protected void exit_OnClick(object sender, EventArgs e)
        {
            Authentication.ClearAuthentication();
            Response.Redirect("adminn.aspx");
        }
    }
}