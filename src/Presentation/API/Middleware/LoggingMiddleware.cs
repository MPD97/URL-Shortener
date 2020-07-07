using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;

namespace API.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;
        private readonly Stopwatch _stopwatch = new Stopwatch();

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            _stopwatch.Start();

            await _next.Invoke(context);

            _stopwatch.Stop();

            var time= _stopwatch.ElapsedMilliseconds;
            _logger.LogInformation($"{context.Request.QueryString} - {time} milliseconds.");
            _stopwatch.Reset();
        }
    }
}