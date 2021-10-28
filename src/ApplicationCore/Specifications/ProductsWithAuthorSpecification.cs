using ApplicationCore.Entities;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Specifications
{
    public class ProductsWithAuthorSpecification : Specification<Product>
    {
        public ProductsWithAuthorSpecification()
        {
            Query.Include(x => x.Author);
        }

        public ProductsWithAuthorSpecification(int? categoryId, int? authorId) : this()
        {
            if (categoryId.HasValue)
            {
                Query.Where(x => x.CategoryId == categoryId);
            }

            if (authorId.HasValue)
            {
                Query.Where(x => x.AuthorId == authorId);
            }
        }

        public ProductsWithAuthorSpecification(int? categoryId, int? authorId, int skip, int take) : this(categoryId, authorId)
        {
            Query.Skip(skip).Take(take);
        }
    }
}
