using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.Products
{
    public class ReviewViewModel
    {
        public int Id { get; set; }
        public string ReviewText { get; set; }
        public string UserId { get; set; }
        public DateTime days { get; set; }
        public string ImgUrl { get; set; }
    }
}