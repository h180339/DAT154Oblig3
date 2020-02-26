using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DatabaseHandler;
using DatabaseHandler.Model;

namespace Oblig_3_Desktop_app
{
    /// <summary>
    /// Interaction logic for RegisterRS.xaml
    /// </summary>
    public partial class RegisterRS : Page
    {
        private BookingDbContext dbContext;

        public RegisterRS()
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            dbContext = new BookingDbContext();

            List<HotelRoom> resList = dbContext.HotelRooms.ToList();
            hotelRooms.ItemsSource = resList;

            statusColumn.ItemsSource = DatabaseHandler.Constants.roomStatuses;
            qualityColumn.ItemsSource = DatabaseHandler.Constants.roomQualities;
        }

         private void Home_Click(object sender, RoutedEventArgs e)
         {
            NavigationService.Navigate(new FrontPage());
         }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            dbContext.SaveChanges();
        }

        private void Add_Room_Service_Click(object sender, RoutedEventArgs e)
        {
            if (hotelRooms.SelectedItem != null)
            {
                if (!String.IsNullOrWhiteSpace(RoomServiceItem.Text))
                {
                    RoomService service = new RoomService
                    {
                        Room = hotelRooms.SelectedItem as HotelRoom,
                        Item = RoomServiceItem.Text
                    };

                    dbContext.AddRoomService(service);
                    roomServices.ItemsSource = dbContext.GetRoomServicesForHotelRoom(service.Room);
                }
                else
                {
                    MessageBox.Show("Please enter desired service.");
                }
            } 
            else
            {
                MessageBox.Show("Please select a room to add room service for.");
            }
        }

        private void Delete_Room_Service_Click(object sender, RoutedEventArgs e)
        {
            if (roomServices.SelectedItem != null)
            {
                HotelRoom room = (roomServices.SelectedItem as RoomService)?.Room;

                dbContext.DeleteRoomService(roomServices.SelectedItem as RoomService);
                roomServices.ItemsSource = dbContext.GetRoomServicesForHotelRoom(room);
            }
        }

        private void hotelRooms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (hotelRooms.SelectedItem != null)
            {
                roomServices.ItemsSource = dbContext.GetRoomServicesForHotelRoom((hotelRooms.SelectedItem as HotelRoom));
            }
            else
            {
                roomServices.ItemsSource = null;
            }
        }
    }
}
