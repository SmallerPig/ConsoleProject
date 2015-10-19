using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsoleProject.Extended
{
    public class TimeHttpModule : IHttpModule
    {
        private DateTime starttime;

        public void Init(HttpApplication application)//实现IHttpModules中的Init事件
        {
            //订阅两个事件
            application.BeginRequest += new EventHandler(application_BeginRequest);
            application.EndRequest += new EventHandler(application_EndRequest);
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

        //必须实现dispose接口
        public void Dispose() { }
    }

}