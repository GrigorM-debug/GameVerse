

using GameVerse.Web.ViewModels.Game.UserPagesViewModels;

namespace GameVerse.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserBoughtGamesViewModel>> GetUserBoughtGamesAsync(string userId);

        Task<IEnumerable<UserEventRegistrationsViewModel>> GetUserEventRegistrationsAsync(string userId);
    }
}
