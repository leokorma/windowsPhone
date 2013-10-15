using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace WeatherApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            hideMessages();

            if (!isValidSearchText())
            {
                searchBlankMessage.Visibility = Visibility.Visible;
                return;
            }

            if (!isValidWoeidCode())
            {
                wrongWoeidMessage.Visibility = Visibility.Visible;
                return;
            }

            if (Convert.ToBoolean(cityNameRadioButton.IsChecked))
            {
                NavigationService.Navigate(new Uri("/View/PlacePage.xaml?regex=" + searchInput.Text, UriKind.Relative));
            }
            else
            {
                NavigationService.Navigate(new Uri("/View/WeatherPage.xaml?woeid=" + searchInput.Text, UriKind.Relative));
            }
        }

        /**
         * Helper function for hiding messages
         */
        private void hideMessages()
        {
            searchBlankMessage.Visibility = Visibility.Collapsed;
            wrongWoeidMessage.Visibility = Visibility.Collapsed;
        }

        /**
         * Validation method for Search Text
         */
        private bool isValidSearchText()
        {
            return !String.IsNullOrEmpty(searchInput.Text);
        }
        
        /**
        * Validation method for Woeid Code
        */
        private bool isValidWoeidCode()
        {
            if (cityCodeRadioButton.IsChecked==false) {
                return true;
            }

            try
            {
                int woeid = int.Parse(searchInput.Text);
                return (woeid > 0);
            }
            catch {
                return false;
            }
        }
    }
}