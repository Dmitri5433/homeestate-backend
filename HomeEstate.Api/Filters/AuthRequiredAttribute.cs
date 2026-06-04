using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using HomeEstate.DataAccess.Context;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace HomeEstate.Api.Filters
{
    public class AuthRequiredAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var db = context.HttpContext.RequestServices.GetService<DbSession>();
            var token = context.HttpContext.Request.Cookies["session_token"];

            if (string.IsNullOrEmpty(token))
            {
                context.Result = new UnauthorizedObjectResult(new { Message = "Требуется авторизация. Войдите в аккаунт." });
                return;
            }

            var user = db?.UserData.FirstOrDefault(u => u.SessionToken == token);
            if (user == null)
            {
                context.Result = new UnauthorizedObjectResult(new { Message = "Сессия устарела. Войдите снова." });
                return;
            }

            // Передаём userId в HttpContext.Items для использования в контроллере
            context.HttpContext.Items["UserId"] = user.Id;

            base.OnActionExecuting(context);
        }
    }
}
