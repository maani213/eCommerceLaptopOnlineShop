using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Shop.Application.Entities
{
    public class Subscribers
    {
        [Key]
        public int id { get; set; }
        public string Email { get; set; }
    }
}
