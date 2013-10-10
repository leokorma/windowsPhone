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
using WeatherApp.models;

namespace WeatherApp
{
    public partial class Results : PhoneApplicationPage
    {
        public Results()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            hideMessages();

            string regex = "";
            NavigationContext.QueryString.TryGetValue("regex", out regex);

            string isCityName = "";
            if (NavigationContext.QueryString.TryGetValue("isCityName", out isCityName)) {
                if (Convert.ToBoolean(isCityName)) {
                    searchResultsByCityName(regex);
                    return;
                }
                searchResultsByCodeName(regex);
            }
            
        }

        private void searchResultsByCityName(String name)
        {
            string uri = "http://query.yahooapis.com/v1/public/yql?format=json&q=select * from geo.places where text='" + name + "'";

            WebClient client = new WebClient();
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(processResultsByName);
            client.DownloadStringAsync(new Uri(uri));
        }

        private void searchResultsByCodeName(String code)
        {
            string uri = "http://query.yahooapis.com/v1/public/yql?format=json&q=select * from weather.forecast where woeid=" + code;

            WebClient client = new WebClient();
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(processResultsByCode);
            client.DownloadStringAsync(new Uri(uri));
        }

        private void processResultsByName(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                errorResultsMessage.Visibility = Visibility.Visible;
                return;
            }
               
            string json = e.Result;
            PlaceJson placeJson = JsonConvert.DeserializeObject<PlaceJson>(json);
            if (placeJson.query.count <= 0)
            {
                noResultsMessage.Visibility = Visibility.Visible;
                return;
            }
            ResultsListBox.DataContext = placeJson.query.results.place;
        }

        private void processResultsByCode(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null) {
            }
            else {
                errorResultsMessage.Visibility = Visibility.Visible;
            }               
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