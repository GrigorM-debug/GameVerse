using GameVerse.Web.Areas.Moderator.Models;

namespace GameVerse.Web.Areas.Moderator.Services.Interfaces
{
    public interface IModeratorService
    {
        Task<IEnumerable<ModeratorGameIndexViewModel>> GetLast5CreatedGamesAsync(string userId);

        Task<IEnumerable<ModeratorEventIndexViewModel>> GetLast5CreatedEventsAsync(string userId);

        Task<int> TotalGamesCreatedAsync(string userId);

        Task<int> TotalEventsCreatedAsync(string userId);
    }
}
