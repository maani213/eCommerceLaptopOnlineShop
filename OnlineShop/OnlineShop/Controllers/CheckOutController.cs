using Online_Shop.Application.Business_Layer;
using Online_Shop.Application.DataAccessLayer;
using Online_Shop.Application.Entities;
using OnlineShop.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    [Authorize]
    public class CheckOutController : Controller
    {
        ShopDAL Data = new ShopDAL();
        BusinessLayer bl = new BusinessLayer();
        const string PromoCode = "Free";
        //
        // GET: /CheckOut/

        public ActionResult AddressAndpayment()
        {
            var cart = ShoppingCart_BusinessLayer.GetCart(this.HttpContext);
            if (cart.GetCount() == 0)
            {
                return View("EmptyCart"); //View("Please add at least 1 Product in Cart....");
            }
            return View();
        }

        [HttpPost]
        [UserFilter]
        public ActionResult AddressAndPayment(FormCollection values)
        {
            Order Order = new Order();
            TryUpdateModel(Order);
            //try
            //{
            //if (string.Equals(values["PromoCode"], PromoCode, StringComparison.OrdinalIgnoreCase))
            if (values["PromoCode"] == PromoCode)
            {
                return View(Order);
            }
            else
            {
                Order.UserName = User.Identity.Name;
                Order.OrderDate = DateTime.Now;
                Data.Order.Add(Order);
                Data.SaveChanges();
                ShoppingCart_BusinessLayer cart = ShoppingCart_BusinessLayer.GetCart(this.HttpContext);
                Notifications n = new Notifications()
                {

                    category = "Order",
                    Description = Order.UserName + "placed a new Order. PLEASE REVIEW",
                    time = DateTime.Now
                };
                bl.PostNotification(n);
                cart.CreatOrder(Order);
                return RedirectToAction("Complete", new { id = Order.OrderId });
            }
        }
        //    //catch
        //    //{
        //    //    return View(Order);
        //    //}
        //}

        public ActionResult Complete(int id)
        {
            bool isValid = Data.Order.Any(o => o.OrderId == id && o.UserName == User.Identity.Name);
            if (isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }


    }
}
