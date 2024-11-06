﻿
using GameVerse.Data.Models.Games.Genres;
using GameVerse.Data.Models.Games.Platform;
using GameVerse.Data.Models.Games.Restrictions;
using GameVerse.Web.ViewModels.Game;
using GameVerse.Web.ViewModels.Game.Details;
using GameVerse.Web.ViewModels.Game.Details.Genres;

namespace GameVerse.Services.Interfaces
{
    /// <summary>
    /// Defines methods for managing games, including adding, editing, deleting, and retrieving game details
    /// </summary>
    public interface IGameService
    {
        Task<string> AddGameAsync(GameInputViewModel inputModel, DateTime createdOn, string moderatorId);

        Task<GameDetailsViewModel> GetGameDetailsByIdAsync(string gameId);

        Task<bool> HasPublisherWithIdAsync(string moderatorId, string gameId);

        Task<bool> GameExistByTitleAsync(string title);

        Task<IEnumerable<GameIndexViewModel>> GetAllGamesAsync(int currentPage, int gamesPerPage);

        Task<IEnumerable<GameIndexViewModel>> GetLast3GamesAsync();

        Task<int> GetTotalGamesCountAsync();

        IEnumerable<GameTypeViewModel> GetGameTypes();

        Task<IEnumerable<GenreIndexViewModel>> GetGenresAsync();

        Task<IEnumerable<Platform>> GetPlatformAsync();

        Task<IEnumerable<Restriction>> GetRestrictionsAsync();
    }
}
