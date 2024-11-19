using System.Globalization;
using AspNetCoreHero.ToastNotification.Abstractions;
using GameVerse.Data.Models.Events;
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
        IGenericRepository<UserBoughtGame, object> userBoughtGamesRepository,
        IGenericRepository<EventRegistration, object> eventRegistrationsRepository,
        INotyfService notyf
        ) : BaseController
    {
        private readonly IGenericRepository<UserBoughtGame, object> _userBoughtGames = userBoughtGamesRepository;
        private readonly IGenericRepository<EventRegistration, object> _eventRegistrationsRepository = eventRegistrationsRepository;
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
                    GameId = g.GameId.ToString(),
                    BoughtOn = g.BoughtOn.ToString(EventDateTimeFormat, CultureInfo.InvariantCulture),
                    Image = g.Game.Image,
                    Price = (g.Game.Price * g.Quantity).ToString("C"),
                    Quantity = g.Quantity,
                    Title = g.Game.Title,
                    Type = g.Game.Type.ToString(),
                }).ToListAsync();

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
                await _eventRegistrationsRepository
                    .GetWithIncludeAsync(e => e.Event)
                    .Where(u => u.UserId.ToString() == userId)
                    .Select(e => new UserEventRegistrationsViewModel()
                    {
                        EventId = e.EventId.ToString(),
                        Topic = e.Event.Topic,
                        Image = e.Event.Image,
                        RegistrationDate =
                            e.RegistrationDate.ToString(EventDateTimeFormat, CultureInfo.InvariantCulture),
                        TicketQuantity = e.TicketQuantity,
                        Price = (e.TicketQuantity * e.Event.TicketPrice).ToString("C"),
                    }).ToListAsync();

            return View(eventRegistrationsViewModels);
        }
    }
}
