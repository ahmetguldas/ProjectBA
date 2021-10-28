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
    public class OrderService : IOrderService
    {
        private readonly IAsyncRepository<Order> _orderRepository;
        private readonly IAsyncRepository<Basket> _basketRepository;
        private readonly IAsyncRepository<Product> _productRepository;

        public OrderService(IAsyncRepository<Order> orderRepository, IAsyncRepository<Basket> basketRepository, IAsyncRepository<Product> productRepository)
        {
            _orderRepository = orderRepository;
            _basketRepository = basketRepository;
            _productRepository = productRepository;
        }

        public async Task CreateOrderAsync(int basketId, Address shippingAddress)
        {
            var spec = new BasketWithItemsSpecification(basketId);
            var basket = await _basketRepository.FirstOrDefaultAsync(spec);
            var specProducts = new ProductsSpecification(basket.Items.Select(x => x.ProductId).ToArray());
            var products = await _productRepository.ListAsync(specProducts);

            Order order = new Order()
            {
                OrderDate = DateTimeOffset.Now,
                ShipToAddress = shippingAddress,
                BuyerId = basket.BuyerId,
                OrderItems = basket.Items.Select(x =>
                {
                    var product = products.First(p => p.Id == x.ProductId);
                    return new OrderItem()
                    {
                        ProductId = x.ProductId,
                        Quantity = x.Quantity,
                        PictureUri = product.PictureUri,
                        Price = product.Price,
                        ProductName = product.ProductName
                    };
                }).ToList()
            };
            await _orderRepository.AddAsync(order);
        }
    }
}
