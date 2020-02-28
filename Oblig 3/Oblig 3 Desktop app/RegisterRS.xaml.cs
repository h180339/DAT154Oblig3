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
using DatabaseHandlerStandard;
using DatabaseHandlerStandard.Model;

namespace Oblig_3_Desktop_app
{
    /// <summary>
    /// Interaction logic for RegisterRS.xaml
    /// </summary>
    public partial class RegisterRS : Page
    {
        private BookingDbContext dbContext;
        private List<RoomService> RoomServices;
        private List<HotelRoom> hotelRoomList;

        public RegisterRS()
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            dbContext = new BookingDbContext();

            hotelRoomList = dbContext.HotelRooms.ToList();
            List<int> hotelRoomNumbersList = new List<int>();
            foreach(HotelRoom h in hotelRoomList)
            {
                hotelRoomNumbersList.Add(h.Id);
            }
            RoomServices = dbContext.RoomServices.ToList();
            serviceList.ItemsSource = RoomServices;
            statusColumn.ItemsSource = DatabaseHandlerStandard.Constants.roomServiceStatuses;
            roomNumberCombo.ItemsSource = hotelRoomNumbersList;

        }

         private void Home_Click(object sender, RoutedEventArgs e)
         {
            NavigationService.Navigate(new FrontPage());
         }
        private void SaveChangesBtn_Click(object sender, RoutedEventArgs e)
        {
            dbContext.SaveChanges();
        }

        private void Add_Room_Service_Click(object sender, RoutedEventArgs e)
        {
            if (roomNumberCombo.SelectedItem != null)
            {
                if (!String.IsNullOrWhiteSpace(RoomServiceItem.Text))
                {
                    RoomService service = new RoomService
                    {
                        Room = hotelRoomList.Find(x => x.Id == (int)roomNumberCombo.SelectedItem),
                        Item = RoomServiceItem.Text,
                        Status = Constants.roomServiceStatuses[0]
                    };

                    dbContext.AddRoomService(service);
                    serviceList.ItemsSource = dbContext.RoomServices.ToList();
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
            if (serviceList.SelectedItem != null)
            {
                HotelRoom room = (serviceList.SelectedItem as RoomService)?.Room;

                dbContext.DeleteRoomService(serviceList.SelectedItem as RoomService);
                serviceList.ItemsSource = dbContext.RoomServices.ToList();
            }
        }
    }
}
