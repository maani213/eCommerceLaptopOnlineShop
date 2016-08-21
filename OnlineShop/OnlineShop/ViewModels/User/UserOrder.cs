using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.ViewModels.User
{
    public class UserOrder
    {
        public int OrderId { get; set; }
        
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime OrderDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public long Phone { get; set; }
        public string Email { get; set; }
        public long Total { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }

    }
}