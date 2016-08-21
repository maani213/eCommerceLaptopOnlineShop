using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.ViewModels;
using Online_Shop.Application.DataAccessLayer;
using Online_Shop.Application.Business_Layer;
using Online_Shop.Application.Entities;
using OnlineShop.Filters;
using OnlineShop.Models.Products;

namespace OnlineShop.Controllers
{
    public class ProductController : Controller
    {
        BusinessLayer bl = new BusinessLayer();

        [AllowAnonymous]
       
        public ActionResult Index()
        {
            BusinessLayer bl=new BusinessLayer();
            List<Product> products = bl.GetAllProducts();
            List<images> imagesList = bl.GetImages();
            foreach(Product item in products)
            {
                item.ImgUrls = bl.FindImgs(item.Id);
            }
            return View("Index", products);
        }

        public ActionResult AllProducts()
        {
            BusinessLayer bl = new BusinessLayer();
            List<Product> products = bl.GetAllProducts();
            List<images> imagesList = bl.GetImages();
            foreach (Product item in products)
            {
                item.ImgUrls = bl.FindImgs(item.Id);
            }
            return View("AllProducts", products);
        }

       
        [HttpGet]
        public ActionResult Categories(int? id)
        {
            
            //int? a = id;
            List<Product> products = bl.SelectByCategory(id);
            List<images> imagesList = bl.GetImages();
            foreach (Product item in products)
            {
                item.ImgUrls = bl.FindImgs(item.Id);
            }
            if (products != null)
            {
                //return View("DellCategory", products);
                return View("Categories", products);
            }
            else
                return View("Categories");
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult GetNewLink()
        {
            ProductViewModel p = new ProductViewModel();
            return PartialView("_AddNew",p);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult SearchProd1()
        {
            return PartialView("~/Views/Product/_ProductSearch.cshtml");
        }


        [HttpPost]
        public ActionResult SearchProd(string Query)
        {
            var Prods = bl.SearchPro(Query);
            List<images> imagesList = bl.GetImages();
            foreach (Product item in Prods)
            {
                item.ImgUrls = bl.FindImgs(item.Id);
            }

            ViewBag.name = Query;
            return View("Product", Prods);
        }

        [HttpPost]
        public ActionResult PostReviews(int id,string username,string review,DateTime time,int c)
        {

            Reviews r = new Reviews()
            {
                UserId = username,
                ReviewText = review,
                time = time,
                ProdId = id
            };
            Notifications n = new Notifications()
            {

                category = "Product",
                Description = username + " posted a review on the product",
                time = DateTime.Now,
                DestinationId=id
            };
            bl.PostNotification(n);
            ReviewPostViewModel r1 = new ReviewPostViewModel()
            {
                UserId = username,
                ReviewText = review,
                time = time,
                ProdId = id,
                count=c+1
            };
            bl.PostReview(r);
            //return PartialView("~/Views/Product/_Reviews.cshtml", r);
            return Json(r1, JsonRequestBehavior.AllowGet);
            
            //return RedirectToAction("Review", "Product");

        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetReviews(int id)
        {
            
            List<Reviews> Reviews1 = bl.GetReviews(id);
            List<ReviewViewModel> review = new List<ReviewViewModel>();
            foreach (Reviews r in Reviews1)
            {
                ReviewViewModel rm = new ReviewViewModel(){
                days = r.time,
                ReviewText = r.ReviewText,
                UserId=r.UserId
                };
                review.Add(rm);
                
            }

            ViewBag.Count = Reviews1.Count();
            return PartialView("~/Views/Product/_Reviews.cshtml",review);
        }

        
        [ChildActionOnly]
        public ActionResult AdminLink()
        {
            string chk = Convert.ToString(Session["User"]);
            if (chk == "admin")
            {
                return PartialView("AdminLink");
            }
            else
            {
                return new EmptyResult();
            }
        }
    }
}