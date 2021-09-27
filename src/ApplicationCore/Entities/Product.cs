using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
   public class Product : BaseEntity
    {
        public string BookName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime CreatedTime { get; set; }
        public int CategoryId { get; set; }   //hangi categoriye ait
        public Category Category { get; set; }
    }
}
