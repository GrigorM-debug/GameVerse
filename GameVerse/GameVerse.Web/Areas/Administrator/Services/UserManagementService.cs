using GameVerse.Data.Models.ApplicationUsers;
using GameVerse.Data.Repositories.Interfaces;
using GameVerse.Web.Areas.Administrator.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GameVerse.Web.Areas.Administrator.Services
{
    public class UserManagementService : IUserManagementService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IGenericRepository<ApplicationUser, Guid> _userRepository;
        private readonly IGenericRepository<Data.Models.ApplicationUsers.Moderator, Guid> _moderatorRepository;

        public UserManagementService(UserManager<ApplicationUser> userManager, IGenericRepository<ApplicationUser, Guid> userRepository, IGenericRepository<Data.Models.ApplicationUsers.Moderator, Guid> moderatorRepository)
        {
            _userManager = userManager;
            _userRepository = userRepository;
            _moderatorRepository = moderatorRepository;
        }

        public async Task<bool> UserExistByIdAsync(string userId)
        {
            ApplicationUser? user = await  _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> AdministratorExistByIdAsync(string userId)
        {
            ApplicationUser? user = await _userManager.FindByIdAsync(userId);

            bool isAlreadyInRole = await _userManager.IsInRoleAsync(user, "Administrator");

            if (!isAlreadyInRole)
            {
                return false;
            }

            return true;
        }

        public async Task PromoteUserToModeratorAsync(string userId)
        {
            ApplicationUser? user = await _userManager.FindByIdAsync(userId);

            if (user != null)
            {
                bool alreadyInRole = await _userManager.IsInRoleAsync(user, "Moderator");
                bool moderatorExist = await _moderatorRepository.AllAsReadOnly()
                    .AnyAsync(m => m.UserId.ToString() == userId);

                if (!alreadyInRole && !moderatorExist)
                {
                    await _userManager.AddToRoleAsync(user, "Moderator");

                    Data.Models.ApplicationUsers.Moderator moderator = new Data.Models.ApplicationUsers.Moderator()
                    {
                        UserId = Guid.Parse(userId),
                        TotalEventsCreated = 0,
                        TotalGamesCreated = 0
                    };

                    await _moderatorRepository.AddAsync(moderator);
                    await _moderatorRepository.SaveChangesAsync();
                }
            }
        }

        public async Task DemoteModeratorToUserAsync(string userId)
        {
            ApplicationUser? user = await _userManager.FindByIdAsync(userId);

            if (user != null)
            {
                await _userManager.RemoveFromRoleAsync(user, "Moderator");

                Data.Models.ApplicationUsers.Moderator? moderator =
                    await _moderatorRepository.FirstOrDefaultAsync(m => m.UserId.ToString() == userId);

                if (moderator != null)
                {
                    await _moderatorRepository.DeleteAsync(moderator.Id);
                }
            }
        }

        public async Task PromoteModeratorToAdministratorAsync(string userId)
        {
            ApplicationUser? user = await _userManager.FindByIdAsync(userId);

            if (user != null)
            {
                if (await _userManager.IsInRoleAsync(user, "Moderator"))
                {
                    await _userManager.RemoveFromRoleAsync(user, "Moderator");
                }

                await _userManager.AddToRoleAsync(user, "Administrator");

                Data.Models.ApplicationUsers.Moderator? moderator =
                    await _moderatorRepository.FirstOrDefaultAsync(m => m.UserId.ToString() == userId);

                if (moderator != null)
                {
                    await _moderatorRepository.DeleteAsync(moderator.Id);
                }
            }
        }
    }
}
