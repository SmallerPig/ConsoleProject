using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConsoleProject.Areas.Admin.Controllers
{
    public class DemoController : Controller
    {
        //
        // GET: /Admin/Demo/

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult List()
        {
            return View();
        }

        public ActionResult Test()
        {
            //string action = RouteData.Values["action"].ToString();

            return Json(RouteData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Test(string content)
        {
            string action = RouteData.Values["action"].ToString();

            return Json(RouteData);
        }


    }
}
