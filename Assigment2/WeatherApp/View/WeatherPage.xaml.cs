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
    public partial class WeatherPage : PhoneApplicationPage
    {
        // Constructor
        public WeatherPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            hideMessages();

            string woeid = "";
            NavigationContext.QueryString.TryGetValue("woeid", out woeid);

            if (String.IsNullOrWhiteSpace(woeid) || string.IsNullOrWhiteSpace(woeid))
            {
                errorWoeidMessage.Visibility = Visibility.Visible;
                return;
            }

            var service = new PlaceViewModel();
            service.searchPlacesByCodeName(woeid, updateUI);
        }

        private void updateUI(Weather weather) {
            cityTitle.Text = "";
            
            if (weather == null) {
                noWeatherMessage.Visibility = Visibility.Visible;
                return;
            }
                        
            if (weather.query.results.channel.title.Contains("Error"))
            {
                errorWoeidMessage.Visibility = Visibility.Visible;
                return;
            }

            cityTitle.Text = weather.query.results.channel.location.city + ", " + weather.query.results.channel.location.country;
        }

        /**
         * Helper function for hiding messages
         */
        private void hideMessages()
        {
            errorWoeidMessage.Visibility = Visibility.Collapsed;
            noWeatherMessage.Visibility = Visibility.Collapsed;
        }
    }
}