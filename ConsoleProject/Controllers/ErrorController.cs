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
            Response.StatusCode = 404;
            return View("404");
        }

        public ActionResult Http500()
        {
            Response.StatusCode = 500;
            return View("500");
        }

    }
}
