using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.UserManagment
{
    public class LogInModel
    {
         [Required(ErrorMessage = "User Name is required")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "you must enter password")]
        [StringLength(8)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}