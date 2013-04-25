﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using unirest_net.http;

namespace unirest_net.request
{
    public abstract class BaseRequest
    {
        public Uri URL { get; protected set; }

        public HttpMethod HttpMethod { get; protected set; }

        public Dictionary<String, String> Headers { get; protected set; }

        // Should add overload that takes URL object
        protected BaseRequest(HttpMethod method, string url)
        {
            Uri locurl;

            if (Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out locurl))
            {
                if (
                    !(locurl.IsAbsoluteUri &&
                      (locurl.Scheme == Uri.UriSchemeHttp || locurl.Scheme == Uri.UriSchemeHttps)) ||
                    !locurl.IsAbsoluteUri)
                {
                    throw new ArgumentException("The url passed to the HttpMethod constructor is not a valid HTTP/S URL");
                }
            }
            else
            {
                throw new ArgumentException("The url passed to the HttpMethod constructor is not a valid HTTP/S URL");
            }

            URL = locurl;
            HttpMethod = method;
            Headers = new Dictionary<string, string>();
        }

        public BaseRequest header(string name, string value)
        {
            Headers.Add(name, value);
            return this;
        }

        public HttpResponse<String> asString()
        {
            return HttpClientHelper.Request<String>(this);
        }

        public Task<HttpResponse<String>> asStringAsync()
        {
            return HttpClientHelper.RequestAsync<String>(this);
        }

        public HttpResponse<Stream> asBinary()
        {
            return HttpClientHelper.Request<Stream>(this);
        }

        public Task<HttpResponse<Stream>> asBinaryAsync()
        {
            return HttpClientHelper.RequestAsync<Stream>(this);
        }

        public HttpResponse<T> asJson<T>()
        {
            return HttpClientHelper.Request<T>(this);
        }

        public Task<HttpResponse<T>> asJsonAsync<T>()
        {
            return HttpClientHelper.RequestAsync<T>(this);
        }
    }
}
