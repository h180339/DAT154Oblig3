﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using DatabaseHandlerStandard.Model;
using DatabaseHandlerStandard;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Oblig_3_Universal_app
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CleanerPage : Page
    {
        private BookingDbContext dbContext;
        public List<HotelRoom> HotelRooms { get; set; } = new List<HotelRoom>();
        public CleanerPage()
        {
            this.InitializeComponent();
            dbContext = new BookingDbContext();
            HotelRooms = dbContext.HotelRooms.ToList();

            HotelRooms.RemoveAll(r => !(r.status.Equals(DatabaseHandlerStandard.Constants.roomStatuses[1]) || r.status.Equals(DatabaseHandlerStandard.Constants.roomStatuses[4])));
            serviceList.ItemsSource = HotelRooms;
            statusColumn.ItemsSource = DatabaseHandlerStandard.Constants.roomStatuses;
            qualityColumn.ItemsSource = DatabaseHandlerStandard.Constants.roomQualities;
        }

        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage), null);
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            dbContext.SaveChanges();
        }
    }
}
