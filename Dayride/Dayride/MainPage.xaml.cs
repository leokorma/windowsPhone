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
using System.IO;
using ParseHelloWorld.model;
using System.IO.IsolatedStorage;
using ParseHelloWorld.util;

namespace ParseHelloWorld
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void create_Click(object sender, RoutedEventArgs e)
        {
            Person user = new Person();
            user.UserName = "javier";
            user.Password = "javier";
        }



        private void button1_Click(object sender, RoutedEventArgs e)
        {
            String uri = ParseUtils.PARSE_CLASSES_URL + Person.PARSE_CLASS_ID;
            new ParseUtils().getJSON(uri, new Action<string>(printJSON));
        }

        private void printJSON(string json)
        {
            Console.Write(json);
        }
    }
}