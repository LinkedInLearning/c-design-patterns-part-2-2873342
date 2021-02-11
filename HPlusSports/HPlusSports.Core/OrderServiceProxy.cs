using System.Collections.Generic;
using System.Threading.Tasks;
using HPlusSports.DAL;
using HPlusSports.Models;
using Microsoft.Extensions.Caching.Memory;

namespace HPlusSports.Core
{
    public class CachingOrderService : IOrderService
    {
        IMemoryCache _cache;
        IOrderService _orderService;
        readonly string OrderCustomerCacheKey = "OrderSet";
        public CachingOrderService(IOrderService orderService, IMemoryCache memoryCache)
        {
            _orderService = orderService;
            _cache = memoryCache;
        }

        public async Task<IList<Order>> GetOrdersWithCustomers()
        {
           return await _cache.GetOrCreateAsync(OrderCustomerCacheKey, (entry) => _orderService.GetOrdersWithCustomers());
        }

        Task<Order> IOrderService.CompleteOrder(NewOrderInformationBuilder builder)
        {
            _cache.Remove(OrderCustomerCacheKey);
            return _orderService.CompleteOrder(builder);
        }

        Task<IList<Order>> IOrderService.GetCustomerOrders(int CustomerId)
        {
            return _orderService.GetCustomerOrders(CustomerId);
        }

        NewOrderInformationBuilder IOrderService.StartOrder(int CustomerId, int SalesPersonId)
        {
            return _orderService.StartOrder(CustomerId, SalesPersonId);
        }
    }
}