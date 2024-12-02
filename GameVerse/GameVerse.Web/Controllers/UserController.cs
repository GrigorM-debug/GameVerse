using AspNetCoreHero.ToastNotification.Abstractions;
using GameVerse.Services.Interfaces;
using GameVerse.Web.Extensions;
using GameVerse.Web.Filters;
using GameVerse.Web.ViewModels.Game.UserPagesViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameVerse.Web.Controllers
{
    /// <summary>
    /// Handles user-specific actions, such as viewing purchased games and event registrations.
    /// </summary>
    [Authorize]
    [OnlyUsersWithoutRoles]
    public class UserController(
        IUserService _userService,
        INotyfService _notyf
        ) : BaseController
    {
        /// <summary>
        /// Displays a list of games that the user has purchased.
        /// </summary>
        /// <returns>The view displaying the user's purchased games or an appropriate error response.</returns>
        [HttpGet]
        public async Task<IActionResult> UserBoughtGames()
        {
            string? userId = User.GetId();

            if (userId == null)
            {
                _notyf.Error("You don't have the permission to do this");
                return Unauthorized();
            }

            IEnumerable<UserBoughtGamesViewModel> userBoughtGamesViewModels =
                await _userService.GetUserBoughtGamesAsync(userId);

            return View(userBoughtGamesViewModels);
        }

        /// <summary>
        /// Displays a list of events the user has registered for.
        /// </summary>
        /// <returns>The view displaying the user's event registrations or an appropriate error response.</returns>
        [HttpGet]
        public async Task<IActionResult> UserEventRegistrations()
        {
            string? userId = User.GetId();

            if (userId == null)
            {
                _notyf.Error("You don't have the permission to do this");
                return Unauthorized();
            }

            IEnumerable<UserEventRegistrationsViewModel> eventRegistrationsViewModels =
                await _userService.GetUserEventRegistrationsAsync(userId);

            return View(eventRegistrationsViewModels);
        }
    }
}
