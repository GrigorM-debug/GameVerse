using AspNetCoreHero.ToastNotification.Abstractions;
using GameVerse.Services.Interfaces;
using GameVerse.Web.Extensions;
using GameVerse.Web.Filters;
using GameVerse.Web.ViewModels.Game.UserPagesViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameVerse.Web.Controllers
{
    [Authorize]
    [OnlyUsersWithoutRoles]
    public class UserController(
        IUserService _userService,
        INotyfService _notyf
        ) : BaseController
    {
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
