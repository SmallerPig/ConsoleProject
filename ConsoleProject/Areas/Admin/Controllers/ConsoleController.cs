using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConsoleProject.Models;

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
            HttpCookie cookie = Request.Cookies["admin"];
            if (cookie == null) //TODO
            {
                return View();
            }
            string username = cookie["username"];
            string password = Server.UrlDecode(cookie["password"]);
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return View();
            }


            WXSSKDbContext dbContext = new WXSSKDbContext();
            if (dbContext.Admin.Any(item => item.UserName == username && item.Password == password && item.Status != 0))
            {
                return View("Main");
            }
            return View();
        }


        public ActionResult Main()
        {
            HttpCookie cookie = Request.Cookies["admin"];
            if (cookie == null) 
            {
                return RedirectToAction("Login");
            }
            string username = cookie["username"];
            string password = Server.UrlDecode(cookie["password"]);
            WXSSKDbContext dbContext = new WXSSKDbContext();
            if (dbContext.Admin.Any(item=>item.UserName == username && item.Password == password && item.Status!=0))
            {
                return View();
            }
            return View();
            cookie.Expires = DateTime.Now;
            Response.Cookies.Add(cookie);

            return Content("Data error!");

        }

        [HttpPost]
        public JsonResult Login(string username, string password)
        {
            password = WXSSK.Common.ASE.EncryptCode(password);

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return null;
            }
            LoginLog log = new LoginLog()
            {
                IpAddress = WXSSK.Common.IPHelp.ClientIP,
                UserName = username,
                CreateTime = DateTime.Now,
            };

            WXSSKDbContext dbContext = new WXSSKDbContext();
            if (dbContext.Admin.Any(item=>item.UserName == username && item.Password == password && item.Status !=0))
            {
                HttpCookie cookie = new HttpCookie("admin");
                cookie["username"] = username;
                cookie["password"] = Server.UrlEncode(WXSSK.Common.ASE.EncryptCode(password));
                Response.Cookies.Add(cookie);

                log.Status = 1;//登录成功
                dbContext.LoginLog.Add(log);
                dbContext.SaveChanges();

                return Json("Success");
            }

            log.Status = 0;//登录失败
            dbContext.LoginLog.Add(log);
            dbContext.SaveChanges();
            return Json("Error");
        }

        public ActionResult Exit()
        {
            HttpCookie cookie = Request.Cookies["admin"];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now;
                Response.Cookies.Add(cookie);
            }
            return RedirectToAction("Login");
        }


    }
}
