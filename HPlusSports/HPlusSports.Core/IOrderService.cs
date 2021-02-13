using System.Collections.Generic;
using System.Threading.Tasks;
using HPlusSports.Models;
using System;
using HPlusSports.DAL;

namespace HPlusSports.Core
{
    public interface IOrderService
    {
        Task<IList<Order>> GetCustomerOrders(int CustomerId);
        Task<IList<Order>> GetOrdersWithCustomers();
        NewOrderInformationBuilder StartOrder(int CustomerId, int SalesPersonId);
        Task<Order> CompleteOrder(NewOrderInformationBuilder builder);
    }
}