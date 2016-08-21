using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Shop.Application.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        //public virtual List<Product> Products { get; set; }
    }
}