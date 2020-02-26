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
    /// Interaction logic for CheckIn.xaml
    /// </summary>
    public partial class CheckIn : Page
    {
        private BookingDbContext dbContext;
        private List<Reservation> resList;
        public CheckIn()
        {
            InitializeComponent();
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

            databaseReservation.Status = "Checked in";

            dbContext.SaveChanges();
            reservationGrid.ItemsSource = null;
            Load();
        }
        private void checkOutBtnClick(object sender, RoutedEventArgs e)
        {
            Reservation selectedReservation = reservationGrid.SelectedItem as Reservation;

            Reservation databaseReservation = resList.Find(x => x.Id == selectedReservation.Id);

            databaseReservation.Status = "Checked out";

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
    }
}
