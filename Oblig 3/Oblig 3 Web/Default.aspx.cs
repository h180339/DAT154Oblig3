using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Oblig_3_Web
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        //register_button click method
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterPage.aspx");
        }
    }
}