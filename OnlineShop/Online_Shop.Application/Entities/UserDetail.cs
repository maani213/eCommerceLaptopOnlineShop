using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Online_Shop.Application.Entities
{
    public class UserDetail
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [DisplayName("First Name")]
        [StringLength(160)]
        public string FName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [DisplayName("Last Name")]
        [StringLength(160)]
        public string LName { get; set; }

        [Required(ErrorMessage = "User Name is required")]
        [DisplayName("User Name")]
        [StringLength(12,ErrorMessage="User Name Length must be 1 to 8")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "you must enter password")]
        [DisplayName("Password")]
        [StringLength(8,ErrorMessage="Password Length must be 1 to 8")]
        public string Password { get; set; }


        public string Gender { get; set; }

         [Required(ErrorMessage = "you must enter Date of Birth")]
        [DisplayName("Date of birth")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "you must enter your email address")]
        [DisplayName("Email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
            ErrorMessage = "Email is is not valid.")]
        public string Email { get; set; }

         [Required(ErrorMessage = "you must enter Address")]
         public string Address { get; set; }

         [Required(ErrorMessage = "you must enter Country name")]
         public string country { get; set; }

         [Required(ErrorMessage = "you must city name")]
         public string city { get; set; }


        [Required(ErrorMessage = "you must contact detail")]
        public string Contact { get; set; }

        [Required(ErrorMessage = "you must select security question")]
        [DisplayName("Security Question")]
        public string SecQuest { get; set; }

         [Required(ErrorMessage = "you must answer of your security question")]
        [DisplayName("Answer")]
        public string Answer { get; set; }
        public int roleId { get; set; }
        public string imgUrl { get; set; }

    }
}