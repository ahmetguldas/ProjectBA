using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
   public class OrderStatus :BaseEntity
    {
        public string StatusDescription { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
