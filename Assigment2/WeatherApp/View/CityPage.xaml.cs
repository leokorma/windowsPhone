using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using WeatherApp.ViewModel;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;
using WeatherApp.Model;
using WeatherApp.Model.json;
using System.Windows.Resources;
using System.IO;

namespace WeatherApp.View
{
    public partial class CityPage : PhoneApplicationPage
    {
        // Constructor
        public CityPage()
        {
            InitializeComponent();
        }

        /**
         * Method called when entering the page.
         */
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // Retrieves the parameters sent by the previous page
            string json = "";
            NavigationContext.QueryString.TryGetValue("json", out json);

            this.CityList.ItemsSource = JsonConvert.DeserializeObject<List<City>>(json);
        }
    }
}