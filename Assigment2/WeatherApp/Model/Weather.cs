﻿using System;
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

/**
 * Class that represents Json
 * Created using json2csharp.com
 * Modified for better easy access to certain data
 */
namespace WeatherApp.Model
{
    public class Url
    {
        public string __invalid_name__execution_start_time { get; set; }
        public string __invalid_name__execution_stop_time { get; set; }
        public string __invalid_name__execution_time { get; set; }
        public string content { get; set; }
    }

    public class Diagnostics
    {
        public string publiclyCallable { get; set; }
        public Url url { get; set; }
        public string __invalid_name__user_time { get; set; }
        public string __invalid_name__service_time { get; set; }
        public string __invalid_name__build_version { get; set; }
    }

    public class Location
    {
        public string city { get; set; }
        public string country { get; set; }
        public string region { get; set; }
    }

    public class Units
    {
        public string distance { get; set; }
        public string pressure { get; set; }
        public string speed { get; set; }
        public string temperature { get; set; }
    }

    public class Wind
    {
        public string chill { get; set; }
        public string direction { get; set; }
        public string speed { get; set; }
    }

    public class Atmosphere
    {
        public string humidity { get; set; }
        public string pressure { get; set; }
        public string rising { get; set; }
        public string visibility { get; set; }
    }

    public class Astronomy
    {
        public string sunrise { get; set; }
        public string sunset { get; set; }
    }

    public class Image
    {
        public string title { get; set; }
        public string width { get; set; }
        public string height { get; set; }
        public string link { get; set; }
        public string url { get; set; }
    }

    public class Condition
    {
        public string code { get; set; }
        public string date { get; set; }
        public string temp { get; set; }
        public string text { get; set; }
    }

    public class Forecast
    {
        public string code { get; set; }
        public string date { get; set; }
        public string day { get; set; }
        public string high { get; set; }
        public string low { get; set; }
        public string text { get; set; }
    }

    public class Guid
    {
        public string isPermaLink { get; set; }
        public string content { get; set; }
    }

    public class Item
    {
        public string title { get; set; }
        public string lat { get; set; }
        public string @long { get; set; }
        public string link { get; set; }
        public string pubDate { get; set; }
        public Condition condition { get; set; }
        public string description { get; set; }
        public List<Forecast> forecast { get; set; }
        public Guid guid { get; set; }
    }

    public class Channel
    {
        public string title { get; set; }
        public string link { get; set; }
        public string description { get; set; }
        public string language { get; set; }
        public string lastBuildDate { get; set; }
        public string ttl { get; set; }
        public Location location { get; set; }
        public Units units { get; set; }
        public Wind wind { get; set; }
        public Atmosphere atmosphere { get; set; }
        public Astronomy astronomy { get; set; }
        public Image image { get; set; }
        public Item item { get; set; }
    }

    public class Results
    {
        public Channel channel { get; set; }
    }

    public class Query
    {
        public int count { get; set; }
        public string created { get; set; }
        public string lang { get; set; }
        public Diagnostics diagnostics { get; set; }
        public Results results { get; set; }
    }

    public class Weather
    {
        public Query query { get; set; }

        private string _fullTemp;
        public string fullTemp
        {
            get { return this.query.results.channel.item.condition.temp + this.query.results.channel.units.temperature; }
            set { _fullTemp = value; }
        }
    }
}
