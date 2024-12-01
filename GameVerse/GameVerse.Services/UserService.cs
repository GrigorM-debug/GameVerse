

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
    /// <summary>
    /// Provides services for retrieving user-specific data, including purchased games and event registrations.
    /// </summary>
    public class UserService(
        IGenericRepository<UserBoughtGame, object> _userBoughtGamesRepository,
        IGenericRepository<EventRegistration, object> _eventRegistrationsRepository
        ) : IUserService
    {
        /// <summary>
        /// Retrieves the list of games purchased by the specified user.
        /// </summary>
        /// <param name="userId">The unique ID of the user.</param>
        /// <returns>
        /// A task containing a collection of <see cref="UserBoughtGamesViewModel"/> 
        /// representing the user's purchased games.
        /// </returns>
        public async Task<IEnumerable<UserBoughtGamesViewModel>> GetUserBoughtGamesAsync(string userId)
        {
            IEnumerable<UserBoughtGamesViewModel> userBoughtGamesViewModels = await _userBoughtGamesRepository
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

        /// <summary>
        /// Retrieves the list of event registrations for the specified user.
        /// </summary>
        /// <param name="userId">The unique ID of the user.</param>
        /// <returns>
        /// A task containing a collection of <see cref="UserEventRegistrationsViewModel"/> 
        /// representing the user's event registrations.
        /// </returns>
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
                        QrCodeAsBase64String = e.QrCode
                    }).ToListAsync();

            return eventRegistrationsViewModels;
        }
    }
}
