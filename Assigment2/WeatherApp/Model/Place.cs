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
using WeatherApp.Model;

namespace WeatherApp.models
{
    public class Country
    {
        public string code { get; set; }
        public string content { get; set; }
    }

    public class Place : ObservableObject
    {
        private string _woeid;
        private string _name;
        private Country _country;

        // Create the property that will be the source of the binding.
        public string woeid
        {
            get { return _woeid; }
            set
            {
                _woeid = value;
                // Call NotifyPropertyChanged when the source property 
                // is updated.
                NotifyPropertyChanged("woeid");
            }
        }

        // Create the property that will be the source of the binding.
        public string name
        {
            get { return _name; }
            set
            {
                _name = value;
                // Call NotifyPropertyChanged when the source property 
                // is updated.
                NotifyPropertyChanged("name");
            }
        }

        // Create the property that will be the source of the binding.
        public Country country
        {
            get { return _country; }
            set
            {
                _country = value;
                // Call NotifyPropertyChanged when the source property 
                // is updated.
                NotifyPropertyChanged("country");
            }
        }
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
