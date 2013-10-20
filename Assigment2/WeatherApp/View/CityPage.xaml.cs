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
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;
using WeatherApp.Model;
using WeatherApp.Model.json;
using WeatherApp.ViewModel;

namespace WeatherApp.View
{
    public partial class CityPage : PhoneApplicationPage
    {
        // Constructor
        public CityPage()
        {
            InitializeComponent();
        }

        /**
         * Method called when entering the page.
         */
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            hideMessages();
            this.CityList.ItemsSource = new List<City>();

            // Retrieves the parameters sent by the previous page (regex)
            string regex = "";
            NavigationContext.QueryString.TryGetValue("regex", out regex);

            if (String.IsNullOrWhiteSpace(regex))
            {
                errorResultsMessage.Visibility = Visibility.Visible;
                return;
            }

            // Calls the viewModel in charge of accessing Yahoo to get the data and updates the UI when data is retrieved
            var service = new ServiceViewModel();
            service.searchCitiesByCityName(regex, updateList);
        }

        /**
        * Function to update List elements depending on the WebClient results
        */
        private void updateList(List<City> cities)
        {
            if (cities == null || cities.Count <= 0)
            {
                noResultsMessage.Visibility = Visibility.Visible;
            }
            this.CityList.ItemsSource = cities;
        }

        /**
         * Helper function for hiding messages
         */
        private void hideMessages()
        {
            errorResultsMessage.Visibility = Visibility.Collapsed;
            noResultsMessage.Visibility = Visibility.Collapsed;
        }

        /**
        * Method call when tapping on one list element (cities) to go to the weather page with the correspondent Woied code
        */
        private void GetWeatherByCity(object sender, GestureEventArgs e)
        {
            if (CityList.SelectedIndex == -1)
            {
                return;
            }

            City city = (City)CityList.SelectedItem;
            if (city != null)
            {
                NavigationService.Navigate(new Uri("/View/WeatherPage.xaml?woeid=" + city.woeid, UriKind.Relative));
                return;
            }

            CityList.SelectedIndex = -1;
        }
    }
}