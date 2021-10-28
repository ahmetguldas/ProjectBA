using ApplicationCore.Entities;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Specifications
{
    public class BasketItemSpecification : Specification<BasketItem>
    {
        public BasketItemSpecification(int basketId)
        {
            Query.Where(x => x.BasketId == basketId);
        }

        public BasketItemSpecification(int basketId, int productId)
        {
            Query.Where(x => x.BasketId == basketId && x.ProductId == productId);
        }
    }
}
