using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Novin.Class;
using rijndael;

namespace Novin.admn
{
    public partial class admaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void exit_OnServerClick(object sender, EventArgs e)
        {
            Authentication.ClearAuthentication();
            Response.Redirect("../adminn.aspx");
        }
    }
}