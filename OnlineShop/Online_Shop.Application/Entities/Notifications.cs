using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Online_Shop.Application.Entities
{
    public class Notifications
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public string category { get; set; }
        public DateTime time { get; set; }
        public int DestinationId { get; set; }
        //public virtual UserData User { get; set; }

    }
}