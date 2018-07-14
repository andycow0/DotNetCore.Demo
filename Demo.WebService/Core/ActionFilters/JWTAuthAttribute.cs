using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;

namespace Demo.WebService.Core.ActionFilters
{
    public class JWTAuthAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            // TODO: key應該移至config
            // var secret = "wellwindJtwDemo";

            // if (actionContext.HttpContext.Request.Headers.Authorization == null || actionContext.Request.Headers.Authorization.Scheme != "Bearer")
            // {
            //     setErrorResponse(actionContext, "驗證錯誤");
            // }
            // else
            // {
            //     try
            //     {
            //         var jwtObject = Jose.JWT.Decode<JwtAuthObject>(
            //             actionContext.Request.Headers.Authorization.Parameter,
            //             Encoding.UTF8.GetBytes(secret),
            //             JwsAlgorithm.HS256);
            //     }
            //     catch (Exception ex)
            //     {
            //         setErrorResponse(actionContext, ex.Message);
            //     }
            // }

            // base.OnActionExecuting(actionContext);

        }
    }
}