﻿using SIS.HTTP.Responses;

namespace ChushkaWebApp.Controllers
{
    public class HomeController : BaseController
    {
        public IHttpResponse Index()
        {
            return this.View();
        }
    }
}
