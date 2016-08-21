using OnlineShop.DataAccessLayer;
using OnlineShop.Models.Products;
using OnlineShop.Models.User;
using OnlineShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class BusinessLayer
    {
        public List<Product> GetProducts()
        {
            ShopDAL Data = new ShopDAL();
            return Data.Products.ToList();
        }
        public List<UserDetail> GetUsers()
        {
            ShopDAL data = new ShopDAL();
            return data.Users.ToList();
        }

        public List<images> GetImages()
        {
            ShopDAL img = new ShopDAL();
            return img.Images.ToList();
        }

        public void AddProduct(Product p)
        {
            ShopDAL product = new ShopDAL();
            ShopDAL Imag = new ShopDAL();
            product.Products.Add(p);
            product.SaveChanges();
        }   
    }
}