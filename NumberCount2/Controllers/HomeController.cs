using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NumberCount2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Message"] = "This is the Index page.";
            return View();
        }

        public IActionResult Om()
        {
            ViewData["Message"] = "This is the action method you get if you add \"Home/About\" to the URL.";  // This message never appears. Why?

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "This is the action method you get if you add \"Home/Contact\" to the URL. See what happens if you try \"Home/Om\"!";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
