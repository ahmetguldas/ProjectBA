using System.Collections.Generic;

namespace ApplicationCore.Entities
{
   public class OrderStatus :BaseEntity
    {
        public string StatusDescription { get; set; }
       // public virtual ICollection<Order> Orders { get; set; }
    }
}
