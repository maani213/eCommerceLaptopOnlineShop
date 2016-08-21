using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.User
{
    public class UserDetail
    {
        [Key]
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string SecQuest { get; set; }
        public string Answer { get; set; }
        public int roleId { get; set; }
        public string imgUrl { get; set; }

    }
}