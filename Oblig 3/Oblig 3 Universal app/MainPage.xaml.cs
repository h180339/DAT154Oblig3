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


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Oblig_3_Universal_app
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void MaintainerBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MaintainerPage), null);
        }

        private void CleanerBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CleanerPage), null);
        }

        private void ServiceBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ServicePage), null);
        }
    }
}
