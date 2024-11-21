

using GameVerse.Data.Models.Events;
using GameVerse.Data.Models.Games;
using GameVerse.Data.Repositories.Interfaces;
using GameVerse.Services.Interfaces;
using GameVerse.Web.ViewModels.Game.UserPagesViewModels;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using static GameVerse.Common.ApplicationConstants.EventConstants;

namespace GameVerse.Services
{
    public class UserService(
        IGenericRepository<UserBoughtGame, object> userBoughtGamesRepository,
        IGenericRepository<EventRegistration, object> eventRegistrationsRepository
        ) : IUserService
    {
        private readonly IGenericRepository<UserBoughtGame, object> _userBoughtGames = userBoughtGamesRepository;
        private readonly IGenericRepository<EventRegistration, object> _eventRegistrationsRepository = eventRegistrationsRepository;

        public async Task<IEnumerable<UserBoughtGamesViewModel>> GetUserBoughtGamesAsync(string userId)
        {
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

            return userBoughtGamesViewModels;
        }

        public async Task<IEnumerable<UserEventRegistrationsViewModel>> GetUserEventRegistrationsAsync(string userId)
        {
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
                        EventStartDate = e.Event.StartDate.ToString(EventDateTimeFormat, CultureInfo.InvariantCulture),
                        EventEndDate = e.Event.EndDate.ToString(EventDateTimeFormat, CultureInfo.InvariantCulture),
                        Longitude = e.Event.Longitude,
                        Latitude = e.Event.Latitude
                    }).ToListAsync();

            return eventRegistrationsViewModels;
        }
    }
}
