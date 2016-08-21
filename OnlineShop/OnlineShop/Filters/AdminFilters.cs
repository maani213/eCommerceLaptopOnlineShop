using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineShop.Filters
{
    public class AdminFilters : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string chk = Convert.ToString(filterContext.HttpContext.Session["User"]);

            if (chk!="Admin" && chk!="admin")
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary{{"controller","product"},
                                             {"Action","Index"}}
                    );

            }
        }
    }
}
