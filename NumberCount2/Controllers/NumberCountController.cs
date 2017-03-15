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
            NumberSeries numbers = null;

            // System.Web cannot be used in .NET Core. Rewriting using Microsoft.AspNetCore.WebUtilities.
            HttpRequest uri = HttpContext.Request;
            QueryString query = uri.QueryString;
            var queryDictionary = QueryHelpers.ParseQuery(query.ToString());
            if (queryDictionary.ContainsKey("upto"))
            {
                string u2 = queryDictionary["upto"];
                // UNFINISHED
            }

            return;
        }
    }
}
