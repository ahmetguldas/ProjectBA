using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IBasketService
    {
        Task AddItemToBasket(int basketId, int productId, int quantity);

        Task<int> BasketItemsCount(int basketId);

        Task DeleteBasketItem(int basketId, int basketItemId);

        Task UpdateBasketItem(int basketId, int basketItemId, int quantity);

        Task TransferBasketAsync(string anonymousId, string userId);

        Task DeleteBasketAsync(int basketId);
    }
}
