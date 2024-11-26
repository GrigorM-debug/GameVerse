﻿
using GameVerse.Common.Enums;
using GameVerse.Data.Models.Games;
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

        Task<Game> GetGameByIdAsync(string gameId);

        Task<Game> GetGameByIdAsTrackingAsync(string gameId);

        Task<GameInputViewModel> AddGameGetAsync();

        Task<string> AddGamePostAsync(GameInputViewModel inputModel, DateTime createdOn, string moderatorId);

        Task<GameInputViewModel> EditGameGetAsync(string gameId, string moderatorId, bool isAdmin);

        Task<string> EditGamePostAsync(GameInputViewModel inputModel, DateTime createdOn,string gameId, string moderatorId, bool isAdmin);

        Task<GameDeleteViewModel> DeleteGameGetAsync(string gameId, string moderatorId, bool isAdmin);

        Task<string> DeleteGamePostAsync(string gameId,string moderatorId, bool isAdmin);

        Task<GameDetailsViewModel> GetGameDetailsByIdAsync(string gameId);

        Task<bool> HasPublisherWithIdAsync(string moderatorId, string gameId);

        Task<bool> GameExistByTitleAndTypeAsync(string title, GameType type);

        Task<IEnumerable<GameIndexViewModel>> GetAllGamesAsync(int currentPage, int gamesPerPage, EntitySortOrder sortOrder, string? searchString, GameType? gameSelectedGameTypeSortOrder);

        Task<IEnumerable<GameIndexViewModel>> GetLast3GamesAsync();

        Task<int> GetTotalGamesCountAsync();

        IEnumerable<GameTypeViewModel> GetGameTypes();

        Task<IEnumerable<GenreSelectList>> GetGenresAsync();

        Task<IEnumerable<PlatformSelectList>> GetPlatformsAsync();

        Task<IEnumerable<RestrictionSelectList>> GetRestrictionsAsync();

        Task UpdateGameQuantityInStockAsync(string gameId, int quantityInStock);
    }
}
