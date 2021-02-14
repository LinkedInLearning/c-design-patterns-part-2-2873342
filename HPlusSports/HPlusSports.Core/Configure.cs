using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HPlusSports.Core
{
    public static class Configure
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddTransient<IOrderService, OrderService>((serviceProvider) =>  
            { 
                var os = new OrderService(  
                    serviceProvider.GetService<DAL.IOrderRepository>(), 
                    serviceProvider.GetService<DAL.HPlusSportsContext>()); 
                 
                os.OrderCreated += serviceProvider.GetService<IUserNotifier>().NotifyUser; 
 
                return os; 
            }); 
            services.AddTransient<ISimpleCachingOrderService, SimpleCachingOrderService>(); 
 
            services.AddTransient<ISalesPersonService, SalesPersonService>();

            services.AddTransient<IUserNotifier>((IServiceProvider serviceProvider) =>
            {
                var configuration = serviceProvider.GetService<IConfiguration>();
                if (configuration.GetValue<bool>("UseTestUserNotifier"))
                    return new TestUserNotifier();
                else
                    return new EmailUserNotifier();
            });
        }
    }
}
