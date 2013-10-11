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
using WeatherApp.models;
using Newtonsoft.Json;

namespace WeatherApp.View
{
    public partial class ResultsPage : PhoneApplicationPage
    {
        private ResultsViewModel vm;

        // Constructor
        public ResultsPage()
        {
            InitializeComponent();
            vm = new ResultsViewModel();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            hideMessages();

            string regex = "";
            NavigationContext.QueryString.TryGetValue("regex", out regex);

            string isCityName = "";
            NavigationContext.QueryString.TryGetValue("isCityName", out isCityName);

            if (String.IsNullOrWhiteSpace(regex) || string.IsNullOrWhiteSpace(isCityName))
            {
                errorResultsMessage.Visibility = Visibility.Visible;
                ResultsControlOnPage.DataContext = new List<Place>();
                return;
            }

            try
            {
                vm.searchResults(regex, isCityName);
                //ResultsControlOnPage.DataContext = vm.Places;
            }
            catch (ErrorResultsException)
            {
                errorResultsMessage.Visibility = Visibility.Visible;
            }
            catch (NoResultsException)
            {
                noResultsMessage.Visibility = Visibility.Visible;
            }
        }

        /**
         * Helper function for hiding messages
         */
        private void hideMessages()
        {
            errorResultsMessage.Visibility = Visibility.Collapsed;
            noResultsMessage.Visibility = Visibility.Collapsed;
        }
    }
}