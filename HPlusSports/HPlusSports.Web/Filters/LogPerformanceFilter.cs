using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HPlusSports.Filters
{
    public class LogPerformanceFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var resultContext = await next();

            stopWatch.Stop();

            Console.WriteLine
                ($"Executed {resultContext.ActionDescriptor.DisplayName} in {stopWatch.ElapsedMilliseconds} ms");
        }
    }
}