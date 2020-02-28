using DatabaseHandlerStandard;
using DatabaseHandlerStandard.Model;
using Microsoft.EntityFrameworkCore;
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

namespace Oblig_3_Desktop_app
{
    /// <summary>
    /// Interaction logic for CheckIn.xaml
    /// </summary>
    public partial class CheckIn : Page
    {
        private BookingDbContext dbContext;
        private List<Reservation> resList;
        public CheckIn()
        {
            InitializeComponent();

            //CRAZY ASS SEED METHOD, BE CAREFUL.
            //Seed();
            Load();
        }
        private void Load()
        {
            dbContext = new BookingDbContext();
            resList = dbContext.Reservations.ToList();
            reservationGrid.ItemsSource = resList;
            List<User> userList = dbContext.Users.ToList();
        }

        private void HomeBtnClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new FrontPage());

        }

        private void checkInBtnClick(object sender, RoutedEventArgs e)
        {
            Reservation selectedReservation = reservationGrid.SelectedItem as Reservation;

            Reservation databaseReservation = resList.Find(x => x.Id == selectedReservation.Id);

            databaseReservation.Status = Constants.reservationStatus[1];

            dbContext.SaveChanges();
            reservationGrid.ItemsSource = null;
            Load();
        }
        private void checkOutBtnClick(object sender, RoutedEventArgs e)
        {
            Reservation selectedReservation = reservationGrid.SelectedItem as Reservation;
            resList = dbContext.Reservations.ToList();
            List<HotelRoom> hotelRoomList = dbContext.HotelRooms.ToList();

            Reservation databaseReservation = resList.Find(x => x.Id == selectedReservation.Id);

            databaseReservation.Status = Constants.reservationStatus[2];

            databaseReservation.HotelRoom.status = Constants.roomStatuses[1];

            dbContext.SaveChanges();

            reservationGrid.ItemsSource = null;
            Load();


        }

        private void SearchBtnClick(object sender, RoutedEventArgs e)
        {
            List<Reservation> searchResList = dbContext.Reservations.ToList();

            searchResList.RemoveAll(r => !(r.User.username.ToLower().Equals(searchText.Text.Trim().ToLower())));
            reservationGrid.ItemsSource = null;
            reservationGrid.ItemsSource = searchResList;
        }

        private void resetReservationGrid()
        {
            reservationGrid.ItemsSource = null;
            reservationGrid.ItemsSource = resList;
        }
        private void resetBtnClick(object sender, RoutedEventArgs e)
        {
            resetReservationGrid();
        }
        protected void Seed()
        {

            BookingDbContext dbContext = new BookingDbContext();
            //Users
            dbContext.AddUser(new User
            {
                username = "Eirik",
                password = "passord",
            });

            //HotelRooms: 
            List<HotelRoom> rooms = new List<HotelRoom>()
            {
                new HotelRoom
                {
                    numberOfBeds = 2,
                    roomSize = 20,
                    quality = "Economy",
                    status = "Clean"
                },
                new HotelRoom
                {
                    numberOfBeds = 4,
                    roomSize = 100,
                    quality = "Suite",
                    status = "Clean"
                },
                new HotelRoom
                {
                    numberOfBeds = 3,
                    roomSize = 70,
                    quality = "Economy",
                    status = "Clean"
                },
                new HotelRoom
                {
                    numberOfBeds = 3,
                    roomSize = 50,
                    quality = "High",
                    status = "Clean"
                },
                new HotelRoom
                {
                    numberOfBeds = 1,
                    roomSize = 10,
                    quality = "Low",
                    status = "Clean"
                },
                new HotelRoom
                {
                    numberOfBeds = 3,
                    roomSize = 60,
                    quality = "Medium",
                    status = "Clean"
                }

            };
            foreach (HotelRoom r in rooms)
            {
                dbContext.AddHotelRoom(r);
            }


            dbContext.AddRoomService(new DatabaseHandlerStandard.Model.RoomService
            {
                Room = rooms[0],
                Item = "Pizza",
                Status = Constants.roomServiceStatuses[0]
                
            });

            dbContext.SaveChanges();

        }
    }
}
