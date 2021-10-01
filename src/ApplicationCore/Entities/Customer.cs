using System.Collections.Generic;

namespace ApplicationCore.Entities
{
   public class Customer :BaseEntity
    {
        public string Email { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int Phone { get; set; }
       // public virtual List<Order> Orders { get; set; }
    }
}
