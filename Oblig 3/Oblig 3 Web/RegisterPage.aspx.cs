using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oblig_3_Web.Model;
using System.Data.Entity;

namespace Oblig_3_Web
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        private BookingDbContext userDbContext;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void register_button_Click(object sender, EventArgs e)
        {
            User created_user = new User()
            {
                username = username_textbox_register.Text,
                password = password_textbox_register.Text
            };
            userDbContext = new BookingDbContext();
            DbSet<User> userList = userDbContext.Users;
            if(userList.Where(u => u.username.Equals(created_user.username)).Count() == 0 && check_user(created_user)) 
                //check if username is already registered or empty string
            {
                userList.Add(created_user);
                userDbContext.SaveChanges();
                Session["User"] = created_user;
                Response.Redirect("BookingPage.aspx");
            } else
            {
                //TODO: sende error message (maybe by using sessions ?)
                Response.Redirect("RegisterPage.aspx");
            }
        }

        private bool check_user(User user)
        {
            if(user.username.Length != 0 && user.password.Length != 0)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}