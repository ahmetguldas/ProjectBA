using System;
using System.Collections.Generic;

namespace EticaretBA.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        
        public List<ProductCategory> ProductCategories { get; set; }
    }
}