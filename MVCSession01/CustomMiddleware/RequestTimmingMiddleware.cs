using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MVCSession01.CustomMiddleware
{
    public class RequestTimmingMiddleware
    {
        private readonly RequestDelegate _next;
        public RequestTimmingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var watch = Stopwatch.StartNew();
            await _next(context);
            watch.Stop();
            Console.WriteLine($"{context.Request.Path}:" +
                $"{watch.ElapsedMilliseconds}ms");
        }
    }
}