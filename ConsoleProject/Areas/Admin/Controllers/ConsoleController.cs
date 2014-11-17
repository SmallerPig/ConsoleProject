using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConsoleProject.Areas.Admin.Controllers
{
    public class ConsoleController : Controller
    {
        //public IUserService UserService { get; private set; }

        //public ConsoleController(IUserService userService)
        //{
        //    this.UserService = userService;
        //    //this.AddDisposableObject(userService);
        //}


        public ActionResult Login()
        {
            return View();
        }


        public ActionResult Main()
        {
            //if (Session["admin"] == null)
            //{
            //    Response.Redirect("/Admin/Console/Login");
            //}

            return View();
        }

        //[HttpPost]
        //public JsonResult Login(string username, string password)
        //{
        //    Models.User user = this.UserService.Login(username, password);
        //    if (user != null)
        //    {
        //        Session["username"] = user.UserName;
        //        Session["userid"] = user.Id;
        //        Session.Timeout = 2 * 60 * 60;
        //        return Json("Success");
        //    }
        //    else
        //    {
        //        return Json("Error");
        //    }
        //}

        public ActionResult Exit()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }


    }
}
