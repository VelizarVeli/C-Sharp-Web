﻿namespace SIS.IRunesApp.Controllers
{
    using HTTP.Enums;
    using HTTP.Requests;
    using HTTP.Responses;
    using IRunesApp.Data;
    using IRunesApp.Extensions;
    using WebServer.Results;
    using System.Collections.Generic;
    using System.IO;

    public abstract class BaseController
    {
        protected BaseController()
        {
            this.Db = new IRunesDbContext();
        }

        protected IRunesDbContext Db { get; }

        protected IHttpResponse View(string viewName, IHttpRequest request, IDictionary<string, string> viewBag = null)
        {
            if (viewBag == null)
            {
                viewBag = new Dictionary<string, string>();
            }

            string allContent = this.GetViewContent(viewName, viewBag, request);
            return new HtmlResult(allContent, HttpResponseStatusCode.Ok);
        }

        protected IHttpResponse Redirect(string location)
        {
            return new RedirectResult(location);
        }

        protected IHttpResponse Error(string errorMessage, HttpResponseStatusCode statusCode, IHttpRequest request)
        {
            Dictionary<string, string> viewBag = new Dictionary<string, string>
            {
                {"Error", errorMessage}
            };
            string allContent = this.GetViewContent("Error", viewBag, request);

            return new HtmlResult(allContent, statusCode);
        }

        private string GetViewContent(string viewName,
            IDictionary<string, string> viewBag, IHttpRequest request)
        {
            var layoutContent = File.ReadAllText("Views/_Layout.html");
            var content = File.ReadAllText("Views/" + viewName + ".html");
            var allContent = layoutContent.Replace("@RenderBody()", content);

            allContent = allContent.Replace("@Model.Navigation", this.GetNavigation(request));

            foreach (var item in viewBag)
            {
                allContent = allContent.Replace("@Model." + item.Key, item.Value);
            }

            return allContent;
        }

        private string GetNavigation(IHttpRequest request)
        {
            string fileName = request.IsLoggedIn()
                ? "NavigationLoggedIn"
                : "NavigationLoggedOut";

            return File.ReadAllText("Views/Navigation/" + fileName + ".html");
        }
    }
}
