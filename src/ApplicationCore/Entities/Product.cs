using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
   public class Product : BaseEntity
    {
        public string BookName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }

        public int CategoryId { get; set; }  
        public virtual Category Category { get; set; }

        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        
        public DateTime CreatedTime { get; set; }
    }
}
