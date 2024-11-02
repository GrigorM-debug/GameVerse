using GameVerse.Services.Interfaces;
using GameVerse.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GameVerse.Web.Filters
{
    /// <summary>
    /// An action filter attribute that restricts access to actions for users who are moderators.
    /// </summary>
    /// <remarks>
    /// This attribute checks if the current user is a moderator using the <see cref="IModeratorService"/>.
    /// If the user is a moderator, it prevents access to the action method by returning a 400 Bad Request status.
    /// If the user is not authenticated or if the moderator service is unavailable, it sets the appropriate HTTP status code in the response.
    /// </remarks>
    public class NotModeratorAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Called before the action method is executed. Checks if the current user is a moderator.
        /// </summary>
        /// <param name="context">The <see cref="ActionExecutingContext"/> context for the action.</param>
        /// <remarks>
        /// This method retrieves the <see cref="IModeratorService"/> from the dependency injection container
        /// and verifies the user's moderator status using their unique identifier.
        /// If the moderator service is unavailable, it returns a 500 Internal Server Error.
        /// If the user is not authenticated, it returns a 401 Unauthorized.
        /// If the user is authenticated and is a moderator, it returns a 400 Bad Request.
        /// </remarks>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            IModeratorService? moderatorService = context.HttpContext.RequestServices.GetService<IModeratorService>();

            if (moderatorService == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            string? userId = context.HttpContext.User.GetId();

            if (userId == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
            }

            if (moderatorService != null && moderatorService.ModeratorExistByUserIdAsync(userId).Result)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
        }
    }
}
