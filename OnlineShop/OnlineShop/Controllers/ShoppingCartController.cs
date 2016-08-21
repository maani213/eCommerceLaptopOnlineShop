using Online_Shop.Application.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Models;
using System.Web;
using System.Web.Mvc;
using Online_Shop.Application.Business_Layer;
using OnlineShop.Models.ShopingCart;
using Online_Shop.Application.Entities;
using OnlineShop.ViewModels;

namespace OnlineShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        ShopDAL Data = new ShopDAL();
        //
        // GET: /ShoppingCart/
        public ActionResult Index()
        {
            var cart = ShoppingCart_BusinessLayer.GetCart(this.HttpContext);

            ShoppingCartViewModel ViewModel = new ShoppingCartViewModel()
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };

            foreach (Cart itm in ViewModel.CartItems)
            {
                itm.product = Data.Products.Single(c => c.Id == itm.ProductId);
            }

            return View(ViewModel);
        }

        [HttpPost]
        public ActionResult AddtoCartDt(string id,string quantity)
        {
            int id2 = int.Parse(id);
            Product pro = Data.Products.Single(c => c.Id == id2);
            var cart = ShoppingCart_BusinessLayer.GetCart(this.HttpContext);
            int l = int.Parse(quantity);
            for (int i = 0; i < l; i++)
            {
                cart.AddToCart(pro);
            }
            var Cart = ShoppingCart_BusinessLayer.GetCart(this.HttpContext);
            cartSummary summ = new cartSummary()
            {
                amount = Cart.GetTotal(),
                count = Cart.GetCount()
            };
            return PartialView("CartSummary", summ);

            //return RedirectToAction("CartSummary1", "ShoppingCart");
            //return RedirectToAction("Index","Product");
        }

        public ActionResult AddtoCart(int id)
        {
            
            Product pro = Data.Products.Single(c => c.Id == id);
            var cart = ShoppingCart_BusinessLayer.GetCart(this.HttpContext);
            cart.AddToCart(pro);
            var Cart = ShoppingCart_BusinessLayer.GetCart(this.HttpContext);
            cartSummary summ = new cartSummary()
            {
                amount = Cart.GetTotal(),
                count = Cart.GetCount()
            };
            return PartialView("CartSummary", summ);

            //return RedirectToAction("CartSummary1", "ShoppingCart");
            //return RedirectToAction("Index","Product");
        }

       

        [HttpPost]
        public JsonResult RemoveFromCart(int id)
        {
            var cart = ShoppingCart_BusinessLayer.GetCart(this.HttpContext);
            Cart cart1 = Data.Cart.Single(c => c.RecordId == id);
            string product = Data.Products.Single(c => c.Id == cart1.ProductId).Description;
            //.product.Description;
            cart.removeFromCart(id);
            ShopingCartRemoveModel Result = new ShopingCartRemoveModel()
            {
                Message = Server.HtmlEncode(product) + "has been removed from the cart.",
                CartTotal = cart.GetTotal(),
                CartCount= cart.GetCount1(id),//cart.GetProCount(id,cart.ShoppingCartId),  //cart.GetCount(),
                DeleteId = id
            };

            return Json(Result, JsonRequestBehavior.AllowGet);
           // return  cart1.product.Description + " is removed from the cart";
        }

        

        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var Cart = ShoppingCart_BusinessLayer.GetCart(this.HttpContext);
            cartSummary summ = new cartSummary()
            {
                amount = Cart.GetTotal(),
                count = Cart.GetCount()
            };
            return PartialView("CartSummary",summ);
        }
	}
}