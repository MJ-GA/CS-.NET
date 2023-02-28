using Microsoft.AspNetCore.Mvc;
using Lab3.Models;

namespace Lab3.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {

            return View();
        }
        public IActionResult SongForm() => View();

        [HttpPost]
        public IActionResult Sing(string bottles)
        {
            ViewBag.Bottles = Request.Form["Bottles"];

            return View(Sing);
        }

        public IActionResult CreatePerson() => View();

        [HttpPost]
        public IActionResult DisplayPerson(Person person)
        {
            return View(person);
        }
        public IActionResult Error()
        {
            return View();
        }

    }
}
