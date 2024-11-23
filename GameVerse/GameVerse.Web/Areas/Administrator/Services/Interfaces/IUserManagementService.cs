using GameVerse.Web.Areas.Administrator.Models;
using Microsoft.Build.ObjectModelRemoting;

namespace GameVerse.Web.Areas.Administrator.Services.Interfaces
{
    public interface IUserManagementService
    {
        Task<IEnumerable<UserViewModel>> GetAllUsersWithDetailsAsync();

        Task<bool> UserExistByIdAsync(string userId);

        Task<bool> AdministratorExistByIdAsync(string userId);

        Task PromoteUserToModeratorAsync(string userId);

        Task DemoteModeratorToUserAsync(string userId);

        Task PromoteModeratorToAdministratorAsync(string userId);

        Task<int> GetTotalUsersCountAsync();
        Task<int> GetTotalModeratorsCountAsync();
        Task<int> GetTotalAdministratorsCountAsync();
    }
}
