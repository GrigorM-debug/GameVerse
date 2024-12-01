

using GameVerse.Data.Models.ApplicationUsers;
using GameVerse.Data.Models.Events;
using GameVerse.Data.Repositories.Interfaces;
using GameVerse.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameVerse.Services
{
    /// <summary>
    /// Provides services for managing moderators, including checking their existence, 
    /// retrieving IDs, and updating counts for created games and events.
    /// </summary>
    public class ModeratorService(IGenericRepository<Moderator, Guid> moderatorRepository) : IModeratorService
    {
        private readonly IGenericRepository<Moderator, Guid> _moderatorRepository = moderatorRepository;

        /// <summary>
        /// Retrieves the moderator ID associated with the specified user ID.
        /// </summary>
        /// <param name="userId">The unique ID of the user.</param>
        /// <returns>
        /// A task containing the moderator ID if found; otherwise, <c>null</c>.
        /// </returns>
        public async Task<string?> GetModeratorIdByUserIdAsync(string? userId)
        {
            Moderator? moderator = await _moderatorRepository
                .AllAsReadOnly()
                .FirstOrDefaultAsync(m => m.UserId.ToString() == userId);

            if (moderator == null)
            {
                return null;
            }

            return moderator.Id.ToString();
        }

        /// <summary>
        /// Increases the total number of events created by the specified moderator.
        /// </summary>
        /// <param name="moderatorId">The unique ID of the moderator.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task InCreaseCreatedTotalEventsCount(string moderatorId)
        {
            Moderator? moderator = await _moderatorRepository
                .FirstOrDefaultAsync(m => m.Id.ToString() == moderatorId);

            if (moderator != null)
            {
                moderator.TotalEventsCreated += 1;

                await _moderatorRepository.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Increases the total number of games created by the specified moderator.
        /// </summary>
        /// <param name="moderatorId">The unique ID of the moderator.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task IncreaseCreatedTotalGamesCount(string moderatorId)
        {
            Moderator? moderator = await _moderatorRepository
                .FirstOrDefaultAsync(m => m.Id.ToString() == moderatorId);

            if (moderator != null)
            {
                moderator.TotalGamesCreated += 1;

                await _moderatorRepository.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Decreases the total number of games created by the specified moderator.
        /// </summary>
        /// <param name="moderatorId">The unique ID of the moderator.</param>
        /// <param name="isAdmin">Boolean representing if the user is Admin</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task DecreaseCreatedTotalGamesCount(string moderatorId, bool isAdmin)
        {
            Moderator? moderator = await _moderatorRepository
                .FirstOrDefaultAsync(m => (m.Id.ToString() == moderatorId || isAdmin));

            if (moderator != null)
            {
                moderator.TotalGamesCreated -= 1;

                await _moderatorRepository.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Decreases the total number of events created by the specified moderator.
        /// </summary>
        /// <param name="moderatorId">The unique ID of the moderator.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <param name="isAdmin">Boolean representing if the user is Admin</param>
        public async Task DecreaseCreatedTotalEventsCount(string moderatorId, bool isAdmin)
        {
            Moderator? moderator = await _moderatorRepository
                .FirstOrDefaultAsync(m => (m.Id.ToString() == moderatorId || isAdmin));

            if (moderator != null)
            {
                moderator.TotalEventsCreated -= 1;

                await _moderatorRepository.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Checks if a moderator exists for the specified user ID.
        /// </summary>
        /// <param name="userId">The unique ID of the user.</param>
        /// <returns>
        /// A task containing a <c>true</c> value if the moderator exists; otherwise, <c>false</c>.
        /// </returns>
        public async Task<bool> ModeratorExistByUserIdAsync(string userId)
        {
            Moderator? moderator = await _moderatorRepository
                .AllAsReadOnly()
                .FirstOrDefaultAsync(m => m.UserId.ToString() == userId);

            if (moderator == null)
            {
                return false;
            }

            return true;
        }

    }
}
