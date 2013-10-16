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

/**
 * Class that represents Json
 * Created using json2csharp.com
 * Modified for better easy access to certain data
 */
namespace WeatherApp.Model
{
    public class Country
    {
        public string code { get; set; }
        public string content { get; set; }
    }

    public class Place
    {
        public string woeid { get; set; }
        public string name { get; set; }
        public Country country { get; set; }

        private string _fullName;
        public string FullName
        {
            get { return name + ((country != null) ?", " + country.content : ""); }
            set { _fullName = value; }
        }
    }

    public class MultiPlaceResults
    {
        public List<Place> place { get; set; }
    }

    public class OnePlaceResults
    {
        public Place place { get; set; }
    }

    public class MultiPlaceQuery
    {
        public int count { get; set; }
        public MultiPlaceResults results { get; set; }
    }

    public class OnePlaceQuery
    {
        public int count { get; set; }
        public OnePlaceResults results { get; set; }
    }

    public class MultiPlaceJson
    {
        public MultiPlaceQuery query { get; set; }
    }

    public class OnePlaceJson
    {
        public OnePlaceQuery query { get; set; }
    }
}
