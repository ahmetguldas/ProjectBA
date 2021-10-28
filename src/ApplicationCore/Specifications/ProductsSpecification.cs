using ApplicationCore.Entities;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Specifications
{
    public class ProductsSpecification : Specification<Product>
    {
        public ProductsSpecification(int[] ids)
        {
            Query.Where(x => ids.Contains(x.Id));
        }
    }
}
