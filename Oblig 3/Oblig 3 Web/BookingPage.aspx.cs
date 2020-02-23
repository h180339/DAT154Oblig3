using Oblig_3_Web.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Oblig_3_Web
{
    public partial class BookingPage : System.Web.UI.Page
    {
        private BookingDbContext roomDbContext;
        private BookingDbContext resDbContext;

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void myDataGrid_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            TableCellCollection cells = e.Item.Cells;
            HotelRoom hotelRoom = new HotelRoom()
            {
                Id = Convert.ToInt32(cells[0].Text),
                numberOfBeds = Convert.ToInt32(cells[1].Text),
                roomSize = Convert.ToInt32(cells[2].Text),
                quality = cells[3].Text
            };
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DateTime startDate = start_date_calendar.SelectedDate;
            DateTime endDate = end_date_calendar.SelectedDate;
            if (startDate != null && endDate != null)
            {
                //Get list of hotel rooms :
                roomDbContext = new BookingDbContext();
                DbSet<HotelRoom> roomSet = roomDbContext.HotelRooms;
                List<HotelRoom> roomList = roomSet.ToList();
                //Get list of reservations
                resDbContext = new BookingDbContext();
                DbSet<Reservation> resSet = resDbContext.Reservations;
                List<Reservation> resList = resSet.ToList();

                foreach(Reservation res in resList)
                {
                    if((startDate >= res.startDate && startDate <= res.endDate) || (endDate >= res.startDate && endDate <= res.endDate))
                    {
                        int id = res.HotelRoomId;
                        roomList.RemoveAll((x) => x.Id == id);
                    }
                }
                myDataGrid.DataSource = roomList;
                myDataGrid.DataBind();
            }
        }
    }
}