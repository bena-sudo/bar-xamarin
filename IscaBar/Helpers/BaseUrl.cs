﻿namespace IscaBar.Helpers
{
    public class BaseUrl
    {
        public static string UrlApi { get; private set; }

        static BaseUrl()
        {
            UrlApi = "http://192.168.216.220:8069/";
        }
    }
}
