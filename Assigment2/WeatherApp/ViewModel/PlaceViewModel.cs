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
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using WeatherApp.Model;

namespace WeatherApp.ViewModel
{
    public class PlaceViewModel
    {
        public void searchPlacesByCityName(String name, Action<List<Place>> callback)
        {
            string uri = "http://query.yahooapis.com/v1/public/yql?format=json&q=select * from geo.places where text='" + name + "'";

            WebClient client = new WebClient();
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(processPlacesByName);
            client.DownloadStringAsync(new Uri(uri), callback);
        }

        public void searchPlacesByCodeName(String code, Action<Weather> callback)
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

                try
                {
                    places = parseMultiplePlaces(json);
                }catch(Exception){
                    places = parseUniquePlace(json);
                }
            }
            
            // if a callback was specified, call it passing the rate.
            var callback = (Action<List<Place>>)e.UserState;
            if (callback != null)
                callback(places);
            return;
        }

        private List<Place> parseMultiplePlaces(string json)
        {
            List<Place> places = new List<Place>();

            MultiPlaceJson placeJson = JsonConvert.DeserializeObject<MultiPlaceJson>(json);
            if (placeJson.query.count > 0)
            {
                places = placeJson.query.results.place;
            }

            return places;
        }

        private List<Place> parseUniquePlace(string json)
        {
            List<Place> places = new List<Place>();

            OnePlaceJson placeJson = JsonConvert.DeserializeObject<OnePlaceJson>(json);
            if (placeJson.query.count > 0)
            {
                places.Add(placeJson.query.results.place);
            }

            return places;
        }

        private void processPlacesByCode(object sender, DownloadStringCompletedEventArgs e)
        {
            Weather weather = null;

            if (e.Error == null)
            {
                string json = e.Result;
                weather = JsonConvert.DeserializeObject<Weather>(json); 
            }

            // if a callback was specified, call it passing the rate.
            var callback = (Action<Weather>)e.UserState;
            if (callback != null)
                callback(weather);
            return;
        }
    }
}
