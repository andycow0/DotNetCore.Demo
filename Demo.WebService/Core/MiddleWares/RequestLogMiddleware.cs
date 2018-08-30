using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Demo.WebService.Core.Middlewares
{
    public class RequestLogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLogMiddleware> _logger;
        public RequestLogMiddleware (ILogger<RequestLogMiddleware> logger, RequestDelegate next) {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {

            //await context.Response.WriteAsync ("RequestLog request in.");
            this._logger.LogInformation ("RequestLog Middle test !");

            Console.WriteLine("RequestLog test !");
            
            // context.Request.Headers.Add("test-header","test1234");
            context.Response.OnStarting(state =>
            {
                var httpContext = (HttpContext)state;
                httpContext.Response.Headers.Add("X-Response-Time-Milliseconds", new[] { "test1234" });
                return Task.FromResult(0);
            }, context);

            await _next.Invoke(context);
            // string response = GenerateResponse (context);
            // context.Response.ContentType = GetContentType ();
            //await context.Response.WriteAsync ("RequestLog request out.");
        }
        private string GenerateResponse(HttpContext context)
        {
            string title = context.Request.Query["title"];
            return string.Format("Title of the report: {0}", title);
        }

        private string GetContentType()
        {
            return "text/plain";
        }
    }
}