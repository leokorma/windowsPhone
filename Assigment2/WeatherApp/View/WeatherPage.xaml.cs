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
using WeatherApp.Model.json;
using System.Windows.Resources;
using System.IO;

namespace WeatherApp.View
{
    public partial class WeatherPage : PhoneApplicationPage
    {
        // Constructor
        public WeatherPage()
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
            hideContainers();

            // Retrieves the parameters sent by the previous page (woeid)
            string woeid = "";
            NavigationContext.QueryString.TryGetValue("woeid", out woeid);

            if (String.IsNullOrWhiteSpace(woeid) || string.IsNullOrWhiteSpace(woeid))
            {
                errorWoeidMessage.Visibility = Visibility.Visible;
                return;
            }

            // Calls the viewModel in charge of accessing Yahoo to get the data and updates the UI when data is retrieved
            var service = new PlaceViewModel();
            service.searchPlacesByCodeName(woeid, updateUI);
        }

        /**
         * Function to update UI elements depending on the WebClient results
         */
        private void updateUI(Weather weather)
        {
            this.cityTitle.Text = "";
            this.todayTemperature.Text = "";
            this.ForecastList.ItemsSource = new List<Forecast>();

            if (weather == null)
            {
                noWeatherMessage.Visibility = Visibility.Visible;
                return;
            }

            if (weather.query.results.channel.title.Contains("Error"))
            {
                errorWoeidMessage.Visibility = Visibility.Visible;
                return;
            }

            this.cityTitle.Text = weather.query.results.channel.location.city + ", " + weather.query.results.channel.location.country;

            this.todayTemperature.Text = weather.query.results.channel.item.condition.temp + weather.query.results.channel.units.temperature;

            this.ForecastList.ItemsSource = weather.query.results.channel.item.forecast;

            this.todayWeather.Visibility = Visibility.Visible;
            this.ForecastList.Visibility = Visibility.Visible;
        }

        /**
         * Helper function for hiding messages
         */
        private void hideMessages()
        {
            errorWoeidMessage.Visibility = Visibility.Collapsed;
            noWeatherMessage.Visibility = Visibility.Collapsed;
        }

        /**
        * Helper function for hiding containers (for error cases)
        */
        private void hideContainers()
        {
            this.todayWeather.Visibility = Visibility.Collapsed;
            this.ForecastList.Visibility = Visibility.Collapsed;
        }
    }
}