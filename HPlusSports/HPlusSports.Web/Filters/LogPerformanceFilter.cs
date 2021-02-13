using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace HPlusSports.Core.Filters
{
    public class LogPerformanceFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var resultContext = await next();
            
            stopWatch.Stop();
            Console.WriteLine($"Exectuted {resultContext.ActionDescriptor.DisplayName} in {stopWatch.ElapsedMilliseconds} ms");
        }
    }
}