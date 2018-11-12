using FDMCRazor.Models;
using Microsoft.AspNetCore.Mvc;

namespace FDMCRazor.Controllers
{
    public class HomeController
    {
        private CatDbContext context;
       public HomeController(CatDbContext ctx) => context = ctx;
       public IActionResult Index() => View();
       //public IActionResult Respond() => View();
       //[HttpPost]
       //public IActionResult Respond(GuestResponse response)
       //{
       //    context.Responses.Add(response);
       //    context.SaveChanges();
       //    return RedirectToAction(nameof(Thanks),
       //        new { Name = response.Name, WillAttend = response.WillAttend });
       //}
       //public IActionResult Thanks(GuestResponse response) => View(response);
       //public IActionResult ListResponses() =>
       //    View(context.Responses.OrderByDescending(r => r.WillAttend));
    }
}
