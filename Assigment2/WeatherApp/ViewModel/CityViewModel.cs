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
    public class CityViewModel
    {

        private ObservableCollection<City> _cities = null;
        public ObservableCollection<City> Cities
        {
            get
            {
                if (_cities == null)
                {
                    _cities = new ObservableCollection<City>();
                }
                return _cities;
            }
        }

        /**
         * Callback function for when the WebClient has finalize reaching data (json with cities data) from Yahoo
         */
        public void processJson(object sender, DownloadStringCompletedEventArgs e)
        {
            _cities = new ObservableCollection<City>();

            if (e.Error == null)
            {
                string json = e.Result;

                try
                {
                    parseMultiplePlaces(json);
                }
                catch (Exception)
                {
                    parseUniquePlace(json);
                }
            }
        }

        /**
         * Helper function to parse json from string to Object
         * This parser is used as default, since it is possible to receive multiple places within json response string
         */
        private void parseMultiplePlaces(string json)
        {
            MultiGeoPlace jsonResult = JsonConvert.DeserializeObject<MultiGeoPlace>(json);
            if (jsonResult.query.count > 0)
            {
                foreach (Place place in jsonResult.query.results.place)
                {
                    City city = new City();
                    city.name = place.name;
                    city.woeid = place.woeid;
                    city.country = place.country.content;

                    _cities.Add(city);
                }
            }
        }

        /**
         * Helper function to parse json from string to Object
         * This parser is used in case default parser fails, since it may happen that there is only one place in json response string
         */
        private void parseUniquePlace(string json)
        {
            UniqueGeoPlace jsonResult = JsonConvert.DeserializeObject<UniqueGeoPlace>(json);
            if (jsonResult.query.count > 0)
            {
                Place place = jsonResult.query.results.place;

                City city = new City();
                city.name = place.name;
                city.woeid = place.woeid;
                city.country = place.country.content;

                _cities.Add(city);
            }
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
        }
    }
}
