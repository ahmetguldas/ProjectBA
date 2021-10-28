using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Interfaces;
using Web.ViewModels;

namespace Web.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketViewModelService _basketViewModelService;
        private readonly IBasketService _basketService;
        private readonly IOrderService _orderService;

        public BasketController(IBasketViewModelService basketViewModelService, IBasketService basketService, IOrderService orderService)
        {
            _basketViewModelService = basketViewModelService;
            _basketService = basketService;
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _basketViewModelService.GetBasketViewModel());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToBasket(int productId, int quantity)
        {
            var basketId = await _basketViewModelService.GetOrCreateBasketIdAsync();
            await _basketService.AddItemToBasket(basketId, productId, quantity);

            return Json(await _basketViewModelService.GetBasketItemsCountViewModel(basketId));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveBasketItem(int basketItemId)
        {
            var basketId = await _basketViewModelService.GetOrCreateBasketIdAsync();
            await _basketService.DeleteBasketItem(basketId, basketItemId);
            return PartialView("_BasketPartial", await _basketViewModelService.GetBasketViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBasketItem(int basketItemId, int quantity)
        {
            if (quantity < 1) 
                return BadRequest("The quantity cannot be less than 1.");

            var basketId = await _basketViewModelService.GetOrCreateBasketIdAsync();
            await _basketService.UpdateBasketItem(basketId, basketItemId, quantity);
            return PartialView("_BasketPartial", await _basketViewModelService.GetBasketViewModel());
        }

        [Authorize]
        public async Task<IActionResult> Checkout()
        {
            var vm = new CheckoutViewModel()
            {
                BasketItems = await _basketViewModelService.GetBasketItems()
            };
            return View(vm);
        }

        [Authorize, HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout(CheckoutViewModel model)
        {
            if (ModelState.IsValid)
            {
                int basketId = await _basketViewModelService.GetOrCreateBasketIdAsync();
                var address = new Address()
                {
                    City = model.City,
                    Country = model.Country,
                    Street = model.Street,
                    State = model.State,
                    ZipCode = model.ZipCode
                };
                await _orderService.CreateOrderAsync(basketId, address);
                await _basketService.DeleteBasketAsync(basketId);

                return RedirectToAction("Success");
            }

            model.BasketItems = await _basketViewModelService.GetBasketItems();
            return View(model);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
