using HPlusSports.DAL;
using HPlusSports.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HPlusSports.Core
{
    public class OrderService : IOrderService
    {
        IOrderRepository _orderRepo;
        HPlusSportsContext _context;
        public delegate void OrderCreatedEvent(int userId); 
        public event OrderCreatedEvent OrderCreated; 
 
        public OrderService(IOrderRepository orderRepo, 
                            HPlusSportsContext context) 
        {
            _orderRepo = orderRepo;
            _context = context;
        }

        public async Task<IList<Order>> GetCustomerOrders(int CustomerId)
        {
            return await _context.Set<Order>()
                .AsNoTracking()
                .Include(o => o.Customer)
                .Where(o => o.CustomerId == CustomerId)
                .ToListAsync();
        }

        public async Task<IList<Order>> GetOrdersWithCustomers()
        {
            return await _context.Set<Order>()
                .AsNoTracking()
                .Include(o => o.Customer)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();
        }

        private decimal GetPriceWithDiscounts(string productCode, int quantity)
        {
            var product = _context.Set<Product>().First(p => p.ProductCode == productCode);
            if (product.Price > 10 && quantity > 100)
                return (product.Price ?? 1) * 0.95m;
            else
                return product.Price ?? 1;

        }

        public NewOrderInformationBuilder StartOrder(int CustomerId, int SalesPersonId)
        {
            var builder = new NewOrderInformationBuilder();
            builder.CustomerId = CustomerId;
            builder.SalesPersonId = SalesPersonId;
            return builder;
        }

        public async Task<Order> CompleteOrder(NewOrderInformationBuilder builder)
        {
            builder.products.ForEach(p => p.Price = GetPriceWithDiscounts(p.ProductCode, p.Quantity));
            var order = _orderRepo.Create(builder);

            await _context.SaveChangesAsync();
            OrderCreated?.Invoke(order.CustomerId);
            return order;
        }
    }
}
