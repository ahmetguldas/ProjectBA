using ApplicationCore.Entities;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore
{
   public class ProductSpecification : Specification<Product>
    {
        public ProductSpecification()
        {
            Query.Include(x => x.Author);
        }
    }
}
