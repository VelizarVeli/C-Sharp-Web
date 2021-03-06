﻿namespace Eventures.WebApp.Controllers
{
    using System.Diagnostics;
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels;

    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public HomeController(ApplicationDbContext context) : base(context)
        {
        }
    }
}