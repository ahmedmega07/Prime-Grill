using System.Diagnostics;

namespace Restaurant.API.Middlewares
{
    public class RequestTimeLoggingMiddleware(ILogger<RequestTimeLoggingMiddleware> logger) : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var watch = Stopwatch.StartNew();
            await next.Invoke(context);
            watch.Stop();

            if (watch.ElapsedMilliseconds / 1000 > 4)
            {
                logger.LogInformation("Request [ {Verb} at {Path} took {Time} ms ]", context.Request.Method, context.Request.Path, watch.ElapsedMilliseconds);
            }

        }
    }

}