using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.ViewModels;

namespace Web.Interfaces
{
    public interface IBasketViewModelService
    {
        string GetBuyerId();

        string GetOrCreateBuyerId();

        Task<int> GetOrCreateBasketIdAsync();

        Task<BasketItemsCountViewModel> GetBasketItemsCountViewModel(int? basketId = null);

        Task<List<BasketItemViewModel>> GetBasketItems();

        Task<BasketViewModel> GetBasketViewModel();

        Task TransferBasketsAsync(string userId);
    }
}
