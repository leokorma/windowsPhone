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

namespace WeatherApp.Model
{
    public class City
    {
        public string name { get; set; }
        public string woeid { get; set; }
        public string country { get; set; }

        private string _fullName;
        public string fullName
        {
            get { return name + ((country != null) ? ", " + country : ""); }
            set { _fullName = value; }
        }
    }
}
