using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConsoleProject.Filter
{
    public class LogExceptionFileAttribute : HandleErrorAttribute
    {
        readonly log4net.ILog log = log4net.LogManager.GetLogger("WebLogger");
        public override void OnException(ExceptionContext filterContext){

            //处理错误消息，将其跳转到一个页面
            log.Error(filterContext.RequestContext.HttpContext.Request.Url);
            log.Error(filterContext.Exception.ToString());
            //log.Fatal("fatal信息", filterContext.Exception);
            base.OnException(filterContext);
        }

    }
}