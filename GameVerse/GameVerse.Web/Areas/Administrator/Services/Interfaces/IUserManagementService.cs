using GameVerse.Web.Areas.Administrator.Models;

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
    }
}
