using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Shop.Application.Entities
{
    public class Reviews
    {
        public int Id { get; set; }
        public string ReviewText { get; set; }
        public int ProdId { get; set; }
        public string UserId { get; set; }
        public DateTime time { get; set; }
    }
}
