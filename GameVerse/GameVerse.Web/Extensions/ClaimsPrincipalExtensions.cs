using System.Security.Claims;

namespace GameVerse.Web.Extensions
{
    /// <summary>
    /// Provides extension methods for the <see cref="ClaimsPrincipal"/> class to retrieve user-specific information.
    /// </summary>
    public static class ClaimsPrincipalExtensions 
    {
        /// <summary>
        /// Retrieves the unique identifier (ID) of the current user.
        /// </summary>
        /// <param name="user">The <see cref="ClaimsPrincipal"/> instance representing the current user.</param>
        /// <returns>The ID of the user as a string if found; otherwise, <c>null</c>.</returns>
        public static string? GetId(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        /// <summary>
        /// Checks if the current user has the "Admin" role.
        /// </summary>
        /// <param name="user">The <see cref="ClaimsPrincipal"/> instance representing the current user.</param>
        /// <returns><c>true</c> if the user is in the "Admin" role; otherwise, <c>false</c>.</returns>
        public static bool IsAdmin(this ClaimsPrincipal user)
        {
            return user.IsInRole("Admin");
        }
    }
}
