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

        protected void Page_Load(object sender, EventArgs e)
        {
            roomDbContext = new BookingDbContext();
            DbSet<HotelRoom> roomList = roomDbContext.HotelRooms;
            List<HotelRoom> list = roomList.ToList();
            myDataGrid.DataSource = list;
            myDataGrid.DataBind();
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
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
    }
}