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
        /// <summary>
        /// GET: /NumberCount/
        /// This is an HTTP GET method that is invoked by appending "/NumberCount/" to the base URL.
        /// This method returns a View object. It uses a view template to generate an HTML response
        /// to the browser. Controller methods (also known as action methods) such as the Index method
        /// generally return an IActionResult (or a class derived from ActionResult), not primitive
        /// types like string.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        //
        // GET: /NumberCount/DefaultAction/
        // This is an HTTP GET method that is invoked by appending "/NumberCount/DefaultAction" to the base URL.
        public string DefaultAction()
        {
            return "This is the default action method.\nIt is also the action method you get when you add \"NumberCount\" to the URL.\nTry also \"FutureAction\"!";
        }

    }
}
