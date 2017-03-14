using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NumberCount2.Controllers
{
    public class NumberCountController : Controller
    {
        //
        // GET: /NumberCount/
        // This is an HTTP GET method that is invoked by appending "/NumberCount/" to the base URL.
        public IActionResult Index()
        {
            return View();
        }

        //
        // GET: /NumberCount/DefaultAction/
        // This is an HTTP GET method that is invoked by appending "/NumberCount/DefaultAction" to the base URL.
        public string DefaultAction()
        {
            return "This is the default action method if no MVC is used. If MVC is used, this is the action method you get when you add \"NumberCount\" to the URL.";
        }

    }
}
