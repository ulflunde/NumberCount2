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
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "This is the action method you get if you add \"Home/About\" to the URL.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "This is the action method you get if you add \"Home/Contact\" to the URL.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
