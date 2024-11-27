using GameVerse.Web.Areas.Moderator.Models;

namespace GameVerse.Web.Areas.Moderator.Services.Interfaces
{
    /// <summary>
    /// Provides functionality for moderators to manage and retrieve information about games and events they have created.
    /// </summary>
    public interface IModeratorService
    {
        /// <summary>
        /// Retrieves the last 5 games created by the specified moderator.
        /// </summary>
        /// <param name="userId">The unique ID of the moderator.</param>
        /// <returns>
        /// A task containing a collection of <see cref="ModeratorGameIndexViewModel"/> 
        /// representing the last 5 games created by the moderator.
        /// </returns>
        Task<IEnumerable<ModeratorGameIndexViewModel>> GetLast5CreatedGamesAsync(string userId);

        /// <summary>
        /// Retrieves the last 5 events created by the specified moderator.
        /// </summary>
        /// <param name="userId">The unique ID of the moderator.</param>
        /// <returns>
        /// A task containing a collection of <see cref="ModeratorEventIndexViewModel"/> 
        /// representing the last 5 events created by the moderator.
        /// </returns>
        Task<IEnumerable<ModeratorEventIndexViewModel>> GetLast5CreatedEventsAsync(string userId);

        /// <summary>
        /// Retrieves the total number of games created by the specified moderator.
        /// </summary>
        /// <param name="userId">The unique ID of the moderator.</param>
        /// <returns>
        /// A task containing the total count of games created by the moderator.
        /// </returns>
        Task<int> TotalGamesCreatedAsync(string userId);

        /// <summary>
        /// Retrieves the total number of events created by the specified moderator.
        /// </summary>
        /// <param name="userId">The unique ID of the moderator.</param>
        /// <returns>
        /// A task containing the total count of events created by the moderator.
        /// </returns>
        Task<int> TotalEventsCreatedAsync(string userId);
    }
}
