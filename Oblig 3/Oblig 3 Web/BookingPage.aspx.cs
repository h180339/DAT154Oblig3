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
            /*
            List<User> userList = dbContext.Users.ToList();
            List<HotelRoom> hrList = dbContext.HotelRooms.ToList();
            DbSet<Reservation> resSet = dbContext.Reservations;


            //Create a object of hotelroom chosen
            HotelRoom hotelRoom = hrList.Find(x => x.Id == Convert.ToInt32(cells[0].Text));
            */
            TableCellCollection cells = e.Item.Cells;

            int hotelRoomId = Convert.ToInt32(cells[0].Text);

            //Find user
            User sessionUser = Session["User"] as User;
            int sessionUserId = sessionUser.Id;
            //User user = userList.Find(x => x.Id == sessionUser.Id);

            dbContext.AddReservation(hotelRoomId, sessionUserId, (start_date_calendar.SelectedDate, end_date_calendar.SelectedDate));

            /*
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
            */
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
            //DbSet<HotelRoom> roomSet = dbContext.HotelRooms;
            //List<HotelRoom> roomList = roomSet.ToList();
            List<HotelRoom> roomList = dbContext.getRoomsInTimeperiod((startDate, endDate));

            //Remove entries with too few beds
            roomList.RemoveAll(x => x.numberOfBeds < int.Parse(numberOfBedsDropdown.SelectedValue));
            //Remove entries with non-matching quality
            roomList.RemoveAll(x => !x.quality.Equals(qualityDropdown.SelectedValue));
           
            myDataGrid.DataSource = roomList;
            myDataGrid.DataBind();
        }
    }
}