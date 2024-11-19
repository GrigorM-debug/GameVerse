using System.Globalization;
using AspNetCoreHero.ToastNotification.Abstractions;
using GameVerse.Data.Models.Games;
using GameVerse.Data.Repositories.Interfaces;
using GameVerse.Web.Extensions;
using GameVerse.Web.Filters;
using GameVerse.Web.ViewModels.Game.UserPagesViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using static GameVerse.Common.ApplicationConstants.EventConstants;

namespace GameVerse.Web.Controllers
{
    [Authorize]
    [OnlyUsersWithoutRoles]
    public class UserController(
        IGenericRepository<UserBoughtGame, object> userBoughtGamesRepositoty,
        INotyfService notyf
        ) : BaseController
    {
        private readonly IGenericRepository<UserBoughtGame, object> _userBoughtGames = userBoughtGamesRepositoty;
        private readonly INotyfService _notyf = notyf;

        [HttpGet]
        public async Task<IActionResult> UserBoughtGames()
        {
            string? userId = User.GetId();

            if (userId == null)
            {
                _notyf.Error("You don't have the permission to do this");
                return Unauthorized();
            }

            IEnumerable<UserBoughtGamesViewModel> userBoughtGamesViewModels = await _userBoughtGames
                .GetWithIncludeAsync(g => g.Game)
                .Where(u => u.UserId.ToString() == userId)
                .Select(g => new UserBoughtGamesViewModel()
                {
                    Id = g.GameId.ToString(),
                    BoughtOn = g.BoughtOn.ToString(EventDateTimeFormat, CultureInfo.InvariantCulture),
                    Image = g.Game.Image,
                    Price = (g.Game.Price * g.Quantity).ToString("C"),
                    Quantity = g.Quantity,
                    Title = g.Game.Title,
                    Type = g.Game.Type.ToString(),
                }).ToListAsync();

            return View(userBoughtGamesViewModels);
        }
    }
}
