using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Novin.Class;

namespace Novin.admn
{
    public partial class excel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Authentication.IsAuthenticated())
            {
                Response.Redirect("../adminn.aspx");
            }
        }
    }
}