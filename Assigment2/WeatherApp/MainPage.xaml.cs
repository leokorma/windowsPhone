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

            NavigationService.Navigate(new Uri("/views/Results.xaml?regex=" + searchInput.Text + "&isCityName=" + cityNameRadioButton.IsChecked, UriKind.Relative));
        }

        /**
         * Helper function for hiding messages
         */
        private void hideMessages()
        {
            searchBlankMessage.Visibility = Visibility.Collapsed;
        }

        /**
         * Validation method for Search Text
         */
        private bool isValidSearchText()
        {
            return !String.IsNullOrEmpty(searchInput.Text);
        }
    }
}