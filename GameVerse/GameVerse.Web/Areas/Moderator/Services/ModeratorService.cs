using System.Globalization;
using GameVerse.Data.Models.ApplicationUsers;
using GameVerse.Data.Repositories.Interfaces;
using GameVerse.Web.Areas.Moderator.Models;
using GameVerse.Web.Areas.Moderator.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using static GameVerse.Common.ApplicationConstants;
using static GameVerse.Common.ApplicationConstants.EventConstants;

namespace GameVerse.Web.Areas.Moderator.Services
{
    /// <summary>
    /// Provides functionality for retrieving and managing information about games and events created by moderators.
    /// </summary>
    public class ModeratorService(
        IGenericRepository<Data.Models.ApplicationUsers.Moderator, Guid> moderatorRepository
        ) : IModeratorService
    {
        private readonly IGenericRepository<Data.Models.ApplicationUsers.Moderator, Guid> _moderatorRepository = moderatorRepository;

        /// <summary>
        /// Retrieves the last 5 events created by the specified moderator.
        /// </summary>
        /// <param name="userId">The unique ID of the moderator.</param>
        /// <returns>
        /// A task containing a collection of <see cref="ModeratorEventIndexViewModel"/> 
        /// representing the last 5 events created by the moderator.
        /// </returns>
        public async Task<IEnumerable<ModeratorEventIndexViewModel>> GetLast5CreatedEventsAsync(string userId)
        {
            IEnumerable<ModeratorEventIndexViewModel> moderatorLast5CreatedEvents = await _moderatorRepository
                .AllAsReadOnly()
                .Where(m => m.UserId.ToString() == userId)
                .Include(m => m.OwnedEvents)
                .SelectMany(m => m.OwnedEvents)
                .Where(e => e.IsDeleted == false)
                .OrderByDescending(e => e.Id)
                .Take(5)
                .Select(e => new ModeratorEventIndexViewModel()
                {
                    Id = e.Id.ToString(),
                    Topic = e.Topic,
                    StartDate = e.StartDate.ToString(EventDateTimeFormat, CultureInfo.InvariantCulture),
                    EndDate = e.EndDate.ToString(EventDateTimeFormat, CultureInfo.InvariantCulture),
                    Seats = e.Seats,
                    TicketPrice = e.TicketPrice.ToString("C")
                }).ToListAsync();

            return moderatorLast5CreatedEvents;
        }

        /// <summary>
        /// Retrieves the total number of games created by the specified moderator.
        /// </summary>
        /// <param name="userId">The unique ID of the moderator.</param>
        /// <returns>
        /// A task containing the total count of games created by the moderator.
        /// </returns>
        public async Task<int> TotalGamesCreatedAsync(string userId)
        {
            int totalGamesCreatedCount = await _moderatorRepository
                .AllAsReadOnly()
                .Where(m => m.UserId.ToString() == userId)
                .Select(m => m.TotalGamesCreated)
                .FirstOrDefaultAsync();

            return totalGamesCreatedCount;
        }

        /// <summary>
        /// Retrieves the total number of events created by the specified moderator.
        /// </summary>
        /// <param name="userId">The unique ID of the moderator.</param>
        /// <returns>
        /// A task containing the total count of events created by the moderator.
        /// </returns>
        public async Task<int> TotalEventsCreatedAsync(string userId)
        {
            int totalEventsCreated = await _moderatorRepository
                .AllAsReadOnly()
                .Where(m => m.UserId.ToString() == userId)
                .Select(m => m.TotalEventsCreated)
                .FirstOrDefaultAsync();

            return totalEventsCreated;
        }

        /// <summary>
        /// Retrieves the last 5 games created by the specified moderator.
        /// </summary>
        /// <param name="userId">The unique ID of the moderator.</param>
        /// <returns>
        /// A task containing a collection of <see cref="ModeratorGameIndexViewModel"/> 
        /// representing the last 5 games created by the moderator.
        /// </returns>
        public async Task<IEnumerable<ModeratorGameIndexViewModel>> GetLast5CreatedGamesAsync(string userId)
        {
            IEnumerable<ModeratorGameIndexViewModel> moderatorsLast5CreatedGames = await _moderatorRepository
                .AllAsReadOnly()
                .Where(m => m.UserId.ToString() == userId)
                .Include(m => m.OwnedGames)
                .SelectMany(m => m.OwnedGames)
                .Where(g => g.IsDeleted == false)
                .OrderByDescending (g => g.CreatedOn)
                .Take(5)
                .Select (g => new ModeratorGameIndexViewModel()
                {
                    Id= g.Id.ToString(),
                    Title = g.Title,
                    CreatedOn = g.CreatedOn.ToString(DateTimeFormat, CultureInfo.InvariantCulture),
                    Price = g.Price.ToString("C"),
                    QuantityInStock = g.QuantityInStock,
                }).ToListAsync();

            return moderatorsLast5CreatedGames;
        }
    }
}
