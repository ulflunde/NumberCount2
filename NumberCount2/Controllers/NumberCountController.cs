using System;
// using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using NumberCount2.Model;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NumberCount2.Controllers
{
    public class NumberCountController : Controller
    {
        public string upto { get; set; }

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
            string message = "This is the default action method.\n"
                + "It is also the action method you get when you add \"NumberCount\" or \"NumberCount/DefaultAction\" to the URL.\n"
                + "Try also \"FutureAction\"!";
            return message;
        }
        public IActionResult Result()
        {
            HandleUserInteraction();
            return View();
        }

        private void HandleUserInteraction()
        {
            short lowerLimit, upperLimit;
            string u2 = "";
            NumberSeries numbers = null;
            HttpRequest uri = HttpContext.Request;
            QueryString query = uri.QueryString;
            var queryDictionary = QueryHelpers.ParseQuery(query.ToString());  // System.Web cannot be used in .NET Core. Had to rewrite using Microsoft.AspNetCore.WebUtilities.

            ViewData["success"] = "false";
            if (queryDictionary.ContainsKey("upto"))
            {
                u2 = queryDictionary["upto"];
                ViewData["UpperLimit"] = u2;
            }

            lowerLimit = 1;
            if (Int16.TryParse(u2, out upperLimit))
            {
                upperLimit = Int16.Parse(u2);
                if (upperLimit >= lowerLimit)
                {
                    numbers = new NumberSeries(upperLimit);
                    ViewData["1"] = numbers.Count(1);
                    ViewData["2"] = numbers.Count(2);
                    ViewData["3"] = numbers.Count(3);
                    ViewData["4"] = numbers.Count(4);
                    ViewData["5"] = numbers.Count(5);
                    ViewData["6"] = numbers.Count(6);
                    ViewData["7"] = numbers.Count(7);
                    ViewData["8"] = numbers.Count(8);
                    ViewData["9"] = numbers.Count(9);
                    ViewData["0"] = numbers.Count(0);
                    ViewData["success"] = "true";
                }
            }

            return;
        }
    }
}
