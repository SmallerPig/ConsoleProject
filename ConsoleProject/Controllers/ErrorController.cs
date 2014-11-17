using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConsoleProject.Controllers
{
    public class ErrorController : Controller
    {
        //
        // GET: /Error/

        public ActionResult Http404()
        {
            return View("404");
        }

        public ActionResult Http500()
        {
            return View("500");
        }

    }
}
