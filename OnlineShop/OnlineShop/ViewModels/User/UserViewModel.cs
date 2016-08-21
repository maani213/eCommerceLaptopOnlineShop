using Online_Shop.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.ViewModels.User
{
    public class UserViewModel
    {

        public string FName { get; set; }
        public string LName { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string SecQuest { get; set; }
        public string ImgUrl { get; set; }
        public string Answer { get; set; }
        public int roleId { get; set; }
       
    }
}