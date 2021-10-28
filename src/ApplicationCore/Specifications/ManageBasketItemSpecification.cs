using ApplicationCore.Entities;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Specifications
{
    public class ManageBasketItemSpecification : Specification<BasketItem>
    {
        public ManageBasketItemSpecification(int basketId, int basketItemId)
        {
            Query.Where(x => x.BasketId == basketId && x.Id == basketItemId);
        }
    }
}
