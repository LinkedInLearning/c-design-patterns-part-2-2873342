using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HPlusSports.DAL;
using HPlusSports.Models;
using Microsoft.Extensions.Caching.Memory;

namespace HPlusSports.Core
{
    public class SimpleCachingOrderService : ISimpleCachingOrderService
    {
        IMemoryCache _cache;
        IOrderService _orderService;
        readonly string OrderCustomerCacheKey = "OrderSet";
        public SimpleCachingOrderService(IOrderService orderService, IMemoryCache memoryCache)
        {
            _orderService = orderService;
            _cache = memoryCache;
        }

        public async Task<IList<Order>> GetOrdersWithCustomers()
        {
           return await _cache.GetOrCreateAsync(OrderCustomerCacheKey, (entry) => _orderService.GetOrdersWithCustomers());
        }

        public Task<IList<Order>> GetCustomerOrders(int CustomerId)
        {
            
           return _orderService.GetCustomerOrders(CustomerId); 
        }

        public async Task<Order> CreateOrder(int CustomerId, int SalesPersonId, IEnumerable<string> ProductCodes)
        {
            var orderBuilder = _orderService.StartOrder(CustomerId, SalesPersonId);

            ProductCodes.ToList().ForEach(pc => 
                orderBuilder.OrderProduct(new ProductOrderInformation(){ ProductCode = pc, Quantity = 1})
                );

            var order = await _orderService.CompleteOrder(orderBuilder);

            _cache.Remove(OrderCustomerCacheKey);

            return order;
        }
    }
}