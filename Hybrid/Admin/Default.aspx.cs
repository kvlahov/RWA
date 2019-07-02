using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminSite
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (User.IsInRole("Admin"))
            //{
            //    output.Controls.Add(new LiteralControl("Admin"));
            //} else
            //{
            //    Response.Redirect("~/");
            //    output.Controls.Add(new LiteralControl("Not admin"));
            //}
        }
    }
}