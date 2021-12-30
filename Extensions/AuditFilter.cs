using KissLog;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace dotnet_core_identity_basics.Extensions
{
    public class AuditFilter : IActionFilter
    {
        private readonly IKLogger _logger;

        public AuditFilter(IKLogger logger)
        {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if(context.HttpContext.User.Identity.IsAuthenticated)
            {
                var message = context.HttpContext.User.Identity.Name + " Accessed: " +
                              context.HttpContext.Request.GetDisplayUrl();

                _logger.Info(message);
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }
    }
}
