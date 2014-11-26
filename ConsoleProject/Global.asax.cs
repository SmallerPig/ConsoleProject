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
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ControllerBuilder.Current.SetControllerFactory(new UnityControllerFactory());

        }

protected void Application_Error(object sender, EventArgs e)
{
    Exception exception = Server.GetLastError();

    Response.Clear();

    HttpException httpException = exception as HttpException;

    RouteData routeData = new RouteData();
    routeData.Values.Add("controller", "Error");

    if (httpException == null)
    {
        routeData.Values.Add("action", "Index");
    }
    else //It's an Http Exception, Let's handle it.
    {
        switch (httpException.GetHttpCode())
        {
            case 404:
                // Page not found.
                routeData.Values.Add("action", "Http404");
                break;
            case 500:
                // Server error.
                routeData.Values.Add("action", "Http500");
                break;

            default:
                routeData.Values.Add("action", "General");
                break;
        }
    }

    // Pass exception details to the target error View.
    routeData.Values.Add("error", exception);

    // Clear the error on server.
    Server.ClearError();

    // Avoid IIS7 getting in the middle
    Response.TrySkipIisCustomErrors = true;

    // Call target Controller and pass the routeData.
    IController errorController = new ErrorController();
    errorController.Execute(new RequestContext(
            new HttpContextWrapper(Context), routeData));
}
    }
}