using Online_Shop.Application.Business_Layer;
using Online_Shop.Application.DataAccessLayer;
using Online_Shop.Application.Entities;
using OnlineShop.Filters;
using OnlineShop.Models;
using OnlineShop.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
   [AdminFilters]
    public class AdminPanelController : Controller
    {
        BusinessLayer bl = new BusinessLayer();
        //
        // GET: /AdminPanel/
        
       // [AdminFilters]
       // [Route("Admin/AdminPanel")]
           
        public ActionResult Index()
        {
            BusinessLayer bl = new BusinessLayer();
            List<Product> products = bl.GetAllProducts();
            List<images> imagesList = bl.GetImages();
            foreach (Product item in products)
            {
                item.ImgUrls = bl.FindImgs(item.Id);
            }
            return View("AdminPanel", products);
        }
       [ChildActionOnly]
       [HttpGet]
        public ActionResult admin()
        {
            if (Convert.ToString(Session["User"]) == "Admin" || Convert.ToString(Session["User"]) == "admin")
            {
                //return "@Html.ActionLink(" + "Admin Panel" + ", " + "Index" + "," + "AdminPanel" + ", null, new { style = " + "color:#645a5a;" + "})";
                return PartialView("~/Views/Authentication/_AdminBtn.cshtml");
            }
            else
                return new EmptyResult();//PartialView("~/Views/Authentication/_AdminBtn.cshtml");
        }

        public ActionResult GetNotifications()
        {
            List<Notifications> n= bl.GetNotifications();
            ViewBag.count=n.Count;
            return View("Notifications",n);
        }

        public ActionResult DeleteNotification(int? id)
        {
            bl.DeleteNotification(id);
            return RedirectToAction("GetNotifications");
        }

      //  [AdminFilters]
        public ActionResult AllUsers()
        {
            List<UserDetail> users = bl.GetAllUsers();
            return View("AllUsers", users);
        }

      
       // [AdminFilters]
          [HttpGet]
        public ActionResult AddNewProduct()
        {
            ViewBag.OperatingSystem = new List<SelectListItem>
                                    {
                                        new SelectListItem{ Text="-Operating System-", Value=null},
                                        new SelectListItem{Text="Windows 10" ,Value="Windows 10" },
                                        new SelectListItem{Text="Windows 8" ,Value="Windows 8" },
                                        new SelectListItem{Text="Windows 7" ,Value="Windows 7" },
                                        new SelectListItem{Text="Windows xp" ,Value="Windows xp" },
                                         new SelectListItem{Text="Mac OS X" ,Value="Mac OS X" }

                                    };
            ViewBag.webcam = new List<SelectListItem>
                               {
                                   new SelectListItem{ Text="-Select-",Value=null},
                                   new SelectListItem{Text="Yes",Value="true"},
                                   new SelectListItem{Text="No",Value="false"},
                               };

            ViewBag.CategoryList = new List<SelectListItem>
                                {
                                   // new SelectListItem{Text="-Select Category-",Value="0", Selected=true},
                                    new SelectListItem{ Text="-Category-", Value=null},
                                   new SelectListItem{Text="DELL",Value="1" },
                                    new SelectListItem{Text="HP",Value="2"},
                                    new SelectListItem{Text="ACER",Value="3"},
                                    new SelectListItem{Text="APPLE",Value="4"},
                                    new SelectListItem{Text="LENOVO",Value="5"},
                                    new SelectListItem{Text="SAMSUNG",Value="6"},
                                    new SelectListItem{Text="ASUS",Value="7"}
                                };
            

            return View("AddNewProduct");
        }

        [HttpPost]
        public ActionResult SaveProduct(Product p)
        {
           
            int counter = 0;

            if (ModelState.IsValid)
            {
                
                BusinessLayer b = new BusinessLayer();
                //Product p = new Product() { 
                //categoryId=pc.SelectedCategoryId,
                //WebCam=pc.SelectedWebCam,
                //OperatingSystem=pc.SelectedOperatingSystem,
                //RAM=pc.RAM,
                //ProcessorType=pc.ProcessorType,
                //Price=pc.Price,
                //HardDrive=pc.HardDrive,
                //Title=pc.Title,
                //Color=pc.DedicatedGraphicMemory,
                //Description=pc.Description,
                //ScreenSize=pc.ScreenSize,
                //Status=pc.Status         
                //};

                b.AddProduct(p);
                ShopDAL Imag = new ShopDAL();

                foreach (string fn in Request.Files)
                {
                    HttpPostedFileBase postedFile = Request.Files[fn];
                    if (Request.Files[fn] != null)
                    {
                        if (postedFile != null && postedFile.ContentLength != 0)
                        {
                            string fName = DateTime.Now.Ticks + "_" + ++counter + postedFile.FileName.Substring(postedFile.FileName.LastIndexOf("."));
                            string WebUrl = "~/images/Products/" + fName;
                            string physicalPath = Request.MapPath(WebUrl);
                            postedFile.SaveAs(physicalPath);
                            images Img = new images();
                            Img.ImgUrl = WebUrl;
                            Img.productId = p.Id;
                            Imag.Images.Add(Img);
                            Imag.SaveChanges();
                        }
                    }
                }
               // return RedirectToAction("ProductGrid","Product");
                return RedirectToAction("Index", "AdminPanel");
                
            }
            else
            {

                ViewBag.OperatingSystem = new List<SelectListItem>
                                    {
                                        new SelectListItem{ Text="-Operating System-", Value=null},
                                        new SelectListItem{Text="Windows 10" ,Value="Windows 10" },
                                        new SelectListItem{Text="Windows 8" ,Value="Windows 8" },
                                        new SelectListItem{Text="Windows 7" ,Value="Windows 7" },
                                        new SelectListItem{Text="Windows xp" ,Value="Windows xp" },
                                         new SelectListItem{Text="Mac OS X" ,Value="Mac OS X" }

                                    };
                ViewBag.webcam = new List<SelectListItem>
                               {
                                   new SelectListItem{ Text="-Select-",Value=null},
                                   new SelectListItem{Text="Yes",Value="true"},
                                   new SelectListItem{Text="No",Value="false"},
                               };

                ViewBag.CategoryList = new List<SelectListItem>
                                {
                                   // new SelectListItem{Text="-Select Category-",Value="0", Selected=true},
                                    new SelectListItem{ Text="-Operating System-", Value=null},
                                   new SelectListItem{Text="DELL",Value="1" },
                                    new SelectListItem{Text="HP",Value="2"},
                                    new SelectListItem{Text="ACER",Value="3"},
                                    new SelectListItem{Text="APPLE",Value="4"},
                                    new SelectListItem{Text="LENOVO",Value="5"},
                                    new SelectListItem{Text="SAMSUNG",Value="6"},
                                    new SelectListItem{Text="ASUS",Value="7"}
                                };
                return View("AddNewProduct");
            }
           

        }
       // [AdminFilters]
        public ActionResult AllOrders()
        {
            List<Order> orders = bl.GetAllOrders();
            List<OrderDetail> OrderDetails = bl.GetAllorderdetails();

            foreach (Order ord in orders)
            {
                foreach (OrderDetail ordd in OrderDetails)
                {
                    if (ordd.OrderId == ord.OrderId)
                    {
                        ord.Total = ord.Total + ordd.UnitPrice;
                    }
                }
            }

            return View("AllOrders",orders);
        }
      //  [AdminFilters]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        //[AdminFilters]
        public ActionResult AddCategory(Category c)
        {
            bl.AddCategory(c);
            return RedirectToAction("Index");
        }

        public void DefaultCategories()
        {
            bl.AddCaetegories();
        }

        public ActionResult ShowAllCategories()
        { 
            var a=bl.GetAllCategories();
            return View("ShowAllCategories",a);
        }
      //  [AdminFilters]
        //public ActionResult OrderDetails(int? id)
        //{
        //    var a = bl.GetOneOrderDetail(id);
        //    var b = bl.GetOneOrder(id);
        //    OrderModel mdl = new OrderModel();
        //    mdl.OrdDetail = a;
        //    mdl.Order = b;
        //    return View(mdl);
        //}
      


        }
	}
