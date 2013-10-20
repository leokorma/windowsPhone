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

namespace WeatherApp.Model.json
{
    public class PlaceTypeName
    {
        public string code { get; set; }
        public string content { get; set; }
    }

    public class Country
    {
        public string code { get; set; }
        public string type { get; set; }
        public string woeid { get; set; }
        public string content { get; set; }
    }

    public class Admin1
    {
        public string code { get; set; }
        public string type { get; set; }
        public string woeid { get; set; }
        public string content { get; set; }
    }

    public class Admin2
    {
        public string code { get; set; }
        public string type { get; set; }
        public string woeid { get; set; }
        public string content { get; set; }
    }

    public class Admin3
    {
        public string code { get; set; }
        public string type { get; set; }
        public string woeid { get; set; }
        public string content { get; set; }
    }

    public class Locality1
    {
        public string type { get; set; }
        public string woeid { get; set; }
        public string content { get; set; }
    }

    public class Postal
    {
        public string type { get; set; }
        public string woeid { get; set; }
        public string content { get; set; }
    }

    public class Centroid
    {
        public string latitude { get; set; }
        public string longitude { get; set; }
    }

    public class SouthWest
    {
        public string latitude { get; set; }
        public string longitude { get; set; }
    }

    public class NorthEast
    {
        public string latitude { get; set; }
        public string longitude { get; set; }
    }

    public class BoundingBox
    {
        public SouthWest southWest { get; set; }
        public NorthEast northEast { get; set; }
    }

    public class Timezone
    {
        public string type { get; set; }
        public string woeid { get; set; }
        public string content { get; set; }
    }

    public class Place
    {
        public string lang { get; set; }
        public string uri { get; set; }
        public string woeid { get; set; }
        public PlaceTypeName placeTypeName { get; set; }
        public string name { get; set; }
        public Country country { get; set; }
        public Admin1 admin1 { get; set; }
        public Admin2 admin2 { get; set; }
        public Admin3 admin3 { get; set; }
        public Locality1 locality1 { get; set; }
        public object locality2 { get; set; }
        public Postal postal { get; set; }
        public Centroid centroid { get; set; }
        public BoundingBox boundingBox { get; set; }
        public string areaRank { get; set; }
        public string popRank { get; set; }
        public Timezone timezone { get; set; }
    }

    public class UniqueGeoPlaceResults
    {
        public Place place { get; set; }
    }

    public class UniqueGeoPlaceQuery
    {
        public int count { get; set; }
        public string created { get; set; }
        public string lang { get; set; }
        public UniqueGeoPlaceResults results { get; set; }
    }

    public class UniqueGeoPlace
    {
        public UniqueGeoPlaceQuery query { get; set; }
    }
}
