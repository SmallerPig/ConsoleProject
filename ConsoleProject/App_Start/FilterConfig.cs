using System.Web;
using System.Web.Mvc;
using ConsoleProject.Filter;

namespace ConsoleProject
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new LogExceptionFileAttribute());
        }
    }
}