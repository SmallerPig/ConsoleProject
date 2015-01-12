using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;

namespace ConsoleProject.Extended
{
    public static class ExtendedHtmlHelper
    {

        public static MvcHtmlString EditModelProp(this HtmlHelper htmlHelper,string showname, string prop, string value ="" ,string tip = "",string type="text")
        {
            string result = "<div class='contentUnit'>" +
                                "<div class='title'>" + showname + "</div>" +
                                "<div class='content'>" +
                                    "<input type='" + type + "' class='inputText' name= '" + prop + "' value = '"+ value +"'/>" +
                                    "</div>" + (string.IsNullOrEmpty(tip)?"":"<div class='tip'>"+tip+"</div>") +
                            "</div>";

            return MvcHtmlString.Create(result);
        }
    }
}