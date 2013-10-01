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
using ParseHelloWorld.model;
using RestSharp;

namespace ParseHelloWorld.util
{
    public class ParseUtils
    {
        private static readonly string PARSE_URL = "https://api.parse.com/1/";
        public static readonly string PARSE_CLASSES_URL = PARSE_URL + "classes/";

        private static readonly string APP_ID = "woFwXYQbEZwMNS4FBfKw2lSGZW3zuqidhRfeTILN";
        private static readonly string REST_API_KEY = "Xg6ABGH4VOsGkQynrmL7oDeDSK2Asi5V0mfNuhIz";

        public void getJSON(string uri, Action<string> callback)
        {
            RestClient client = new RestClient(uri);

            RestRequest request = new RestRequest(Method.GET);
            request.RequestFormat = DataFormat.Json;

            // easily add HTTP Headers
            request.AddHeader("X-Parse-Application-Id", ParseUtils.APP_ID);
            request.AddHeader("X-Parse-REST-API-Key", ParseUtils.REST_API_KEY);

            // execute the request
            client.ExecuteAsync(request, response =>
            {
                callback(response.Content);
            });
        }

        public void postJSON(string uri, Action<string> callback, object o)
        {
            RestClient client = new RestClient(uri);

            RestRequest request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(o); // uses JsonSerializer

            // easily add HTTP Headers
            request.AddHeader("X-Parse-Application-Id", ParseUtils.APP_ID);
            request.AddHeader("X-Parse-REST-API-Key", ParseUtils.REST_API_KEY);

            // execute the request
            client.ExecuteAsync(request, response =>
            {
                callback(response.Content);
            });
        }
    }
}
