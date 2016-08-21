using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace OnlineShop.Filters
{
    public class UserFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
           // string chk = Convert.ToString(filterContext.HttpContext.Session["chk1"]);
            string chk=Convert.ToString(filterContext.HttpContext.Session["User"]);

            if (chk != "User")
            {
                filterContext.Result = new ContentResult()
                {
                    Content = "Unauthorized to access specified resource. you are not register user"
                };

            }
        }
    }
}
