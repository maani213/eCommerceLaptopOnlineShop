using Online_Shop.Application.Business_Layer;
using Online_Shop.Application.DataAccessLayer;
using Online_Shop.Application.Entities;
using OnlineShop.Filters;
using OnlineShop.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class ProductsManagmentController : Controller
    {
        ShopDAL shop = new ShopDAL();
        BusinessLayer bl = new BusinessLayer();
        //
        // GET: /ProductsManagment/
        public ActionResult Index()
        {
            return View();
        }

    [AdminFilters]
        [HttpGet]
        public ActionResult Edit(int? id)
        {
        

          ViewBag.OperatingSystem = new List<SelectListItem>
                                    {
                                        new SelectListItem{Text="Windows 10" ,Value="Windows 10" },
                                        new SelectListItem{Text="Windows 8" ,Value="Windows 8" },
                                        new SelectListItem{Text="Windows 7" ,Value="Windows 7" },
                                        new SelectListItem{Text="Windows xp" ,Value="Windows xp" }

                                    };
            ViewBag.webcam = new List<SelectListItem>
                               {
                                   new SelectListItem{Text="Yes",Value="true"},
                                   new SelectListItem{Text="No",Value="false"},
                               };
         ViewBag.Category = new List<SelectListItem>
                                {
                                    new SelectListItem{Text="DELL",Value="1"},
                                    new SelectListItem{Text="HP",Value="2"},
                                    new SelectListItem{Text="APPLE",Value="3"},
                                    new SelectListItem{Text="ACER",Value="4"},
                                    new SelectListItem{Text="LENOVO",Value="5"},
                                    new SelectListItem{Text="SAMSUNG",Value="6"},
                                    
                                    };

            //Product pro = bl.EditProduct(id);
            //return RedirectToAction("Index", "AdminPanel");    
         return View("Edit",shop.Products.Find(id));
        //return View("Index", "AdminPanel", pro);
        }

    [AdminFilters]
        [HttpPost]
        public ActionResult Edit(Product pro)
        {
            var imags = shop.Images.Where(c => c.productId == pro.Id);
            List<string> i = new List<string>();
            foreach (images img in imags)
            {
                if (img.productId == pro.Id)
                {
                    i.Add(img.ImgUrl);
                }
            }
            pro.ImgUrls = i;
            if (ModelState.IsValid)
            {
                shop.Entry(pro).State = EntityState.Modified;
                shop.SaveChanges();
                return RedirectToAction("Index", "AdminPanel");
            }
            ViewBag.OperatingSystem = new List<SelectListItem>
                                    {
                                        new SelectListItem{Text="Windows 10" ,Value="Windows 10" },
                                        new SelectListItem{Text="Windows 8" ,Value="Windows 8" },
                                        new SelectListItem{Text="Windows 7" ,Value="Windows 7" },
                                        new SelectListItem{Text="Windows xp" ,Value="Windows xp" }

                                    };
            ViewBag.webcam = new List<SelectListItem>
                               {
                                   new SelectListItem{Text="Yes",Value="true"},
                                   new SelectListItem{Text="No",Value="false"},
                               };
            ViewBag.Category = new List<SelectListItem>
                                {
                                    new SelectListItem{Text="DELL",Value="1"},
                                    new SelectListItem{Text="HP",Value="2"},
                                    new SelectListItem{Text="APPLE",Value="3"},
                                    new SelectListItem{Text="ACER",Value="4"},
                                    new SelectListItem{Text="LENOVO",Value="5"},
                                    new SelectListItem{Text="SAMSUNG",Value="6"},
                                    
                                    };
            return View(pro);
        }

    [AdminFilters]        
        public ActionResult Delete(int? Id)
        {
           
            Product pro= shop.Products.Find(Id);
            //List<images> imgs = new List<images>(); 
            bl.RemImage(Id);
            shop.Products.Remove(pro);
            shop.SaveChanges();
            return RedirectToAction("Index", "AdminPanel");

        }
       [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            Product pro= shop.Products.Find(id);
            var imags = shop.Images.Where(c => c.productId == id);
            ProductDetail product = new ProductDetail();
            
                product.Id = pro.Id;
                product.Price = pro.Price;
                product.ProcessorType = pro.ProcessorType;
                product.RAM = pro.RAM;
                product.Title = pro.Title;
                product.ImgUrls = pro.ImgUrls;
                product.Description = pro.Description;
                product.HardDrive = pro.HardDrive;
                product.WebCam = pro.WebCam;
                product.ScreenSize = pro.ScreenSize;
                product.DedicatedGraphicMemory = pro.DedicatedGraphicMemory;
                product.category = shop.Category.Single(c => c.CategoryId == pro.categoryId).Title;
                product.Status = pro.Status;
            
            List<string> i = new List<string>();
            foreach (images img in imags)
            {
                if (img.productId == pro.Id)
                {
                    i.Add(img.ImgUrl);
                }
            }
            product.ImgUrls = i;
           
            return View("Details", product);
        }

	}
}