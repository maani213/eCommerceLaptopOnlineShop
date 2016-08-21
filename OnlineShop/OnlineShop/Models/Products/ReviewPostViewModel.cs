using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.Products
{
    public class ReviewPostViewModel
    {
        public int Id { get; set; }
        public string ReviewText { get; set; }
        public int ProdId { get; set; }
        public string UserId { get; set; }
        public DateTime time { get; set; }
        public int count { get; set; }
    }
}