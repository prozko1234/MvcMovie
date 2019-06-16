using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{        /*! \brief HomeController class for first page
         *         There are actions for returning info for user
         */

    public class HomeController : Controller
    {
        public string message1 = "Your application description page."; /*!< \param - string message added for testing */

        //! An action - "Index".
        /*! More "Index" action description: 
         \return returns "Index" view.
             */
        public IActionResult Index()
        {
            return View();
        }

        //! An action - "About".
        /*! More "About" action description: 
         \return returns "Index" view with message in ViewData.
             */
        public IActionResult About()
        {
            ViewData["Message"] = message1;

            return View();
        }
        //! An action - "Contact".
        /*! More "Contact" action description: 
         \return return "Contact" view with message in ViewData.
             */
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        //! An action Error.
        /*! More action description: 
         \return return automatically when generated View with error.
             */
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
