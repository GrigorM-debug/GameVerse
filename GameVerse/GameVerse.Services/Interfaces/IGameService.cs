
using GameVerse.Common.Enums;
using GameVerse.Web.ViewModels.Game;
using GameVerse.Web.ViewModels.Game.Details;
using GameVerse.Web.ViewModels.Game.SelectLists;

namespace GameVerse.Services.Interfaces
{
    /// <summary>
    /// Defines methods for managing games, including adding, editing, deleting, and retrieving game details
    /// </summary>
    public interface IGameService
    {
        Task<bool> GameExistByIdAsync(string gameId);

        Task<GameInputViewModel> AddGameGetAsync();

        Task<string> AddGamePostAsync(GameInputViewModel inputModel, DateTime createdOn, string moderatorId);

        Task<GameInputViewModel> EditGameGetAsync(string gameId, string moderatorId);

        Task<string> EditGamePostAsync(GameInputViewModel inputModel, DateTime createdOn,string gameId, string moderatorId);

        Task<GameDeleteViewModel> DeleteGameGetAsync(string gameId, string moderatorId);

        Task<string> DeleteGamePostAsync(string gameId,string moderatorId);

        Task<GameDetailsViewModel> GetGameDetailsByIdAsync(string gameId);

        Task<bool> HasPublisherWithIdAsync(string moderatorId, string gameId);

        Task<bool> GameExistByTitleAndTypeAsync(string title, GameType type);

        Task<IEnumerable<GameIndexViewModel>> GetAllGamesAsync(int currentPage, int gamesPerPage, EntitySortOrder sortOrder, string? searchString);

        Task<IEnumerable<GameIndexViewModel>> GetLast3GamesAsync();

        Task<int> GetTotalGamesCountAsync();

        IEnumerable<GameTypeViewModel> GetGameTypes();

        Task<IEnumerable<GenreSelectList>> GetGenresAsync();

        Task<IEnumerable<PlatformSelectList>> GetPlatformsAsync();

        Task<IEnumerable<RestrictionSelectList>> GetRestrictionsAsync();
    }
}
