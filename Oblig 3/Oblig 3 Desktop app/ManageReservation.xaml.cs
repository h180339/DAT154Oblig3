using DatabaseHandler;
using DatabaseHandler.Model;
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
    /// Interaction logic for ManageReservation.xaml
    /// </summary>
    public partial class ManageReservation : Page
    {
        private BookingDbContext dbContext;

        public ManageReservation()
        {
            InitializeComponent();
            Load();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new FrontPage());
        }
        private void Load()
        {
            dbContext = new BookingDbContext();
            List<Reservation> resList = dbContext.Reservations.ToList();
            reservationGrid.ItemsSource = resList;
            List<string> usernameList = new List<string>();
            foreach(User u in dbContext.Users.ToList())
            {
                usernameList.Add(u.username);
            }
            userNamesDropDown.ItemsSource = dbContext.Users.ToList();
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            int id = (reservationGrid.SelectedItem as Reservation).Id;
            dbContext = new BookingDbContext();
            dbContext.DeleteReservation(id);
            reservationGrid.ItemsSource = null;
            reservationGrid.ItemsSource = dbContext.Reservations.ToList();

            //add functionality to remove reservation from database
            
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            User selectedUser = userNamesDropDown.SelectedItem as User;

            dbContext = new BookingDbContext();
            DateTime? checkIn = getDatesSelected().Item1;
            DateTime? checkOut = getDatesSelected().Item2;
            if(checkIn != null && checkOut != null && selectedUser != null)
            {
                List<HotelRoom>  hrList = dbContext.getRoomsInTimeperiod(getDatesSelected());
                serchResGrid.ItemsSource = hrList;
            }

        }
        
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            dbContext = new BookingDbContext();
            int hotelRoomId = (serchResGrid.SelectedItem as HotelRoom).Id;
            int userId = (userNamesDropDown.SelectedItem as User).Id;

            dbContext.AddReservation(hotelRoomId, userId, getDatesSelected());

            reservationGrid.ItemsSource = null;
            reservationGrid.ItemsSource = dbContext.Reservations.ToList();

            serchResGrid.ItemsSource = null;
            serchResGrid.ItemsSource = dbContext.getRoomsInTimeperiod(getDatesSelected());
        }

        private (DateTime?, DateTime?) getDatesSelected()
        {
            return (CheckInCal.SelectedDate, CheckOutCal.SelectedDate);
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            EditReservationPage erp = new EditReservationPage(reservationGrid.SelectedItem as Reservation);
            erp.ShowDialog();
        }
    }
}
