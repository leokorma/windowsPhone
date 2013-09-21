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

        private void signInButton_Click(object sender, RoutedEventArgs e)
        {
            hideMessages();

            if (!isValidUsername() || !isValidPassword()){
                errorMessage.Visibility = Visibility.Visible;
                return;
            }      
            successMessage.Visibility = Visibility.Visible;
        }

        private void hideMessages()
        {
            successMessage.Visibility = Visibility.Collapsed;
            errorMessage.Visibility = Visibility.Collapsed;
        }        

        private bool isValidPassword()
        {
            return !String.IsNullOrEmpty(passwordInput.Text);
        }

        private bool isValidUsername()
        {
            return !String.IsNullOrEmpty(usernameInput.Text);
        }

        private void privateRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (privateRadioButtonAlert != null)
            {
                privateRadioButtonAlert.Visibility = Visibility.Visible;
            }
        }

        private void publicRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (privateRadioButtonAlert != null)
            {
                privateRadioButtonAlert.Visibility = Visibility.Collapsed;
            }
        }

        private void lightVersionCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            if (lightVersionCheckBoxAlert != null)
            {
                lightVersionCheckBoxAlert.Visibility = Visibility.Visible;
            }
        }

        private void lightVersionCheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (lightVersionCheckBoxAlert != null)
            {
                lightVersionCheckBoxAlert.Visibility = Visibility.Collapsed;
            }
        }

        private void securityShowExplanationTrigger_Tap(object sender, GestureEventArgs e)
        {
            publicRadioButtonHelp.Visibility = Visibility.Visible;
            privateRadioButtonHelp.Visibility = Visibility.Visible;
            securityShowExplanationTrigger.Visibility = Visibility.Collapsed;
            securityHideExplanationTrigger.Visibility = Visibility.Visible;
        }

        private void securityHideExplanationTrigger_Tap(object sender, GestureEventArgs e)
        {
            publicRadioButtonHelp.Visibility = Visibility.Collapsed;
            privateRadioButtonHelp.Visibility = Visibility.Collapsed;
            securityShowExplanationTrigger.Visibility = Visibility.Visible;
            securityHideExplanationTrigger.Visibility = Visibility.Collapsed;
        }
    }
}