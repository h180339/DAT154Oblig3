
using DatabaseHandler.Model;
using DatabaseHandler;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Oblig_3_Web
{
    public partial class _Default : Page
    {
        private BookingDbContext userDbContext;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //register_button click method
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterPage.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            userDbContext = new BookingDbContext();

            List<User> userList = userDbContext.Users.ToList();
            foreach(User u in userList)
            {
                if(username_textbox.Text.Equals(u.username) && password_textbox.Text.Equals(u.password))
                {
                    Session["User"] = u;
                    Response.Redirect("UserPage.aspx");
                }
            }
        }
    }
}