﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PLSucht.admin
{
    public partial class adminuser : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ImageButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("KlientenAuswahl.aspx");
        }
    }
}