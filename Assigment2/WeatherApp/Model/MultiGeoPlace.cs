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

namespace WeatherApp.Model.json
{
    public class MultiGeoPlaceResults
    {
        public List<Place> place { get; set; }
    }

    public class MultiGeoPlaceQuery
    {
        public int count { get; set; }
        public string created { get; set; }
        public string lang { get; set; }
        public MultiGeoPlaceResults results { get; set; }
    }

    public class MultiGeoPlace
    {
        public MultiGeoPlaceQuery query { get; set; }
    }
}
