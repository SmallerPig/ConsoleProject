using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Web.Routing;
using ConsoleProject.Areas.Admin.Models;
using ConsoleProject.Models;

namespace ConsoleProject.Areas.Admin.Controllers
{
    public abstract class BaseController<Tentity> : Controller where Tentity : new()
    {
        private String exceptionFileName = "exception.txt";

        protected int pageIndex = 1;
        protected int pageSize = 20;
        protected int count = 0;
        protected int pageCount = 0;

        public WXSSKDbContext DbContext = new WXSSKDbContext();


        protected override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext
           filterContext)
        {
            if (filterContext.HttpContext.Session["admin"] == null)
            {
                filterContext.HttpContext.Response.Redirect("/Admin/Console/Login");
            }
        }

        /// <summary>
        /// 页面Model获得函数 ----模板方法模式
        /// </summary>
        public virtual void GetList()
        { }



        /// <summary>
        /// 设定每个页面呈现数量
        /// </summary>
        /// <param name="size"></param>
        public void SetPageSize(int size)
        {
            this.pageSize = size;
        }



        /// <summary>
        /// 创建页面,不包含任何逻辑处理
        /// </summary>
        /// <returns></returns>
        public virtual ActionResult Create()
        {
            return View();
        }








        public ActionResult Error()
        {
            return View();
        }

        /// <summary>
        /// 初始化分页类,
        /// </summary>
        /// <param name="pager">具有action名称,总计条目数量以及当前页码的SmpPager类</param>
        /// <param name="routeValue">需要传递的额外的get参数
        ///     例如key=keyword,company=1等等!
        /// </param>
        public void InitPage(SmpPager pager, RouteValueDictionary routeValue = null)
        {

            routeValue = routeValue ?? new RouteValueDictionary();

            RouteValueDictionary firstPageRouteValue = new RouteValueDictionary(routeValue);
            RouteValueDictionary perPageRouteValue = new RouteValueDictionary(routeValue);
            RouteValueDictionary nextPageRouteValue = new RouteValueDictionary(routeValue);
            RouteValueDictionary lastPageRouteValue = new RouteValueDictionary(routeValue);

            pageCount = pager.GetPageCount(pageSize);
            if (pager.PageIndex >= pageCount && pageCount > 0)
            {
                pager.PageIndex = pageCount;
            }

            firstPageRouteValue["pageIndex"] = 1;


            perPageRouteValue["pageIndex"] = (pager.PageIndex - 1) < 1 ? 1 : (pager.PageIndex - 1);

            nextPageRouteValue["pageIndex"] = (pager.PageIndex + 1) > pageCount ? pageCount : (pager.PageIndex + 1);

            lastPageRouteValue["pageIndex"] = pageCount;


            string firstPage = Url.Action(RouteData.Values["action"].ToString(), firstPageRouteValue);
            string perPage = Url.Action(RouteData.Values["action"].ToString(), perPageRouteValue);
            string nextPage = Url.Action(RouteData.Values["action"].ToString(), nextPageRouteValue);
            string lastPage = Url.Action(RouteData.Values["action"].ToString(), lastPageRouteValue);//"/admin/" + "House" + "/" + "List" + "?pageIndex=" + pageCount;
            ViewData["firstPage"] = firstPage;
            ViewData["perPage"] = perPage;
            ViewData["nextPage"] = nextPage;
            ViewData["pageIndex"] = pager.PageIndex;
            ViewData["pageCount"] = pageCount;
            ViewData["lastPage"] = lastPage;
        }



    }
}