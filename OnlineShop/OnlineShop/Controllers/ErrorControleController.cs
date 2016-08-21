using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class ErrorControleController : Controller
    {
        //
        // GET: /ErrorControle/
        public ActionResult Index()
        {
            Exception e = new Exception("Invalid Controller or/and Action Name");
            HandleErrorInfo eInfo = new HandleErrorInfo(e, "Unknown", "Unknown");
            return View("Error", eInfo);
        }

        //public ActionResult custom()
        //{
        //    Exception e=new Exception();
        //    HandleErrorInfo eInfo = new HandleErrorInfo(e, "Unknown", "Unknown");
        //    return View("Error", eInfo);
        //}
	}
}