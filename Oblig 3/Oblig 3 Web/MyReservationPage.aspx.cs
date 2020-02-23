using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oblig_3_Web.Model;

namespace Oblig_3_Web
{
    public partial class MyReservationPage : System.Web.UI.Page
    {
        private BookingDbContext dbContext;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Default.aspx");
            }

            dbContext = new BookingDbContext();
            List<Reservation> reservations = dbContext.Reservations.ToList();

            User user = Session["User"] as User;

            List<Reservation> gridList = new List<Reservation>();
            foreach(Reservation r in reservations)
            {
                if(r.UserId == user.Id)
                {
                    gridList.Add(r);
                }
            }
            myDataGrid.DataSource = gridList;
            myDataGrid.DataBind();

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserPage.aspx");
        }
    }
}