using FDMCBook.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using FDMCBook.Models;

namespace FDMCBook.Controllers
{
    public class HomeController : Controller
    {
        private DataContext context;
        public HomeController(DataContext ctx) => context = ctx;

        public IActionResult Index() => View(context.Cats);

        public IActionResult CatPage() => View(context.Cats.Where(i => i.Id == 2));

        public IActionResult AddCat() => View();
        [HttpPost]
        public IActionResult AddCat(Cat cat)
        {
            context.Cats.Add(cat);
            context.SaveChanges();
            return RedirectToAction(nameof(Index),
                new {cat.Name});
        }
        public IActionResult AllCats(Cat AllCats) => View(AllCats);

        public IActionResult ListResponses() =>
            View(context.Cats.OrderByDescending(r => r.Name));


    }
}