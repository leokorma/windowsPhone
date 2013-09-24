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

namespace TuubiWebApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        /**
         * Handler function when signIn button is clicked 
         */
        private void signInButton_Click(object sender, RoutedEventArgs e)
        {
            hideMessages();

            if (!isValidUsername() || !isValidPassword())
            {
                errorMessage.Visibility = Visibility.Visible;
                return;
            }
            successMessage.Visibility = Visibility.Visible;
        }

        /**
         * Helper function for hiding error/success messages
         */
        private void hideMessages()
        {
            successMessage.Visibility = Visibility.Collapsed;
            errorMessage.Visibility = Visibility.Collapsed;
        }

        /**
         * Validation method for Password
         */
        private bool isValidPassword()
        {
            return !String.IsNullOrEmpty(passwordInput.Text);
        }

        /**
         * Validation method for Username
         */
        private bool isValidUsername()
        {
            return !String.IsNullOrEmpty(usernameInput.Text);
        }

        /**
         * Handler function when private radio button is checked
         */
        private void privateRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (privateRadioButtonAlert != null)
            {
                privateRadioButtonAlert.Visibility = Visibility.Visible;
            }
        }

        /**
        * Handler function when public radio button is checked
        */
        private void publicRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (privateRadioButtonAlert != null)
            {
                privateRadioButtonAlert.Visibility = Visibility.Collapsed;
            }
        }

        /**
        * Handler function when light version checkbox is checked
        */
        private void lightVersionCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            if (lightVersionCheckBoxAlert != null)
            {
                lightVersionCheckBoxAlert.Visibility = Visibility.Visible;
            }
        }

        /**
        * Handler function when light version checkbox is UNchecked
        */
        private void lightVersionCheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (lightVersionCheckBoxAlert != null)
            {
                lightVersionCheckBoxAlert.Visibility = Visibility.Collapsed;
            }
        }

        /**
        * Handler function when "SHOW security explanation" trigger checkbox is tapped
        */
        private void securityShowExplanationTrigger_Tap(object sender, GestureEventArgs e)
        {
            publicRadioButtonHelp.Visibility = Visibility.Visible;
            privateRadioButtonHelp.Visibility = Visibility.Visible;
            securityShowExplanationTrigger.Visibility = Visibility.Collapsed;
            securityHideExplanationTrigger.Visibility = Visibility.Visible;
        }

        /**
        * Handler function when "HIDE security explanation" trigger checkbox is tapped
        */
        private void securityHideExplanationTrigger_Tap(object sender, GestureEventArgs e)
        {
            publicRadioButtonHelp.Visibility = Visibility.Collapsed;
            privateRadioButtonHelp.Visibility = Visibility.Collapsed;
            securityShowExplanationTrigger.Visibility = Visibility.Visible;
            securityHideExplanationTrigger.Visibility = Visibility.Collapsed;
        }
    }
}