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
    public class ServiceViewModel
    {
        /*
         * Method to get city list from Yahoo
         */
        public void searchCitiesByCityName(String name, Action<List<City>> callback)
        {
            string uri = "http://query.yahooapis.com/v1/public/yql?format=json&q=select * from geo.places where text='" + name + "'";

            WebClient client = new WebClient();
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(processCitiesByName);
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
        private void processCitiesByName(object sender, DownloadStringCompletedEventArgs e)
        {
            List<City> cities = new List<City>();

            if (e.Error == null)
            {
                string json = e.Result;

                try
                {
                    cities = parseMultipleCities(json);
                }
                catch (Exception)
                {
                    cities = parseUniqueCity(json);
                }
            }

            var callback = (Action<List<City>>)e.UserState;
            if (callback != null)
                callback(cities);
            return;
        }

        /**
         * Helper function to parse json from string to Object
         * This parser is used as default, since it is possible to receive multiple places within json response string
         */
        private List<City> parseMultipleCities(string json)
        {
            List<City> cities = new List<City>();

            MultiGeoPlace jsonResult = JsonConvert.DeserializeObject<MultiGeoPlace>(json);
            if (jsonResult.query.count > 0)
            {
                foreach (Place place in jsonResult.query.results.place)
                {
                    City city = new City();
                    city.name = place.name;
                    city.woeid = place.woeid;
                    city.country = place.country.content;
                    cities.Add(city);
                }
            }

            return cities;
        }

        /**
         * Helper function to parse json from string to Object
         * This parser is used in case default parser fails, since it may happen that there is only one place in json response string
         */
        private List<City> parseUniqueCity(string json)
        {
            List<City> cities = new List<City>();

            UniqueGeoPlace jsonResult = JsonConvert.DeserializeObject<UniqueGeoPlace>(json);
            if (jsonResult.query.count > 0)
            {
                Place place = jsonResult.query.results.place;

                City city = new City();
                city.name = place.name;
                city.woeid = place.woeid;
                city.country = place.country.content;
                cities.Add(city);
            }

            return cities;
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
