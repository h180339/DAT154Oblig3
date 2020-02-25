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
        }
    }
}
