﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.Products
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        //public virtual List<Product> Products { get; set; }
    }
}