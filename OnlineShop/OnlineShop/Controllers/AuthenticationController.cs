using Online_Shop.Application.Business_Layer;
using Online_Shop.Application.DataAccessLayer;
using Online_Shop.Application.Entities;
using OnlineShop.Models;
using OnlineShop.Models.UserManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineShop.Controllers
{
    public class AuthenticationController : Controller
    {
        private string r;
        BusinessLayer bl = new BusinessLayer();
        ShopDAL Data = new ShopDAL();
      


        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            string chk = Convert.ToString(Session["User"]);
            if (chk != "")
            {
                return RedirectToAction("Index", "Product");
            }
            return View("Login");
        }


        [AllowAnonymous]
        public ActionResult DoLogin(LogInModel l)
        {
            Session["User"] = null;
            Session["chk1"] = null;
            if (l.UserId != null && l.Password != null)
            {
               
                UserDetail a = new UserDetail();
                a.UserId = l.UserId;
                a.Password = l.Password;
                r = bl.ValidateUser(a);

                if (r == a.UserId)
                {
                    if (a.UserId == "Admin" || a.UserId == "admin")
                    {
                        Session["User"] = a.UserId;
                        //Session["chk1"] = "User";
                        FormsAuthentication.SetAuthCookie(l.UserId, false);
                        string xc = Convert.ToString(Session["User"]);
                        //return Redirect(ControllerContext.HttpContext.Request.UrlReferrer.ToString());
                        
                        //bl.SendMail("abc@gmail.com");
                        return RedirectToAction("Index", "AdminPanel");
                    }
                    else
                    {
                        Session["User"] = a.UserId;
                        Session["chk1"] = "User";
                        FormsAuthentication.SetAuthCookie(l.UserId, false);
                        return RedirectToAction("Index", "Product");
                        //return Redirect(ControllerContext.HttpContext.Request.UrlReferrer.ToString());
                    }
                }

                else
                {
                    Session["User"] = "nonAuthenticatedAdminUser";
                    ModelState.AddModelError("CredentialError", "Invalid Username or Password");
                    return View("Login");
                }
            }
            else
            {
                ModelState.AddModelError("CredentialError", "Invalid Username or Password");
                return View("Login");
 
            }


        }

        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Login");
        }

        [ChildActionOnly]
        public ActionResult Name()
        {
            string chk = Convert.ToString(Session["User"]);
            messag a = new messag();
            if (User.Identity.IsAuthenticated)
            {
                a.username = User.Identity.Name +" "+ "|" + " " ;
                return PartialView("User", a);
            }
            else
            {
                return PartialView("LoginMessage");
            }          
        }

        [ChildActionOnly]
        public ActionResult UserLink()
        {
           
            if (User.Identity.IsAuthenticated)
            {
                string k= User.Identity.Name;
                ViewData["Name"] = k;
             }
            return PartialView();
        }
        public ActionResult UserAccount()
        {
            ViewBag.Url = "~/Authentication/UserAccount";
            if (User.Identity.IsAuthenticated)
            {
                string name = Convert.ToString(Session["User"]);
                UserDetail usr = Data.Users.SingleOrDefault(c => c.UserId == name);
                //var usr = (from u in Data.Users
                //                  where u.UserId == name
                //                  select u);
                                  //Data.Users.where(c => c.UserId == name);

                if (usr != null)
                {
                    return View("UserAccount", usr);
                }
                else
                    return RedirectToAction("Login", "Authentication");
            }
            else
                return RedirectToAction("Login","Authentication");
        }


        public ActionResult AddSubscriber(string email)
        {
            bl.AddSubscriber(email);
            return RedirectToAction("Index","Product");
        }

    }
}