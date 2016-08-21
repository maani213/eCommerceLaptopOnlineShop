﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Shop.Application.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; } 
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public long Phone { get; set; }
        public string Email { get; set; }
        public long Total { get; set; }
    }
}
