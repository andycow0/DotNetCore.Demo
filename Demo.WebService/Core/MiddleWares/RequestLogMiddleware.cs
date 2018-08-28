using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Demo.WebService.Core.Middlewares
{
    public class RequestLogMiddleware
    {
        private readonly RequestDelegate _next;
        public RequestLogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {

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
            // await context.Response.WriteAsync (response);
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