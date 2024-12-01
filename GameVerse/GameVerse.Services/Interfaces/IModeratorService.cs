

namespace GameVerse.Services.Interfaces
{
    /// <summary>
    /// Provides functionality for managing moderator-related operations, such as checking existence, 
    /// retrieving IDs, and updating counts for created games and events.
    /// </summary>
    public interface IModeratorService
    {
        /// <summary>
        /// Checks if a moderator exists by the given user ID.
        /// </summary>
        /// <param name="userId">The unique ID of the user.</param>
        /// <returns>
        /// A task containing a <c>true</c> value if the moderator exists; otherwise, <c>false</c>.
        /// </returns>
        Task<bool> ModeratorExistByUserIdAsync(string userId);

        /// <summary>
        /// Retrieves the moderator ID associated with the given user ID.
        /// </summary>
        /// <param name="userId">The unique ID of the user.</param>
        /// <returns>
        /// A task containing the moderator ID if found; otherwise, <c>null</c>.
        /// </returns>
        Task<string?> GetModeratorIdByUserIdAsync(string? userId);

        /// <summary>
        /// Increases the count of total events created by the specified moderator.
        /// </summary>
        /// <param name="moderatorId">The unique ID of the moderator.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task InCreaseCreatedTotalEventsCount(string moderatorId);

        /// <summary>
        /// Increases the count of total games created by the specified moderator.
        /// </summary>
        /// <param name="moderatorId">The unique ID of the moderator.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task IncreaseCreatedTotalGamesCount(string moderatorId);

        /// <summary>
        /// Decreases the count of total games created by the specified moderator.
        /// </summary>
        /// <param name="moderatorId">The unique ID of the moderator.</param>
        /// <param name="isAdmin">Boolean representing if the user is Admin</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DecreaseCreatedTotalGamesCount(string moderatorId, bool isAdmin);

        /// <summary>
        /// Decreases the count of total events created by the specified moderator.
        /// </summary>
        /// <param name="moderatorId">The unique ID of the moderator.</param>
        /// <param name="isAdmin">Boolean representing if the user is Admin</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DecreaseCreatedTotalEventsCount(string moderatorId, bool isAdmin);
    }
}
