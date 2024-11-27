using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GameVerse.Web.Filters
{
    /// <summary>
    /// A custom authorization attribute that restricts access to users who are authenticated 
    /// but do not have specific roles (e.g., "Moderator" or "Admin").
    /// </summary>
    public class OnlyUsersWithoutRolesAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        /// <summary>
        /// Handles the authorization logic to ensure the user does not have any restricted roles.
        /// </summary>
        /// <param name="context">The authorization filter context for the current HTTP request.</param>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
                return;
            }

            bool isModerator = context.HttpContext.User.IsInRole("Moderator");
            bool isAdmin = context.HttpContext.User.IsInRole("Admin");

            if (isAdmin || isModerator)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
                return;
            }
        }
    }
}
