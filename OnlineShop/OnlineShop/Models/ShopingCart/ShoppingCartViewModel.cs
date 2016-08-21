using Online_Shop.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.ShopingCart
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems = new List<Cart>();
        public decimal CartTotal { get; set; }
    }
}