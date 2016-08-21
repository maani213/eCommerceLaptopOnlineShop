using Online_Shop.Application.DataAccessLayer;
using Online_Shop.Application.Entities;
using System;
using System.Collections.Generic;
//using System.Data;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Net.Mail;
using System.Net;

namespace Online_Shop.Application.Business_Layer
{
    public class BusinessLayer
    {
        ShopDAL Data = new ShopDAL();

        

       
        public List<OrderDetail> GetAllorderdetails()
        {
            return Data.OrderDetail.ToList();
        }


        public List<Product> SearchPro(string s)
        {
            List<Product> ListProd =Data.Products.Where(p=>p.Title.Contains(s)) .ToList() ;
            return ListProd;   
                                        
        }
        public List<Order> GetOneOrder(int id)
        {
           
            UserDetail username=Data.Users.Single(o=>o.Id==id);
            var orders = (from ord in Data.Order
                          where ord.UserName == username.UserId
                          select ord).ToList();
            var orderdetails = this.GetAllorderdetails();
            foreach (Order or in orders)
            {
                foreach (OrderDetail ord in orderdetails)
                {
                    if (ord.OrderId == or.OrderId)
                    {
                        or.Total = or.Total + ord.UnitPrice;
                    }
                }
            }
            return orders;
            
        }

        public void PostNotification(Notifications n)
        {
            Data.Notifications.Add(n);
            Data.SaveChanges();
        }

        public void DeleteNotification(int? id)
        {
            Notifications n = Data.Notifications.Find(id);
            Data.Notifications.Remove(n);
            Data.SaveChanges();
        }
        public List<Notifications> GetNotifications()
        {
            List<Notifications> notifiactions= Data.Notifications.ToList();
            return notifiactions;
        }

        public OrderDetail GetOneOrderDetail(int? id)
        {

            return Data.OrderDetail.SingleOrDefault(o => o.OrderDetailId == id);

        }
        public List<Product> GetAllProducts()
        {
           
            return Data.Products.ToList();
        }

        public List<Product> SelectByCategory(int? id)
        {
            List<Product> pro = (from product in Data.Products
                                 where product.categoryId == id
                                 select product).ToList();
            return pro;

        }

        public List<UserDetail> GetAllUsers()
        {
            return Data.Users.ToList();
        }

        public List<images> GetImages()
        {
            return Data.Images.ToList();
        }

        public void DeleteAccount(int id)
        {
            UserDetail p = Data.Users.Find(id);
            Data.Users.Remove(p);
            Data.SaveChanges();
        }
        public Product EditProduct(int? id)
        {
            Product p = Data.Products.Find(id);
            Data.Entry(p).State = EntityState.Modified;
            return Data.Products.Find(id);
            //dbCtx.Entry(stud).State = System.Data.Entity.EntityState.Modified;   
        }
        public void AddProduct(Product p)
        {
            //p.Id = null;
            Data.Products.Add(p);
            Data.SaveChanges();
        }

        public string ValidateUser(UserDetail u)
        {
            UserDetail usr = Data.Users.SingleOrDefault(x => x.Password==u.Password && x.UserId == u.UserId);
            if (usr!=null)
            {
                return usr.UserId;
            }
            else  
            {
            return "nonAuthenticatedAdminUser";
            }  
        }

        public List<string> FindImgs(int id)
        {
            List<string> url = (from imgs in Data.Images
                                where imgs.productId == id
                                select imgs.ImgUrl).ToList();
            return url;
        }
        public UserDetail FindUser(string a)
        {
             UserDetail usr=Data.Users.Single(c => c.UserId == "maani6736");
             if (usr != null)
             {
                 return usr;
             }
             else
                 return new UserDetail();
        }

        public bool CheckUser(UserDetail a)
        {
            List<UserDetail> chk=Data.Users.ToList();
            if (chk.Count == 0)
            {
                return false;
            }
            //bool x=Data.Users.Contains(a);
            var usr = Data.Users.Where(c => c.UserId == a.UserId);

            if (usr != null)
            {
                return true;
            }
            else
                return false;
           
        }

        public void AddUser(UserDetail u)
        {
            Data.Users.Add(u);
            Data.SaveChanges();
        }

        public void AddSubscriber(string s )
        {
            Subscribers s1 = new Subscribers()
            {
                Email = s
            };
            Data.Subscribers.Add(s1);
            Data.SaveChanges();
        }
        public List<Order> GetAllOrders()
        {
            List<Order> orders = Data.Order.ToList();
            return orders;
        }

        public void AddCategory(Category c)
        {
            Data.Category.Add(c);
            Data.SaveChanges();
        }

        public List<Category> GetAllCategories()
        {
            List<Category> c= Data.Category.ToList();
            return c;
        }

        public UserDetail GetUser(int? id)
        {
            UserDetail usr = Data.Users.Find(id);
            return usr;
        }

        public void RemImage(int? Id)
        {
            var imgs = Data.Images.Where(c => c.productId == Id);
            foreach (var im in imgs)
            {
                Data.Images.Remove(im);
               
            }
            Data.SaveChanges();
        }
        public void EditUser(UserDetail u)
        {
            Data.Entry(u).State = EntityState.Modified;
            Data.SaveChanges();
            
        }


        public void PostReview(Reviews r)
        {
            Data.Reviews.Add(r);
            Data.SaveChanges();
        }

        public List<Reviews> GetReviews(int id)
        {
            var reviews = Data.Reviews.Where(r => r.ProdId == id).ToList();
            return reviews;
        }

        public void AddCaetegories()
        {
            List<Category> Categories = new List<Category>();
            Category c1 = new Category()
            {
                Title = "DELL"
            };

            Data.Category.Add(c1);
            Data.SaveChanges();
            Category c2 = new Category()
            {
                Title = "HP"
            };
            Data.Category.Add(c2);
            Data.SaveChanges();

            Category c3 = new Category()
            {
                Title = "ACER"
            };
            Data.Category.Add(c3);
            Data.SaveChanges();

            Category c4 = new Category()
            {
                Title = "APPLE"
            };
            Data.Category.Add(c4);
            Data.SaveChanges();

            Category c5 = new Category()
            {
                Title = "LENOVO"
            };
            Data.Category.Add(c5);
            Data.SaveChanges();

            Category c6 = new Category()
            {
                Title = "SAMSUNG"
            };
            Data.Category.Add(c6);
            Data.SaveChanges();

            Category c7 = new Category()
            {
                Title = "ASUS"
            };
            Data.Category.Add(c7);
            Data.SaveChanges();
            
        }

        public void SendMail(string e)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(e);
            mail.From = new MailAddress("creatlist16@gmail.com");
            mail.Subject = "Welcom To Laptops Shop";
            mail.Body = "Hi.. you are warm Welcom to our customers";
            mail.IsBodyHtml = true;
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("creatlist16@gmail.com", "khuajaasif123");
            client.EnableSsl = true;
            client.Send(mail);

        }

    }
}