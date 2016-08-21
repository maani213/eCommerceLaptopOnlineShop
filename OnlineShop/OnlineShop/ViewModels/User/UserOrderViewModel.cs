using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.ViewModels.User
{
    public class UserOrderViewModel
    {
        public int OrderId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public DateTime OrderDate { get; set; }
        public string Address { get; set; }
        public long Phone { get; set; }
        public string Email { get; set; }
        public long Total { get; set; }
     }
}