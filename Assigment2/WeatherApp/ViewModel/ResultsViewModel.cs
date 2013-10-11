using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using WeatherApp.models;
using Newtonsoft.Json;

namespace WeatherApp.ViewModel
{
    public class ResultsViewModel
    {
        public ObservableCollection<Place> Places { get; set; }

        public void searchResults(string regex, string isCityName)
        {
            if (Convert.ToBoolean(isCityName))
            {
                searchResultsByCityName(regex);
            }
            else
            {
                searchResultsByCodeName(regex);
            }
        }

        public void searchResultsByCityName(String name)
        {
            string uri = "http://query.yahooapis.com/v1/public/yql?format=json&q=select * from geo.places where text='" + name + "'";

            WebClient client = new WebClient();
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(processResultsByName);
            client.DownloadStringAsync(new Uri(uri));
        }

        public void searchResultsByCodeName(String code)
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
                throw new ErrorResultsException();
            }

            string json = e.Result;
            PlaceJson placeJson = JsonConvert.DeserializeObject<PlaceJson>(json);
            if (placeJson.query.count <= 0)
            {
                throw new NoResultsException();
            }

            Places = new ObservableCollection<Place>(placeJson.query.results.place);
        }

        private void processResultsByCode(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null)
            {
            }
            else
            {
                //errorResultsMessage.Visibility = Visibility.Visible;
            }
        }
    }

}
