using System.Collections.Generic;
using System.Threading.Tasks;
using HPlusSports.DAL;
using HPlusSports.Models;
using Microsoft.Extensions.Caching.Memory;

namespace HPlusSports.Core
{
    public class CachingOrderService : IOrderService
    {
        readonly string OrderCustomerCacheKey = "OrderSet";
        IMemoryCache _cache;
        IOrderService _orderService;

        public CachingOrderService(IOrderService orderService, IMemoryCache memoryCache){
            _orderService = orderService;
            _cache = memoryCache;
        }
        public Task<Order> CompleteOrder(NewOrderInformationBuilder builder)
        {
            _cache.Remove(OrderCustomerCacheKey);
            return _orderService.CompleteOrder(builder);
        }

        public Task<IList<Order>> GetCustomerOrders(int CustomerId)
        {
            return _orderService.GetCustomerOrders(CustomerId);
        }

        public Task<IList<Order>> GetOrdersWithCustomers()
        {
            return _cache.GetOrCreateAsync(OrderCustomerCacheKey,
                (entry) =>  _orderService.GetOrdersWithCustomers());
        }

        public NewOrderInformationBuilder StartOrder(int CustomerId, int SalesPersonId)
        {
            return _orderService.StartOrder(CustomerId, SalesPersonId);
        }
    }
}