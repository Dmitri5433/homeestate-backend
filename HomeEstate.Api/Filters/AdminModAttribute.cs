using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using HomeEstate.DataAccess.Context;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace HomeEstate.Api.Filters
{
    public class AdminModAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var db = context.HttpContext.RequestServices.GetService<DbSession>();
            var token = context.HttpContext.Request.Cookies["session_token"];

            if (string.IsNullOrEmpty(token))
            {
                context.Result = new UnauthorizedObjectResult(new { Message = "Access denied. Guests cannot perform this action." });
                return;
            }

            var user = db?.UserData.FirstOrDefault(u => u.SessionToken == token);

            if (user == null)
            {
                context.Result = new UnauthorizedObjectResult(new { Message = "Access denied. Invalid or expired session." });
                return;
            }

            if (user.Role != "Admin")
            {
                context.Result = new ObjectResult(new { Message = "Access denied. Administrator privileges required." })
                {
                    StatusCode = 403
                };
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}
