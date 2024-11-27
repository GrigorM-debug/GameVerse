

using GameVerse.Web.ViewModels.Game.UserPagesViewModels;

namespace GameVerse.Services.Interfaces
{
    /// <summary>
    /// Provides functionality for retrieving user-specific data, such as purchased games and event registrations.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Retrieves the list of games purchased by the specified user.
        /// </summary>
        /// <param name="userId">The unique ID of the user.</param>
        /// <returns>
        /// A task containing a collection of <see cref="UserBoughtGamesViewModel"/> representing the user's purchased games.
        /// </returns>
        Task<IEnumerable<UserBoughtGamesViewModel>> GetUserBoughtGamesAsync(string userId);

        /// <summary>
        /// Retrieves the list of event registrations for the specified user.
        /// </summary>
        /// <param name="userId">The unique ID of the user.</param>
        /// <returns>
        /// A task containing a collection of <see cref="UserEventRegistrationsViewModel"/> representing the user's event registrations.
        /// </returns>
        Task<IEnumerable<UserEventRegistrationsViewModel>> GetUserEventRegistrationsAsync(string userId);
    }
}
