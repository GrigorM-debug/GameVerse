using GameVerse.Services;
using GameVerse.Services.Interfaces;
using GameVerse.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

//Mark!! - This class is currently not used in the project. I made it and used it when I didn't have Areas yet. 
//I wanted to see how Actions filters works
namespace GameVerse.Web.Filters
{
    /// <summary>
    /// An action filter attribute that restricts access to actions to users who are moderators.
    /// </summary>
    /// <remarks>
    /// This attribute checks if the current user is a moderator by interacting with the UserClaimsPrincipals that controller receives.
    /// If the user is not authenticated or is not a moderator,
    /// it sets the appropriate HTTP status code in the response.
    /// </remarks>
    public class MustBeModeratorAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Called before the action method is executed. Checks if the current user is a moderator.
        /// </summary>
        /// <param name="context">The <see cref="ActionExecutingContext"/> context for the action.</param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);


            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
                return;
            }

            bool isModerator = context.HttpContext.User.IsInRole("Moderator");

            // If the user is not a moderator, return 401 Unauthorized
            if (!isModerator)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
                return;
            }
        }
    }
}
