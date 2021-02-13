using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HPlusSports.Models;

namespace HPlusSports.DAL
{
    public class NewOrderInformationBuilder
    {
        int salesPersonId; 
        int customerId; 
        List<ProductOrderInformation> products = new List<ProductOrderInformation>(); 
        Func<string, int, decimal> priceEvaluator; 
 
        public NewOrderInformationBuilder ForUser(int CustomerId){ 
            customerId = CustomerId; 
            return this; 
        } 
 
        public NewOrderInformationBuilder SoldBy(int SalesPersonId){ 
            salesPersonId = SalesPersonId; 
            return this; 
        } 
 
        public NewOrderInformationBuilder OrderProduct(ProductOrderInformation product) 
        { 
            products.Add(product); 
            return this; 
        } 
 
        public NewOrderInformationBuilder ConfigurePricing(Func<string, int, decimal> PriceEvaluator){ 
            priceEvaluator = PriceEvaluator; 
            return this; 
        }         public Order Build()
        {
            return new Order()
            {
                CustomerId = customerId,
                SalespersonId = salesPersonId,
                Status = "due",
                TotalDue = products.Sum(p => priceEvaluator(p.ProductCode, p.Quantity) * p.Quantity), 
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
