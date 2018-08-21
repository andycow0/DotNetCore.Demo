using Demo.WebService.Core.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Demo.WebService.Core.MiddleWares {
    public static class MiddlewareExtension {
        public static IApplicationBuilder UseMyMiddleware (this IApplicationBuilder builder) {
            return builder.UseMiddleware<RequestLogMiddleware> ();
        }
    }
}