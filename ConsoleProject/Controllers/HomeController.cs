using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ConsoleProject.Models;

namespace ConsoleProject.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index(int id = 0)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TestModel model)
        {
            WXSSKDbContext db = new WXSSKDbContext();

            db.TestModel.Add(model);
            db.SaveChanges();
            return Json(model);
        }


        [OutputCache(Duration = int.MaxValue, VaryByParam = "id")]
        public ActionResult Test(int id)
        {
            return Content(DateTime.Now.ToString());
        }

    }
}
