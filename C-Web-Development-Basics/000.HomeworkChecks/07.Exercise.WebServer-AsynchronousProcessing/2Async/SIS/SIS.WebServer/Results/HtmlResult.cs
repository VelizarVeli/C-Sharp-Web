﻿using System.Net;
using System.Text;
using SIS.Http.Headers;
using SIS.Http.Responses;

namespace SIS.WebServer.Results
{
    public class HtmlResult : HttpResponse
    {
        public HtmlResult(string content, HttpStatusCode statusCode)
            : base(statusCode)
        {
            this.Headers.Add(new HttpHeader("Content.Type", "text/html"));
            this.Content = Encoding.UTF8.GetBytes(content);
        }
    }
}