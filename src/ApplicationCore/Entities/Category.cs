using System.Collections.Generic;

namespace ApplicationCore.Entities
{
   public class Category :BaseEntity
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
