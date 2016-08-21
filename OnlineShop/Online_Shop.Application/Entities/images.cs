//using OnlineShop.Models.Products;
//using OnlineShop.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Online_Shop.Application.Entities
{
    public class images
    {
        [Key]
        public int Id { get; set; }
        public string ImgUrl { get; set; }
        public int productId { get; set; }
        //public virtual Product Products { get; set; }
        //public virtual UserData Users { get; set; }
    }
}