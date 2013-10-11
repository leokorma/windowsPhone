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

namespace WeatherApp.ViewModel
{
    public class ResultViewModel
    {
        public ObservableCollection<Place> Places { get; set; }


        public void GetPlaces()
        {
            GetDefaultPlaces();
        }


        public void GetDefaultPlaces()
        {
            ObservableCollection<Place> a = new ObservableCollection<Place>();

            // Items to collect
            a.Add(new Place() { name = "Burgos" });

            Places = a;
        }
    }
}
