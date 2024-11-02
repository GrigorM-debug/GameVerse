using GameVerse.Services;
using GameVerse.Services.Interfaces;
using GameVerse.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GameVerse.Web.Filters
{
    /// <summary>
    /// An action filter attribute that restricts access to actions to users who are moderators.
    /// </summary>
    /// <remarks>
    /// This attribute checks if the current user is a moderator by interacting with the <see cref="IModeratorService"/>.
    /// If the user is not authenticated, is not a moderator, or if the moderator service is unavailable,
    /// it sets the appropriate HTTP status code in the response.
    /// </remarks>
    public class MustBeModeratorAttribute : ActionFilterAttribute
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
        /// If the user is authenticated but is not a moderator, it also returns a 401 Unauthorized.
        /// </remarks>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            //Getting the Moderator Service from Controller Context
            //We are checking which Service is required my the Controller and gets only the ModeratorService
            IModeratorService? moderatorService = context.HttpContext.RequestServices.GetService<IModeratorService>();

            //If Moderator Service is null we return a 500 internal server error
            if (moderatorService == null )
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            string? userId = context.HttpContext.User.GetId();

            //After we get the userId from the Controller Context. Every controller receices Claims Principals
            //With this claims principals we can check if the currect user is Authernticated for example
            //I made ClaimPrincipal Extension class and I added GetId() claim principal 
            //If the user Id is null this means we don't have logged in user, we return 401 Unauthorized Page
            if(userId == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
            }

            //Now after we have the id for currently logged in user
            //We are checking if the user is Moderator by using ModeratorExistByUserIdAsync from Moderator Service
            //The method return true if the user is moderator and false if is not
            //If the user is not Moderator we return 401 Unauthorized Page
            if(moderatorService != null && moderatorService.ModeratorExistByUserIdAsync(userId).Result == false)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
            }

            //If you are reading this and want to see the Custom Error Pages don't forget to change the project environment to Production
            //Because when the project is in Developement Environment I use the Developer Exception Pages.
        }
    }
}
