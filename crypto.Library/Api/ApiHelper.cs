using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace crypto.Library.Api
{
    internal static class ApiHelper
    {
        private static HttpClient _apiClient;
        static ApiHelper()
        {
            InitializeClient();
        }
        
        public static HttpClient ApiClient
        {
            get { return _apiClient; }
        }

        private static void InitializeClient()
        {
            string apiBaseAddress = ConfigurationManager.AppSettings["api"];

            _apiClient = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip });
            _apiClient.BaseAddress = new Uri(apiBaseAddress);
            _apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _apiClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip");
            _apiClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)");
            
        }
    }
}
