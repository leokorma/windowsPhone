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
using WeatherApp.models;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace WeatherApp.ViewModel
{
    public class PlaceViewModel
    {
        public void searchPlaces(string regex, string isCityName, Action<List<Place>> callback)
        {
            if (Convert.ToBoolean(isCityName))
            {
                searchPlacesByCityName(regex, callback);
            }
            else
            {
                searchPlacesByCodeName(regex, callback);
            }
        }

        private void searchPlacesByCityName(String name, Action<List<Place>> callback)
        {
            string uri = "http://query.yahooapis.com/v1/public/yql?format=json&q=select * from geo.places where text='" + name + "'";

            WebClient client = new WebClient();
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(processPlacesByName);
            client.DownloadStringAsync(new Uri(uri), callback);
        }

        private void searchPlacesByCodeName(String code, Action<List<Place>> callback)
        {
            string uri = "http://query.yahooapis.com/v1/public/yql?format=json&q=select * from weather.forecast where woeid=" + code;

            WebClient client = new WebClient();
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(processPlacesByCode);
            client.DownloadStringAsync(new Uri(uri), callback);
        }

        private void processPlacesByName(object sender, DownloadStringCompletedEventArgs e)
        {
            List<Place> places = new List<Place>();

            if (e.Error == null)
            {
                string json = e.Result;
                PlaceJson placeJson = JsonConvert.DeserializeObject<PlaceJson>(json);
                if (placeJson.query.count > 0)
                {
                    places = placeJson.query.results.place;
                }
            }
            
            // if a callback was specified, call it passing the rate.
            var callback = (Action<List<Place>>)e.UserState;
            if (callback != null)
                callback(places);
            return;
        }

        private void processPlacesByCode(object sender, DownloadStringCompletedEventArgs e)
        {
            List<Place> places = new List<Place>();

            if (e.Error == null)
            {
                // DO SOMETHING
            }

            // if a callback was specified, call it passing the rate.
            var callback = (Action<List<Place>>)e.UserState;
            if (callback != null)
                callback(places);
            return;
        }
    }
}
