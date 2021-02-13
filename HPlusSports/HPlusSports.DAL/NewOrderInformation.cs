using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HPlusSports.Models;

namespace HPlusSports.DAL
{
    public class NewOrderInformationBuilder
    {
        public int SalesPersonId { get; set; }
        public int CustomerId { get; set; }
        public List<ProductOrderInformation> products { get; set; }

        public Order Build()
        {
            return new Order()
            {
                CustomerId = CustomerId,
                SalespersonId = SalesPersonId,
                Status = "due",
                TotalDue = products.Sum(p => p.Price * p.Quantity),
                CreatedDate = DateTime.Now,
                OrderDate = DateTime.Now,
                OrderItem = products.Select(p =>
                    {
                        return new OrderItem()
                        {
                            ProductId = p.ProductCode,
                            Quantity = p.Quantity
                        };
                    }).ToList()
                  
            };
        }
    }

    public class ProductOrderInformation
    {
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
