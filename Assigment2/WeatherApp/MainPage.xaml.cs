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
using WeatherApp.ViewModel;
using System.Collections.ObjectModel;
using WeatherApp.Model;
using Newtonsoft.Json;

namespace WeatherApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        /**
         * Function to call when search button is clicked
         */
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
                downloadCitiesJson(searchInput.Text);
            }
            else
            {
                // if city code radio button is selected, go directly to weather page
                NavigationService.Navigate(new Uri("/View/WeatherPage.xaml?woeid=" + searchInput.Text, UriKind.Relative));
            }
        }

        /**
        * Method called when entering the page.
        */
        private void downloadCitiesJson(string name)
        {
            string uri = "http://query.yahooapis.com/v1/public/yql?format=json&q=select * from geo.places where text='" + name + "'";

            WebClient client = new WebClient();
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(processCities);
            client.DownloadStringAsync(new Uri(uri));
        }

        private void processCities(object sender, DownloadStringCompletedEventArgs e)
        {
            App.CityViewModel.processJson(sender, e);

            ObservableCollection<City> cities = App.CityViewModel.Cities;
            if (cities != null && cities.Count > 0)
            {
                string json = JsonConvert.SerializeObject(cities);
                NavigationService.Navigate(new Uri("/View/CityPage.xaml?json=" + json, UriKind.Relative));
            }
            else
            {
                noCitiesFoundMessage.Visibility = Visibility.Visible;
            }
        }

        /**
         * Helper function for hiding messages
         */
        private void hideMessages()
        {
            searchBlankMessage.Visibility = Visibility.Collapsed;
            wrongWoeidMessage.Visibility = Visibility.Collapsed;
            noCitiesFoundMessage.Visibility = Visibility.Collapsed;
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
            if (cityCodeRadioButton.IsChecked == false)
            {
                return true;
            }

            try
            {
                int woeid = int.Parse(searchInput.Text);
                return (woeid > 0);
            }
            catch
            {
                return false;
            }
        }

        /**
         * Function to execute actions when input text changes
         */
        private void searchInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            hideMessages();
        }

        /**
         * Function to execute actions when radio button for city name is clicked
         */
        private void cityNameRadioButton_Click(object sender, RoutedEventArgs e)
        {
            hideMessages();
        }

        /**
         * Function to execute actions when radio button for city code is clicked
         */
        private void cityCodeRadioButton_Click(object sender, RoutedEventArgs e)
        {
            hideMessages();
        }
    }
}