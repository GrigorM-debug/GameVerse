using GameVerse.Web.Areas.Administrator.Models;

namespace GameVerse.Web.Areas.Administrator.Services.Interfaces
{
    /// <summary>
    /// Provides methods for managing users, moderators, and administrators within the application.
    /// </summary>
    public interface IUserManagementService
    {
        /// <summary>
        /// Retrieves a collection of all users with detailed information asynchronously.
        /// </summary>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation.
        /// The task result contains an <see cref="IEnumerable{T}"/> of <see cref="UserViewModel"/> representing the user details.
        /// </returns>
        Task<IEnumerable<UserViewModel>> GetAllUsersWithDetailsAsync();

        /// <summary>
        /// Checks whether a user exists by their unique identifier asynchronously.
        /// </summary>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation.
        /// The task result contains a <see cref="bool"/> indicating whether the user exists.
        /// </returns>
        Task<bool> UserExistByIdAsync(string userId);

        /// <summary>
        /// Checks whether an administrator exists by their unique identifier asynchronously.
        /// </summary>
        /// <param name="userId">The unique identifier of the administrator.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation.
        /// The task result contains a <see cref="bool"/> indicating whether the administrator exists.
        /// </returns>
        Task<bool> AdministratorExistByIdAsync(string userId);

        /// <summary>
        /// Promotes a user to the role of moderator asynchronously.
        /// </summary>
        /// <param name="userId">The unique identifier of the user to promote.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task PromoteUserToModeratorAsync(string userId);

        /// <summary>
        /// Demotes a moderator to the role of user asynchronously.
        /// </summary>
        /// <param name="userId">The unique identifier of the moderator to demote.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task DemoteModeratorToUserAsync(string userId);

        /// <summary>
        /// Promotes a moderator to the role of administrator asynchronously.
        /// </summary>
        /// <param name="userId">The unique identifier of the moderator to promote.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task PromoteModeratorToAdministratorAsync(string userId);

        /// <summary>
        /// Retrieves the total count of users asynchronously.
        /// </summary>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation.
        /// The task result contains the total number of users as an <see cref="int"/>.
        /// </returns>
        Task<int> GetTotalUsersCountAsync();

        /// <summary>
        /// Retrieves the total count of moderators asynchronously.
        /// </summary>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation.
        /// The task result contains the total number of moderators as an <see cref="int"/>.
        /// </returns>
        Task<int> GetTotalModeratorsCountAsync();

        /// <summary>
        /// Retrieves the total count of administrators asynchronously.
        /// </summary>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation.
        /// The task result contains the total number of administrators as an <see cref="int"/>.
        /// </returns>
        Task<int> GetTotalAdministratorsCountAsync();
    }
}
