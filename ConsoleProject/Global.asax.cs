using ConsoleProject.Controllers;
using ConsoleProject.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace ConsoleProject
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        private DateTime starttime;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ControllerBuilder.Current.SetControllerFactory(new DefaultControllerFactory());
            log4net.Config.XmlConfigurator.Configure();

            BeginRequest += new EventHandler(application_BeginRequest);


            EndRequest += new EventHandler(application_EndRequest);
        }


        private void application_BeginRequest(object sender, EventArgs e)
        {
            //object sender是BeginRequest传递过来的对象
            //里面存储的就是HttpApplication实例
            //HttpApplication实例里包含HttpContext属性
            starttime = DateTime.Now;
        }

        private void application_EndRequest(object sender, EventArgs e)
        {
            DateTime endtime = DateTime.Now;
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            var ms = (endtime - starttime).Milliseconds;
            context.Response.Headers.Add("times", string.Format("{0}ms", ms.ToString()));
        }


    }
}