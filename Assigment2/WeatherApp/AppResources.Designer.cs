﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1008
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WeatherApp {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class AppResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal AppResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("WeatherApp.AppResources", typeof(AppResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Assigment.
        /// </summary>
        public static string ApplicationTitle {
            get {
                return ResourceManager.GetString("ApplicationTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cities.
        /// </summary>
        public static string cities {
            get {
                return ResourceManager.GetString("cities", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to City Code.
        /// </summary>
        public static string cityCodeRadioButton {
            get {
                return ResourceManager.GetString("cityCodeRadioButton", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to City Name.
        /// </summary>
        public static string cityNameRadioButton {
            get {
                return ResourceManager.GetString("cityNameRadioButton", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There was an error when searching for results.
        /// </summary>
        public static string errorResultsMessage {
            get {
                return ResourceManager.GetString("errorResultsMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An error occurred when searching for weather. Please press back button and try again..
        /// </summary>
        public static string errorWoeidMessage {
            get {
                return ResourceManager.GetString("errorWoeidMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No Cities Found.
        /// </summary>
        public static string noCitiesFoundMessage {
            get {
                return ResourceManager.GetString("noCitiesFoundMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Now.
        /// </summary>
        public static string now {
            get {
                return ResourceManager.GetString("now", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No weather found.
        /// </summary>
        public static string noWeatherMessage {
            get {
                return ResourceManager.GetString("noWeatherMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to weather app.
        /// </summary>
        public static string PageTitle {
            get {
                return ResourceManager.GetString("PageTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please select which type of search you prefer.
        /// </summary>
        public static string radioButtonTitle {
            get {
                return ResourceManager.GetString("radioButtonTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Results.
        /// </summary>
        public static string resultsTitle {
            get {
                return ResourceManager.GetString("resultsTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Text cannot be empty..
        /// </summary>
        public static string searchBlankMessage {
            get {
                return ResourceManager.GetString("searchBlankMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Search.
        /// </summary>
        public static string searchButton {
            get {
                return ResourceManager.GetString("searchButton", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please write here your search.
        /// </summary>
        public static string searchTitle {
            get {
                return ResourceManager.GetString("searchTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Select one city to see the weather.
        /// </summary>
        public static string selectResultsMessage {
            get {
                return ResourceManager.GetString("selectResultsMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Woeid must be a positive number.
        /// </summary>
        public static string wrongWoeidMessage {
            get {
                return ResourceManager.GetString("wrongWoeidMessage", resourceCulture);
            }
        }
    }
}
