using GameVerse.Services;
using GameVerse.Services.Interfaces;
using GameVerse.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GameVerse.Web.Filters
{
    public class MustBeModerator : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            IModeratorService? moderatorService = context.HttpContext.RequestServices.GetService<IModeratorService>();

            if (moderatorService == null )
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            string? userId = context.HttpContext.User.GetId();

            if(userId == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
            }

            if(moderatorService != null && moderatorService.ModeratorExistByUserIdAsync(userId).Result == false)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
            }
        }
    }
}
