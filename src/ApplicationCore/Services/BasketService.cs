using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class BasketService : IBasketService
    {
        private readonly IAsyncRepository<BasketItem> _basketItemRepository;
        private readonly IAsyncRepository<Basket> _basketRepository;

        public BasketService(IAsyncRepository<BasketItem> basketItemRepository, IAsyncRepository<Basket> basketRepository)
        {
            _basketItemRepository = basketItemRepository;
            _basketRepository = basketRepository;
        }

        public async Task AddItemToBasket(int basketId, int productId, int quantity)
        {
            if (quantity < 1) 
                throw new ArgumentException("Miktar 1'den küçük olamaz.");

            var spec = new BasketItemSpecification(basketId, productId);
            var basketItem = await _basketItemRepository.FirstOrDefaultAsync(spec);

            if (basketItem != null)
            {
                basketItem.Quantity += quantity;
                await _basketItemRepository.UpdateAsync(basketItem);
            }
            else
            {
                basketItem = new BasketItem() { BasketId = basketId, ProductId = productId, Quantity = quantity };
                await _basketItemRepository.AddAsync(basketItem);
            }
        }

        public async Task<int> BasketItemsCount(int basketId)
        {
            var spec = new BasketItemSpecification(basketId);
            return await _basketItemRepository.CountAsync(spec);
        }

        public async Task DeleteBasketAsync(int basketId)
        {
            var basket = await _basketRepository.GetByIdAsync(basketId);
            await _basketRepository.DeleteAsync(basket);
        }

        public async Task DeleteBasketItem(int basketId, int basketItemId)
        {
            var spec = new ManageBasketItemSpecification(basketId, basketItemId);
            var item = await _basketItemRepository.FirstOrDefaultAsync(spec);
            await _basketItemRepository.DeleteAsync(item);
        }

        public async Task TransferBasketAsync(string anonymousId, string userId)
        {
            var specAnon = new BasketWithItemsSpecification(anonymousId);
            var basketAnon = await _basketRepository.FirstOrDefaultAsync(specAnon);
            if (basketAnon == null || !basketAnon.Items.Any()) return;

            var specUser = new BasketWithItemsSpecification(userId);
            var basketUser = await _basketRepository.FirstOrDefaultAsync(specUser);
            if (basketUser == null)
                basketUser = await _basketRepository.AddAsync(new Basket() { BuyerId = userId });

            foreach (BasketItem itemAnon in basketAnon.Items)
            {
                var itemUser = basketUser.Items.FirstOrDefault(x => x.ProductId == itemAnon.ProductId);

                if (itemUser == null)
                {
                    basketUser.Items.Add(new BasketItem() 
                    { 
                        ProductId = itemAnon.ProductId, 
                        Quantity = itemAnon.Quantity 
                    });
                }
                else
                {
                    itemUser.Quantity += itemAnon.Quantity;
                }
            }

            await _basketRepository.UpdateAsync(basketUser);
            await _basketRepository.DeleteAsync(basketAnon);
        }

        public async Task UpdateBasketItem(int basketId, int basketItemId, int quantity)
        {
            if (quantity < 1) throw new Exception("Miktar 1'den küçük olamaz.");
            var spec = new ManageBasketItemSpecification(basketId, basketItemId);
            var item = await _basketItemRepository.FirstOrDefaultAsync(spec);
            item.Quantity = quantity;
            await _basketItemRepository.UpdateAsync(item);
        }
    }
}
