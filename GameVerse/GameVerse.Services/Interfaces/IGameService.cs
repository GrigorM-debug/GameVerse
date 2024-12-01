
using GameVerse.Common.Enums;
using GameVerse.Data.Models.Games;
using GameVerse.Web.ViewModels.Game;
using GameVerse.Web.ViewModels.Game.Details;
using GameVerse.Web.ViewModels.Game.SelectLists;

namespace GameVerse.Services.Interfaces
{
    /// <summary>
    /// Provides functionality for managing games, including operations such as 
    /// adding, editing, deleting, retrieving, and listing games with associated details.
    /// </summary>
    public interface IGameService
    {
        /// <summary>
        /// Checks if a game exists by its ID.
        /// </summary>
        /// <param name="gameId">The unique ID of the game.</param>
        /// <returns>A task containing <c>true</c> if the game exists; otherwise, <c>false</c>.</returns>
        Task<bool> GameExistByIdAsync(string gameId);

        /// <summary>
        /// Retrieves a game by its ID if it exists and is not marked as deleted.
        /// </summary>
        /// <param name="gameId">The unique ID of the game.</param>
        /// <returns>The game if found; otherwise, <c>null</c>.</returns>
        Task<Game> GetGameByIdAsync(string gameId);

        /// <summary>
        /// Retrieves a game by its ID with tracking enabled.
        /// </summary>
        /// <param name="gameId">The unique ID of the game.</param>
        /// <returns>A task containing the tracked game if found; otherwise, <c>null</c>.</returns>
        Task<Game> GetGameByIdAsTrackingAsync(string gameId);

        /// <summary>
        /// Prepares the necessary data for adding a new game.
        /// </summary>
        /// <returns>A view model containing the required data for adding a game.</returns>
        Task<GameInputViewModel> AddGameGetAsync();

        /// <summary>
        /// Adds a new game to the system.
        /// </summary>
        /// <param name="inputModel">The data for the new game.</param>
        /// <param name="createdOn">The creation date of the game.</param>
        /// <param name="moderatorId">The ID of the moderator adding the game.</param>
        /// <returns>A task containing the ID of the newly created game.</returns>
        Task<string> AddGamePostAsync(GameInputViewModel inputModel, DateTime createdOn, string moderatorId);

        /// <summary>
        /// Retrieves game details for editing.
        /// </summary>
        /// <param name="gameId">The ID of the game to edit.</param>
        /// <param name="moderatorId">The ID of the moderator editing the game.</param>
        /// <param name="isAdmin">Indicates if the user is an admin.</param>
        /// <returns>A task containing the game details in a <see cref="GameInputViewModel"/>.</returns>
        Task<GameInputViewModel> EditGameGetAsync(string gameId, string moderatorId, bool isAdmin);

        /// <summary>
        /// Updates a game with new details.
        /// </summary>
        /// <param name="inputModel">The updated game data.</param>
        /// <param name="createdOn">The modification date.</param>
        /// <param name="gameId">The ID of the game being updated.</param>
        /// <param name="moderatorId">The ID of the moderator updating the game.</param>
        /// <param name="isAdmin">Indicates if the user is an admin.</param>
        /// <returns>A task containing the ID of the updated game.</returns>
        Task<string> EditGamePostAsync(GameInputViewModel inputModel, DateTime createdOn,string gameId, string moderatorId, bool isAdmin);

        /// <summary>
        /// Retrieves game details for deletion confirmation.
        /// </summary>
        /// <param name="gameId">The ID of the game to delete.</param>
        /// <param name="moderatorId">The ID of the moderator performing the deletion.</param>
        /// <param name="isAdmin">Indicates if the user is an admin.</param>
        /// <returns>A task containing the game details in a <see cref="GameDeleteViewModel"/>.</returns>
        Task<GameDeleteViewModel> DeleteGameGetAsync(string gameId, string moderatorId, bool isAdmin);

        /// <summary>
        /// Deletes a game from the system.
        /// </summary>
        /// <param name="gameId">The ID of the game to delete.</param>
        /// <param name="moderatorId">The ID of the moderator performing the deletion.</param>
        /// <param name="isAdmin">Indicates if the user is an admin.</param>
        Task DeleteGamePostAsync(string gameId,string moderatorId, bool isAdmin);

        /// <summary>
        /// Retrieves detailed information about a specific game.
        /// </summary>
        /// <param name="gameId">The ID of the game.</param>
        /// <returns>A task containing a <see cref="GameDetailsViewModel"/> with the game details.</returns>
        Task<GameDetailsViewModel> GetGameDetailsByIdAsync(string gameId);

        /// <summary>
        /// Checks if a specific moderator is associated with a game's publisher.
        /// </summary>
        /// <param name="moderatorId">The ID of the moderator.</param>
        /// <param name="gameId">The ID of the game.</param>
        /// <returns>A task containing <c>true</c> if the moderator is associated with the game's publisher; otherwise, <c>false</c>.</returns>
        Task<bool> HasPublisherWithIdAsync(string moderatorId, string gameId);

        /// <summary>
        /// Checks if a game exists with the specified title and type.
        /// </summary>
        /// <param name="title">The title of the game.</param>
        /// <param name="type">The type of the game.</param>
        /// <returns>A task containing <c>true</c> if the game exists; otherwise, <c>false</c>.</returns>
        Task<bool> GameExistByTitleAndTypeAsync(string title, GameType type);

        /// <summary>
        /// Retrieves a paginated and optionally sorted list of games.
        /// </summary>
        /// <param name="currentPage">The current page number.</param>
        /// <param name="gamesPerPage">The number of games per page.</param>
        /// <param name="sortOrder">The sorting order of the games.</param>
        /// <param name="searchString">An optional search term to filter games.</param>
        /// <param name="gameSelectedGameTypeSortOrder">An optional filter for the game type.</param>
        /// <returns>A task containing a collection of <see cref="GameIndexViewModel"/> for the games.</returns>
        Task<IEnumerable<GameIndexViewModel>> GetAllGamesAsync(int currentPage, int gamesPerPage, EntitySortOrder sortOrder, string? searchString, GameType? gameSelectedGameTypeSortOrder);

        /// <summary>
        /// Retrieves the last three added games.
        /// </summary>
        /// <returns>A task containing a collection of the last three games as <see cref="GameIndexViewModel"/>.</returns>
        Task<IEnumerable<GameIndexViewModel>> GetLast3GamesAsync();

        /// <summary>
        /// Retrieves the total count of games in the system.
        /// </summary>
        /// <returns>A task containing the total number of games.</returns>
        Task<int> GetTotalGamesCountAsync();

        /// <summary>
        /// Retrieves a collection of all available game types.
        /// </summary>
        /// <returns>A collection of <see cref="GameTypeViewModel"/>.</returns>
        IEnumerable<GameTypeViewModel> GetGameTypes();

        /// <summary>
        /// Retrieves a list of all available genres for games.
        /// </summary>
        /// <returns>A task containing a collection of <see cref="GenreSelectList"/>.</returns>
        Task<IEnumerable<GenreSelectList>> GetGenresAsync();

        /// <summary>
        /// Retrieves a list of all available platforms for games.
        /// </summary>
        /// <returns>A task containing a collection of <see cref="PlatformSelectList"/>.</returns>
        Task<IEnumerable<PlatformSelectList>> GetPlatformsAsync();

        /// <summary>
        /// Retrieves a list of all available age restrictions for games.
        /// </summary>
        /// <returns>A task containing a collection of <see cref="RestrictionSelectList"/>.</returns>
        Task<IEnumerable<RestrictionSelectList>> GetRestrictionsAsync();

        /// <summary>
        /// Updates the quantity of a game in stock.
        /// </summary>
        /// <param name="gameId">The ID of the game.</param>
        /// <param name="quantityInStock">The new quantity to set.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task UpdateGameQuantityInStockAsync(string gameId, int quantityInStock);
    }
}
