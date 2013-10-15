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
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;
using WeatherApp.Model;

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

            if (String.IsNullOrWhiteSpace(regex))
            {
                errorResultsMessage.Visibility = Visibility.Visible;
                return;
            }

            var service = new PlaceViewModel();
            service.searchPlacesByCityName(regex, updateList);
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

        private void GetWeatherByPlace(object sender, GestureEventArgs e)
        {
            // íf selected index is -1 (no selection), do nothing
            if (PlaceList.SelectedIndex == -1)
            {
                return;
            }

            Place p = (Place)PlaceList.SelectedItem;
            if (p != null) {
                NavigationService.Navigate(new Uri("/View/WeatherPage.xaml?woeid=" + p.woeid, UriKind.Relative));
                return;
            }
            
            // rest the selected index
            PlaceList.SelectedIndex = -1;
        }
    }
}