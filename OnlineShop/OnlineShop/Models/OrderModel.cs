using Online_Shop.Application.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Models
{
    //[MetadataType(typeof(OrderMetadata))]
    //[MetadataType(typeof(OrderMetadata))]
    [Bind(Exclude = "OrderId")]
    public class OrderModel
    {



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
