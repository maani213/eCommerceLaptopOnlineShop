using Online_Shop.Application.DataAccessLayer;
using Online_Shop.Application.Business_Layer;
using Online_Shop.Application.Entities;
using OnlineShop.Filters;
//using OnlineShop.Models;
//using OnlineShop.Models.User;
using OnlineShop.Models.UserManagment;
using OnlineShop.ViewModels.User;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineShop.Controllers
{
   // [UserFilter]
    public class UsersController : Controller
    {
        BusinessLayer bl = new BusinessLayer();
        
        //
        // GET: /Users/
        public ActionResult Index()
        {
            return View();
        }
       
        [AllowAnonymous]
        public ActionResult Register()
        {
            string chk = Convert.ToString(Session["User"]);
            if (chk != "")
            {
                return RedirectToAction("Index", "Product");
            }
            return View("Register");
        }
        //[Authorize]
         [AllowAnonymous]
        [HttpPost]
        public ActionResult RegisterUser(UserDetail ud)
        {
            int counter = 0;
            if (ModelState.IsValid)
            {
                if (bl.CheckUser(ud))
                {

                    ModelState.AddModelError("UserId", "Username is used by another user");
                }
                else
                {
                    foreach (string fn in Request.Files)
                    {
                        HttpPostedFileBase postedFile = Request.Files[fn];
                        if (Request.Files[fn] != null)
                        {
                            if (postedFile != null && postedFile.ContentLength != 0)
                            {
                                string fName = DateTime.Now.Ticks + "_" + ++counter + postedFile.FileName.Substring(postedFile.FileName.LastIndexOf("."));
                                string WebUrl = "~/images/UserImg/" + fName;
                                string physicalPath = Request.MapPath(WebUrl);
                                postedFile.SaveAs(physicalPath);
                                ud.imgUrl = WebUrl;
                            }
                        }
                    }
                    if (ud.imgUrl == null)
                    {
                        ModelState.AddModelError("imgUrl", "Please Upload your Image");
                    }
                    //bl.SendMail(ud.Email);
                    bl.AddUser(ud);
                    Notifications n = new Notifications()
                    {

                        category = "User",
                        Description = ud.UserId + " is registered account as a member",
                        time = DateTime.Now
                    };
                    bl.PostNotification(n);
                    return RedirectToAction("Login", "Authentication");
                }
                return View("Register",ud);
            }
            else
            {
                return View("Register",ud);
            }

        }

      
        [UserFilter]
        public ActionResult UserOrders(int id)
        {
            List<Order> orders = bl.GetOneOrder(id);
            List<UserOrderViewModel> usrO = new List<UserOrderViewModel>();
           
            foreach (Order ord in orders)
            {

                UserOrderViewModel usrV = new UserOrderViewModel(){
                OrderId=ord.OrderId,
                UserName=ord.UserName,
                Name=ord.FirstName+" "+ord.LastName,
                Address=ord.Address +" "+ ord.City + " " +ord.Country,
                Email=ord.Email,
                OrderDate=ord.OrderDate,
                Phone=ord.Phone,
                Total=ord.Total
                };
                
                usrO.Add(usrV);
 
            }
            return View(usrO);

        }



        
        [AdminFilters]
        public ActionResult AllUsers()
        {
            
            List<UserDetail> users= bl.GetAllUsers();
            return View("AllUsers",users);
        }
        [HttpGet]
        [UserFilter]
        public ActionResult Edit(int? id)
        {
            UserDetail usr=bl.GetUser(id);
            return View("EditUser",usr);
        }

        [HttpPost]
        [UserFilter]
        public ActionResult EditUser(UserDetail u)
        {
            if (ModelState.IsValid)
            {
                bl.EditUser(u);
                return RedirectToAction("UserAccount", "Authentication", bl.GetUser(u.Id));
            }
            else
            {
                return RedirectToAction("Edit", "Users",u);
            }
        }

        [UserFilter]
        public ActionResult DeleteAccount(int id)
        {
            bl.DeleteAccount(id);
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Login", "Authentication");
         }
	}
}