﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;

using unirest_net.request;

namespace unirest_net.http
{
    public class Unirest
    {
        // Should add overload that takes URL object
        public static HttpRequest get(string url)
        {
            return new HttpRequest(HttpMethod.Get, url);
        }

        public static HttpRequestWithBody Post(string url)
        {
            return new HttpRequestWithBody(HttpMethod.Post, url);
        }

        public static HttpRequest delete(string url)
        {
            return new HttpRequest(HttpMethod.Delete, url);
        }

        public static HttpRequestWithBody patch(string url)
        {
            return new HttpRequestWithBody(new HttpMethod("PATCH"), url);
        }

        public static HttpRequestWithBody put(string url)
        {
            return new HttpRequestWithBody(HttpMethod.Put, url);
        }
    }
}