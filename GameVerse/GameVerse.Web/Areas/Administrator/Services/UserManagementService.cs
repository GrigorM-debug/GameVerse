using GameVerse.Data.Models.ApplicationUsers;
using GameVerse.Data.Repositories.Interfaces;
using GameVerse.Web.Areas.Administrator.Models;
using GameVerse.Web.Areas.Administrator.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GameVerse.Web.Areas.Administrator.Services
{
    /// <summary>
    /// Service for managing user roles and retrieving user details, including administrators and moderators.
    /// </summary>
    public class UserManagementService(
        UserManager<ApplicationUser> _userManager,
        IGenericRepository<ApplicationUser, Guid> _userRepository,
        IGenericRepository<Data.Models.ApplicationUsers.Moderator, Guid> _moderatorRepository)
        : IUserManagementService
    {
        /// <summary>
        /// Retrieves a collection of all users with detailed information asynchronously.
        /// </summary>
        /// <returns>
        /// A <see cref="Task{TResult}"/> containing a collection of <see cref="UserViewModel"/> objects.
        /// </returns>
        public async Task<IEnumerable<UserViewModel>> GetAllUsersWithDetailsAsync()
        {
            IEnumerable<ApplicationUser> users = await _userManager.Users.ToListAsync();

            List<UserViewModel> userViewModels = new List<UserViewModel>();

            foreach (ApplicationUser user in users)
            {
                IEnumerable<string> roles = await _userManager.GetRolesAsync(user);

                Data.Models.ApplicationUsers.Moderator? moderator =
                    await _moderatorRepository
                        .AllAsReadOnly()
                        .FirstOrDefaultAsync(m => m.UserId == user.Id);

                userViewModels.Add(new UserViewModel()
                {
                    Id = user.Id.ToString(),
                    Email = user.Email,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Roles = roles.ToList(),
                    TotalGamesCreated = moderator?.TotalGamesCreated ?? 0,
                    TotalEventsCreated = moderator?.TotalEventsCreated ?? 0,
                });
            }

            return userViewModels;
        }

        /// <summary>
        /// Checks whether a user exists by their unique identifier asynchronously.
        /// </summary>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <returns>
        /// <c>true</c> if the user exists; otherwise, <c>false</c>.
        /// </returns>
        public async Task<bool> UserExistByIdAsync(string userId)
        {
            ApplicationUser? user = await  _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks whether an administrator exists by their unique identifier asynchronously.
        /// </summary>
        /// <param name="userId">The unique identifier of the administrator.</param>
        /// <returns>
        /// <c>true</c> if the user is an administrator; otherwise, <c>false</c>.
        /// </returns>
        public async Task<bool> AdministratorExistByIdAsync(string userId)
        {
            ApplicationUser? user = await _userManager.FindByIdAsync(userId);

            bool isAlreadyInRole = await _userManager.IsInRoleAsync(user, "Admin");

            if (user == null && !isAlreadyInRole)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Promotes a user to the role of moderator asynchronously.
        /// </summary>
        /// <param name="userId">The unique identifier of the user to promote.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task PromoteUserToModeratorAsync(string userId)
        {
            ApplicationUser? user = await _userManager.FindByIdAsync(userId);

            if (user != null)
            {
                bool alreadyInRole = await _userManager.IsInRoleAsync(user, "Moderator");
                Data.Models.ApplicationUsers.Moderator? moderator =
                    await _moderatorRepository.FirstOrDefaultAsync(m => m.UserId.ToString() == userId);

                if (!alreadyInRole)
                {
                    await _userManager.AddToRoleAsync(user, "Moderator");

                    if (moderator != null)
                    {
                        if (!moderator.IsActive)
                        {
                            moderator.IsActive = true;
                            await _moderatorRepository.SaveChangesAsync();
                        }
                    }
                    else
                    {
                        Data.Models.ApplicationUsers.Moderator newModerator = new Data.Models.ApplicationUsers.Moderator()
                        {
                            UserId = Guid.Parse(userId),
                            TotalEventsCreated = 0,
                            TotalGamesCreated = 0,
                            IsActive = true
                        };

                        await _moderatorRepository.AddAsync(newModerator);
                        await _moderatorRepository.SaveChangesAsync();
                    }
                }
            }
        }

        /// <summary>
        /// Demotes a moderator to a regular user asynchronously.
        /// </summary>
        /// <param name="userId">The unique identifier of the moderator to demote.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task DemoteModeratorToUserAsync(string userId)
        {
            ApplicationUser? user = await _userManager.FindByIdAsync(userId);

            if (user != null)
            {
                await _userManager.RemoveFromRoleAsync(user, "Moderator");

                Data.Models.ApplicationUsers.Moderator? moderator =
                    await _moderatorRepository.FirstOrDefaultAsync(m => m.UserId.ToString() == userId && m.IsActive == true);

                if (moderator != null)
                {
                    moderator.IsActive = false;
                    await _moderatorRepository.SaveChangesAsync();
                }
            }
        }

        /// <summary>
        /// Promotes a moderator to the role of administrator asynchronously.
        /// </summary>
        /// <param name="userId">The unique identifier of the moderator to promote.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task PromoteModeratorToAdministratorAsync(string userId)
        {
            ApplicationUser? user = await _userManager.FindByIdAsync(userId);

            if (user != null)
            {
                if (await _userManager.IsInRoleAsync(user, "Moderator"))
                {
                    await _userManager.RemoveFromRoleAsync(user, "Moderator");
                }

                await _userManager.AddToRoleAsync(user, "Admin");

                Data.Models.ApplicationUsers.Moderator? moderator =
                    await _moderatorRepository.FirstOrDefaultAsync(m => m.UserId.ToString() == userId && m.IsActive == true);

                if (moderator != null)
                {
                    moderator.IsActive = false;
                    await _moderatorRepository.SaveChangesAsync();
                }
            }
        }

        /// <summary>
        /// Retrieves the total number of users asynchronously.
        /// </summary>
        /// <returns>
        /// The total number of users as an <see cref="int"/>.
        /// </returns>
        public async Task<int> GetTotalUsersCountAsync()
        {
            int totalUsersCount = await _userManager.Users.CountAsync();
            return totalUsersCount;
        }

        /// <summary>
        /// Retrieves the total number of moderators asynchronously.
        /// </summary>
        /// <returns>
        /// The total number of moderators as an <see cref="int"/>.
        /// </returns>
        public async Task<int> GetTotalModeratorsCountAsync()
        {
            IEnumerable<ApplicationUser> moderators = await _userManager.GetUsersInRoleAsync("Moderator");

            int totalModeratorsCount = moderators.Count();

            return totalModeratorsCount;
        }

        /// <summary>
        /// Retrieves the total number of administrators asynchronously.
        /// </summary>
        /// <returns>
        /// The total number of administrators as an <see cref="int"/>.
        /// </returns>
        public async Task<int> GetTotalAdministratorsCountAsync()
        {
            IEnumerable<ApplicationUser> administrators = await _userManager.GetUsersInRoleAsync("Admin");

            int totalAdministratorsCount = administrators.Count();

            return totalAdministratorsCount;
        }
    }
}
