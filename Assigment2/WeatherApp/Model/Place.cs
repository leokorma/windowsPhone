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

namespace WeatherApp.models
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
    }

    public class Results
    {
        public List<Place> place { get; set; }
    }

    public class PlaceQuery
    {
        public int count { get; set; }
        public Results results { get; set; }
    }

    public class PlaceJson
    {
        public PlaceQuery query { get; set; }
    }
}
