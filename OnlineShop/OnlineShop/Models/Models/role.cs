using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.User
{
    public class role
    {
        [Key]
        public int Id { get; set; }
        public string RoleName { get; set; }
        //public virtual UserData User { get; set; }

    }
}