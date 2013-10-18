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
using WeatherApp.Model.json;

namespace WeatherApp.ViewModel
{
    public class PlaceViewModel
    {
        /*
         * Method to get city list from Yahoo
         */
        public void searchPlacesByCityName(String name, Action<List<Place>> callback)
        {
            string uri = "http://query.yahooapis.com/v1/public/yql?format=json&q=select * from geo.places where text='" + name + "'";

            WebClient client = new WebClient();
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(processPlacesByName);
            client.DownloadStringAsync(new Uri(uri), callback);
        }

        /*
         * Method to get weather from Yahoo
         */
        public void searchPlacesByCodeName(String code, Action<Weather> callback)
        {
            string uri = "http://query.yahooapis.com/v1/public/yql?format=json&q=select * from weather.forecast where woeid=" + code;

            WebClient client = new WebClient();
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(processPlacesByCode);
            client.DownloadStringAsync(new Uri(uri), callback);
        }

        /**
         * Callback function for when the WebClient has finalize reaching data (json with cities data) from Yahoo
         */
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
            
            var callback = (Action<List<Place>>)e.UserState;
            if (callback != null)
                callback(places);
            return;
        }

        /**
         * Helper function to parse json from string to Object
         * This parser is used as default, since it is possible to receive multiple places within json response string
         */
        private List<Place> parseMultiplePlaces(string json)
        {
            List<Place> places = new List<Place>();

            MultiGeoPlace jsonResult = JsonConvert.DeserializeObject<MultiGeoPlace>(json);
            if (jsonResult.query.count > 0)
            {
                places = jsonResult.query.results.place;
            }

            return places;
        }

        /**
         * Helper function to parse json from string to Object
         * This parser is used in case default parser fails, since it may happen that there is only one place in json response string
         */
        private List<Place> parseUniquePlace(string json)
        {
            List<Place> places = new List<Place>();

            UniqueGeoPlace jsonResult = JsonConvert.DeserializeObject<UniqueGeoPlace>(json);
            if (jsonResult.query.count > 0)
            {
                places.Add(jsonResult.query.results.place);
            }

            return places;
        }

        /**
         * Callback function for when the WebClient has finalize reaching data (json with weather data) from Yahoo
         */
        private void processPlacesByCode(object sender, DownloadStringCompletedEventArgs e)
        {
            Weather weather = null;

            if (e.Error == null)
            {
                string json = e.Result;
                weather = JsonConvert.DeserializeObject<Weather>(json); 
            }

            var callback = (Action<Weather>)e.UserState;
            if (callback != null)
                callback(weather);
            return;
        }
    }
}
