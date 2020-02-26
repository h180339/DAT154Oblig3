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
using System.Windows.Shapes;

namespace Oblig_3_Desktop_app
{
    /// <summary>
    /// Interaction logic for EditReservationPage.xaml
    /// </summary>
    public partial class EditReservationPage : Window
    {
        private BookingDbContext dbContext;
        private Reservation chosenReservation;
        private ManageReservation manageReservation;

        public EditReservationPage(Reservation reservation, ManageReservation manageReservation)
        {
            InitializeComponent();
            dbContext = new BookingDbContext();
            this.chosenReservation = dbContext.findReservation(reservation.Id);
            this.manageReservation = manageReservation;
            Load();
        }

        private void Load()
        {
            DateTime? checkIn = this.chosenReservation.startDate;
            DateTime? checkOut = this.chosenReservation.endDate;
            List<HotelRoom> hrList = dbContext.getRoomsInTimeperiod((checkIn, checkOut));
            editReservationGrid.ItemsSource = hrList;
        }


        private void ChooseBtn_Click(object sender, RoutedEventArgs e)
        {
            HotelRoom gridHR = (editReservationGrid.SelectedItem as HotelRoom);
            this.chosenReservation.HotelRoomId = gridHR.Id;
            this.chosenReservation.HotelRoom = dbContext.findHotelRoom(gridHR.Id);
            dbContext.replaceReservation(this.chosenReservation);
            manageReservation.Load();
            this.Close();
        }
    }
}
