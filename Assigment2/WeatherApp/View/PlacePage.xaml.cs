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
using WeatherApp.models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WeatherApp.View
{
    public partial class PlacePage : PhoneApplicationPage
    {
        // Constructor
        public PlacePage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            hideMessages();
            this.PlaceList.ItemsSource = new List<Place>();

            string regex = "";
            NavigationContext.QueryString.TryGetValue("regex", out regex);

            string isCityName = "";
            NavigationContext.QueryString.TryGetValue("isCityName", out isCityName);

            if (String.IsNullOrWhiteSpace(regex) || string.IsNullOrWhiteSpace(isCityName))
            {
                errorResultsMessage.Visibility = Visibility.Visible;
                return;
            }

            // call the rate service
            var service = new PlaceViewModel();
            service.searchPlaces(regex, isCityName, updateList);
        }

        private void updateList(List<Place> places) {
            if (places == null || places.Count <= 0)
            {
                noResultsMessage.Visibility = Visibility.Visible;
            }
            this.PlaceList.ItemsSource = places;
        }

        /**
         * Helper function for hiding messages
         */
        private void hideMessages()
        {
            errorResultsMessage.Visibility = Visibility.Collapsed;
            noResultsMessage.Visibility = Visibility.Collapsed;
        }
    }
}