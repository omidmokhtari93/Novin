﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Novin.Class;

namespace Novin
{
    public partial class adminn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Authentication.ClearAuthentication();
        }
    }
}