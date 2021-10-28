using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Web.Interfaces;
using Web.ViewModels;

namespace Web.Services
{
    public class BasketViewModelService : IBasketViewModelService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAsyncRepository<Basket> _basketRepository;
        private readonly IBasketService _basketService;
        private readonly IAsyncRepository<Product> _productRepository;

        public BasketViewModelService(IHttpContextAccessor httpContextAccessor, IAsyncRepository<Basket> basketRepository, IBasketService basketService, IAsyncRepository<Product> productRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _basketRepository = basketRepository;
            _basketService = basketService;
            _productRepository = productRepository;
        }

        public async Task<List<BasketItemViewModel>> GetBasketItems()
        {
            return (await GetBasketViewModel()).Items;
        }
        public async Task<BasketItemsCountViewModel> GetBasketItemsCountViewModel(int? basketId = null)
        {
            var vm = new BasketItemsCountViewModel();
            if (!basketId.HasValue)
            {
                string buyerId = GetBuyerId();
                if (buyerId == null) return vm;
                var spec = new BasketSpecification(buyerId);
                var basket = await _basketRepository.FirstOrDefaultAsync(spec);
                if (basket == null) return vm;
                basketId = basket.Id;
            }
            vm.BasketItemsCount = await _basketService.BasketItemsCount(basketId.Value);
            return vm;
        }

        public async Task<BasketViewModel> GetBasketViewModel()
        {
            int basketId = await GetOrCreateBasketIdAsync();
            var specBasket = new BasketWithItemsSpecification(basketId);
            var basket = await _basketRepository.FirstOrDefaultAsync(specBasket);
            var productIds = basket.Items.Select(x => x.ProductId).ToArray();
            var specProducts = new ProductsSpecification(productIds);
            var products = await _productRepository.ListAsync(specProducts);
            var basketItems = new List<BasketItemViewModel>();

            foreach (var item in basket.Items.OrderBy(x => x.Id))
            {
                var product = products.First(x => x.Id == item.ProductId);
                basketItems.Add(new BasketItemViewModel()
                {
                    Id = item.Id,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    ProductName = product.ProductName,
                    Price = product.Price,
                    PictureUri = product.PictureUri
                });
            }
            
            return new BasketViewModel()
            {
                Id = basketId,
                BuyerId = basket.BuyerId,
                Items = basketItems,
            };
        }

        public string GetBuyerId()
        {
            var context = _httpContextAccessor.HttpContext;
            var user = context.User;
            var anonId = context.Request.Cookies[Constants.BASKET_COOKIE_NAME];
            return user.FindFirstValue(ClaimTypes.NameIdentifier) ?? anonId;
        }

        public async Task<int> GetOrCreateBasketIdAsync()
        {
            var buyerId = GetOrCreateBuyerId();
            var spec = new BasketSpecification(buyerId);
            var basket = await _basketRepository.FirstOrDefaultAsync(spec);

            if (basket == null)
            {
                basket = new Basket() { BuyerId = buyerId };
                basket = await _basketRepository.AddAsync(basket);
            }
            return basket.Id;
        }

        public string GetOrCreateBuyerId()
        {
            var context = _httpContextAccessor.HttpContext;
            var user = context.User;
            if (user.Identity.IsAuthenticated)
            {
                return user.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            else
            {
                if (context.Request.Cookies.ContainsKey(Constants.BASKET_COOKIE_NAME))
                {
                    return context.Request.Cookies[Constants.BASKET_COOKIE_NAME];
                }
                else
                {
                    string newBuyerId = Guid.NewGuid().ToString();
                    var cookieOptions = new CookieOptions()
                    {
                        IsEssential = true,
                        Expires = DateTime.Now.AddYears(20)
                    };
                    context.Response.Cookies.Append(Constants.BASKET_COOKIE_NAME, newBuyerId, cookieOptions);
                    return newBuyerId;
                }
            }
        }

        public async Task TransferBasketsAsync(string userId)
        {
            var context = _httpContextAccessor.HttpContext;
            var anonId = context.Request.Cookies[Constants.BASKET_COOKIE_NAME];
            if (!string.IsNullOrEmpty(anonId))
                await _basketService.TransferBasketAsync(anonId, userId);
            context.Response.Cookies.Delete(Constants.BASKET_COOKIE_NAME);
        }
    }
}
