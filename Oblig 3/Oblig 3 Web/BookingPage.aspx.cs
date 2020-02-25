using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DatabaseHandler;
using DatabaseHandler.Model;

namespace Oblig_3_Web
{
    public partial class BookingPage : Page
    {
        private BookingDbContext dbContext;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["User"] == null)
            {
                Response.Redirect("Default.aspx");
            }
        }


        protected void myDataGrid_ItemCommand(object source, DataGridCommandEventArgs e)
        {

            dbContext = new BookingDbContext();
            List<User> userList = dbContext.Users.ToList();
            List<HotelRoom> hrList = dbContext.HotelRooms.ToList();
            DbSet<Reservation> resSet = dbContext.Reservations;


            //Create a object of hotelroom chosen
            TableCellCollection cells = e.Item.Cells;
            HotelRoom hotelRoom = hrList.Find(x => x.Id == Convert.ToInt32(cells[0].Text));

            //Find user
            User sessionUser = Session["User"] as User;
            User user = userList.Find(x => x.Id == sessionUser.Id);

            //Creates the reservation
            Reservation reservation = new Reservation()
            {
                startDate = start_date_calendar.SelectedDate,
                endDate = end_date_calendar.SelectedDate,
                User = user,
                HotelRoom = hotelRoom,
                Status = "Created"
            };

            resSet.Add(reservation);
            dbContext.SaveChanges();

            updateDataGrid(start_date_calendar.SelectedDate, end_date_calendar.SelectedDate);

            //TODO: redirect somewhere when booked ?

        }

        protected void searchForRooms(object sender, EventArgs e)
        {
            DateTime startDate = start_date_calendar.SelectedDate;
            DateTime endDate = end_date_calendar.SelectedDate;
            if (startDate != null && endDate != null)
            {
                if (startDate.CompareTo(endDate) > 0)
                {
                    searchError.Text = "Start date must be before end date";
                } else
                {
                    searchError.Text = "";
                    updateDataGrid(startDate, endDate);
                }
                
            }
        }

        private void updateDataGrid(DateTime startDate, DateTime endDate)
        {
            //Get list of hotel rooms :
            dbContext = new BookingDbContext();
            DbSet<HotelRoom> roomSet = dbContext.HotelRooms;
            List<HotelRoom> roomList = roomSet.ToList();
            //Get list of reservations
            dbContext = new DatabaseHandler.BookingDbContext();
            DbSet<Reservation> resSet = dbContext.Reservations;
            List<Reservation> resList = resSet.ToList();

            //Removes rooms that are already reserved in the time period chosen
            foreach (Reservation res in resList)
            {
                if ((startDate >= res.startDate && startDate <= res.endDate) || (endDate >= res.startDate && endDate <= res.endDate))
                {
                    int id = res.HotelRoomId;
                    roomList.RemoveAll((x) => x.Id == id);
                }
            }
            //Remove entries with too few beds
            roomList.RemoveAll(x => x.numberOfBeds < int.Parse(numberOfBedsDropdown.SelectedValue));
            //Remove entries with non-matching quality
            roomList.RemoveAll(x => !x.quality.Equals(qualityDropdown.SelectedValue));
           
            myDataGrid.DataSource = roomList;
            myDataGrid.DataBind();
        }
    }
}