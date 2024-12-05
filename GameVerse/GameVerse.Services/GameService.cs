

using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using GameVerse.Common.Enums;
using GameVerse.Data;
using GameVerse.Data.Models.Games;
using GameVerse.Data.Models.Games.Genres;
using GameVerse.Data.Models.Games.Platform;
using GameVerse.Data.Models.Games.Restrictions;
using GameVerse.Data.Models.Games.Review;
using GameVerse.Data.Repositories.Interfaces;
using GameVerse.Services.Interfaces;
using GameVerse.Web.ViewModels.Game;
using GameVerse.Web.ViewModels.Game.Details;
using GameVerse.Web.ViewModels.Game.SelectLists;
using Microsoft.EntityFrameworkCore;

using static GameVerse.Common.ApplicationConstants;

namespace GameVerse.Services
{
    /// <summary>
    /// Provides functionality for managing games, including adding, editing, deleting, and retrieving game details.
    /// </summary>
    public class GameService(
        IGenericRepository<Game, Guid> _gameRepository,
        IGenericRepository<Genre, Guid> _genreRepository,
        IGenericRepository<Platform, Guid> _platformRepository,
        IGenericRepository<Restriction, Guid> _restrictionRepository)
        : IGameService
    {
        /// <summary>
        /// Retrieves a game by its ID if it exists and is not marked as deleted.
        /// </summary>
        /// <param name="gameId">The unique ID of the game.</param>
        /// <returns>The game if found; otherwise, <c>null</c>.</returns>
        public async Task<Game> GetGameByIdAsync(string gameId)
        {
            Game? game = await _gameRepository
                .AllAsReadOnly()
                .FirstOrDefaultAsync(g => g.Id.ToString() == gameId && g.IsDeleted == false);

            return game;
        }

        /// <summary>
        /// Retrieves a game by its ID with tracking enabled.
        /// </summary>
        /// <param name="gameId">The unique ID of the game.</param>
        /// <returns>The tracked game if found; otherwise, <c>null</c>.</returns>
        public async Task<Game> GetGameByIdAsTrackingAsync(string gameId)
        {
            Game? game =
                await _gameRepository.FirstOrDefaultAsync(g => g.Id.ToString() == gameId && g.IsDeleted == false);

            return game;
        }

        /// <summary>
        /// Prepares the necessary data for adding a new game.
        /// </summary>
        /// <returns>A view model containing the required data for adding a game.</returns
        public async Task<GameInputViewModel> AddGameGetAsync()
        {
            IEnumerable<GenreSelectList> genres = await GetGenresAsync();
            IEnumerable<PlatformSelectList> platforms = await GetPlatformsAsync();
            IEnumerable<RestrictionSelectList> restrictions = await GetRestrictionsAsync();
            IEnumerable<GameTypeViewModel> gameTypes = GetGameTypes();

            GameInputViewModel model = new GameInputViewModel();

            model.GameTypes = gameTypes;
            model.GenreSelectList = genres;
            model.PlatformSelectList = platforms;
            model.RestrictionSelectList = restrictions;

            return model;
        }

        /// <summary>
        /// Adds a new game to the system.
        /// </summary>
        /// <param name="inputModel">The data for the new game.</param>
        /// <param name="createdOn">The date the game was created.</param>
        /// <param name="moderatorId">The ID of the moderator adding the game.</param>
        /// <returns>The ID of the newly created game.</returns>
        public async Task<string> AddGamePostAsync(GameInputViewModel inputModel, DateTime createdOn, string moderatorId)
        {
            Game game = new Game()
            {
                Title = inputModel.Title,
                Description = inputModel.Description,
                PublishingStudio = inputModel.PublishingStudio,
                YearPublished = inputModel.YearPublished,
                CreatedOn = createdOn,
                Price = inputModel.Price,
                Image = inputModel.Image,
                QuantityInStock = inputModel.QuantityInStock,
                Type = inputModel.Type,
                PublisherId = Guid.Parse(moderatorId),
            };

            foreach (var genreId in inputModel.SelectedGenres)
            {
                game.GamesGenres.Add(new GameGenre()
                {
                    GenreId = genreId,
                    Game = game,
                    IsDeleted = false
                });
            }

            foreach (var platformId in inputModel.SelectedPlatforms)
            {
                game.GamesPlatforms.Add(new GamePlatform()
                {
                    PlatformId = platformId,
                    Game = game,
                    IsDeleted = false
                });
            }

            foreach (var restrictionId in inputModel.SelectedRestrictions)
            {
                game.GamesRestrictions.Add(new GameRestriction()
                {
                    RestrictionId = restrictionId,
                    Game = game,
                    IsDeleted = false
                });
            }

            await _gameRepository.AddAsync(game);
            await _gameRepository.SaveChangesAsync();

            return game.Id.ToString();
        }

        /// <summary>
        /// Retrieves game details for editing.
        /// </summary>
        /// <param name="gameId">The ID of the game to edit.</param>
        /// <param name="moderatorId">The ID of the moderator performing the edit.</param>
        /// <param name="isAdmin">Indicates whether the user is an admin.</param>
        /// <returns>A view model containing the game details for editing.</returns>
        public async Task<GameInputViewModel> EditGameGetAsync(string gameId, string moderatorId, bool isAdmin)
        {
            Game? game = await _gameRepository
                .GetWithIncludeAsync(g => g.GamesGenres, g=> g.GamesPlatforms, g => g.GamesRestrictions)
                .AsNoTracking()
                .FirstOrDefaultAsync(g =>
                    g.Id.ToString() == gameId && (g.PublisherId.ToString() == moderatorId || isAdmin) && g.IsDeleted == false);

            IEnumerable<GenreSelectList> genres = await GetGenresAsync();
            IEnumerable<PlatformSelectList> platforms = await GetPlatformsAsync();
            IEnumerable<RestrictionSelectList> restrictions = await GetRestrictionsAsync();
            IEnumerable<GameTypeViewModel> gameTypes = GetGameTypes();

            GameInputViewModel model = new GameInputViewModel()
            {
                Title = game.Title,
                Description = game.Description,
                PublishingStudio = game.PublishingStudio,
                YearPublished = game.YearPublished,
                CreatedOn = game.CreatedOn.ToString(DateTimeFormat, CultureInfo.InvariantCulture),
                Price = game.Price,
                Image = game.Image,
                QuantityInStock = game.QuantityInStock,
                Type = game.Type
            };

            model.GenreSelectList = genres;
            model.PlatformSelectList = platforms;
            model.RestrictionSelectList = restrictions;
            model.GameTypes = gameTypes;

            model.SelectedGenres = game.GamesGenres.Where(g => g.IsDeleted == false).Select(g => g.GenreId);
            model.SelectedPlatforms = game.GamesPlatforms.Where(p => p.IsDeleted == false).Select(p => p.PlatformId);
            model.SelectedRestrictions = game.GamesRestrictions.Where(r => r.IsDeleted == false).Select(r => r.RestrictionId);

            return model;
        }

        /// <summary>
        /// Updates a game with new details.
        /// </summary>
        /// <param name="inputModel">The updated game data.</param>
        /// <param name="createdOn">The modification date.</param>
        /// <param name="gameId">The ID of the game being updated.</param>
        /// <param name="moderatorId">The ID of the moderator performing the update.</param>
        /// <param name="isAdmin">Indicates whether the user is an admin.</param>
        /// <returns>The ID of the updated game.</returns>
        public async Task<string> EditGamePostAsync(GameInputViewModel inputModel, DateTime createdOn,string gameId, string moderatorId, bool isAdmin)
        {
            Game? game = await _gameRepository
                .GetWithIncludeAsync(g=> g.GamesGenres, g => g.GamesPlatforms, g => g.GamesRestrictions)
                .FirstOrDefaultAsync(g =>
                    g.Id.ToString() == gameId && (g.PublisherId.ToString() == moderatorId || isAdmin) && g.IsDeleted == false);

            game.Title = inputModel.Title;
            game.Description = inputModel.Description;
            game.PublishingStudio = inputModel.PublishingStudio;
            game.YearPublished = inputModel.YearPublished;
            game.CreatedOn = createdOn;
            game.Price = inputModel.Price;
            game.Image = inputModel.Image;
            game.QuantityInStock = inputModel.QuantityInStock;
            game.Type = inputModel.Type;
            //game.PublisherId = Guid.Parse(moderatorId);

            var selectedGenreIds = inputModel.SelectedGenres.ToHashSet();
            foreach (var gameGenre in game.GamesGenres.ToList())
            {
                if (selectedGenreIds.Contains(gameGenre.GenreId))
                {
                    gameGenre.IsDeleted = false; // Reactivate if selected
                    selectedGenreIds.Remove(gameGenre.GenreId); // Remove processed IDs
                }
                else
                {
                    gameGenre.IsDeleted = true; // Mark as deleted if not in selected list
                }
            }

            foreach (var newGenreId in selectedGenreIds)
            {
                game.GamesGenres.Add(new GameGenre
                {
                    GenreId = newGenreId,
                    Game = game,
                    IsDeleted = false
                });
            }

            var selectedPlatformIds = inputModel.SelectedPlatforms.ToHashSet();
            foreach (var gamePlatform in game.GamesPlatforms.ToList())
            {
                if (selectedPlatformIds.Contains(gamePlatform.PlatformId))
                {
                    gamePlatform.IsDeleted = false;
                    selectedPlatformIds.Remove(gamePlatform.PlatformId);
                }
                else
                {
                    gamePlatform.IsDeleted = true;
                }
            }

            foreach (var newPlatformId in selectedPlatformIds)
            {
                game.GamesPlatforms.Add(new GamePlatform
                {
                    PlatformId = newPlatformId,
                    Game = game,
                    IsDeleted = false
                });
            }

            var selectedRestrictionIds = inputModel.SelectedRestrictions.ToHashSet();
            foreach (var gameRestriction in game.GamesRestrictions.ToList())
            {
                if (selectedRestrictionIds.Contains(gameRestriction.RestrictionId))
                {
                    gameRestriction.IsDeleted = false;
                    selectedRestrictionIds.Remove(gameRestriction.RestrictionId);
                }
                else
                {
                    gameRestriction.IsDeleted = true;
                }
            }

            foreach (var newRestrictionId in selectedRestrictionIds)
            {
                game.GamesRestrictions.Add(new GameRestriction
                {
                    RestrictionId = newRestrictionId,
                    Game = game,
                    IsDeleted = false
                });
            }

            await _gameRepository.SaveChangesAsync();


            return game.Id.ToString();
        }

        /// <summary>
        /// Retrieves game details for deletion confirmation.
        /// </summary>
        /// <param name="gameId">The ID of the game to delete.</param>
        /// <param name="moderatorId">The ID of the moderator performing the deletion.</param>
        /// <param name="isAdmin">Indicates whether the user is an admin.</param>
        /// <returns>A view model containing the game details for deletion.</returns>
        public async Task<GameDeleteViewModel> DeleteGameGetAsync(string gameId, string moderatorId, bool isAdmin)
        {
            Game? game = await _gameRepository
                .GetWithIncludeAsync(g => g.Publisher.User)
                .AsNoTracking()
                .FirstOrDefaultAsync(g => g.Id.ToString() == gameId && (g.PublisherId.ToString() == moderatorId || isAdmin) &&
                                          g.IsDeleted == false);

            if (game == null)
            {
                return null;
            }

            GameDeleteViewModel model = new GameDeleteViewModel()
            {
                Id = game.Id.ToString(),
                Title = game.Title,
                PublisherId = game.PublisherId.ToString(),
                PublisherName = game.Publisher.User.UserName ?? string.Empty
            };

            return model;
        }

        /// <summary>
        /// Deletes a game from the system.
        /// </summary>
        /// <param name="gameId">The ID of the game to delete.</param>
        /// <param name="moderatorId">The ID of the moderator performing the deletion.</param>
        /// <param name="isAdmin">Indicates whether the user is an admin.</param>
        public async Task DeleteGamePostAsync(string gameId, string moderatorId, bool isAdmin)
        {
            Game? game = await _gameRepository
                .FirstOrDefaultAsync(g =>
                    g.Id.ToString() == gameId && (g.PublisherId.ToString() == moderatorId || isAdmin) && g.IsDeleted == false);

            if (game != null)
            {
                game.IsDeleted = true;

                await _gameRepository.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Checks if a game exists by its ID.
        /// </summary>
        /// <param name="gameId">The unique ID of the game.</param>
        /// <returns><c>true</c> if the game exists; otherwise, <c>false</c>.</returns>
        public async Task<bool> GameExistByIdAsync(string gameId)
        {
            Game? game = await _gameRepository
                .AllAsReadOnly()
                .FirstOrDefaultAsync(g => g.Id.ToString() == gameId && g.IsDeleted == false);

            if (game == null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Retrieves detailed information about a specific game.
        /// </summary>
        /// <param name="gameId">The ID of the game.</param>
        /// <returns>A view model containing the game details.</returns>
        public async Task<GameDetailsViewModel> GetGameDetailsByIdAsync(string gameId)
        {
            Game? g = await _gameRepository
                .GetAllAttached()
                .Include(g => g.Publisher.User)
                .Include(g => g.GamesGenres).ThenInclude(x => x.Genre)
                .Include(g => g.GamesPlatforms).ThenInclude(x => x.Platform)
                .Include(g => g.GamesRestrictions).ThenInclude(r => r.Restriction)
                .Include(g => g.Reviews).ThenInclude(r => r.Reviewer)
                .AsNoTracking()
                .FirstOrDefaultAsync(g => g.Id.ToString() == gameId && g.IsDeleted == false);


            GameDetailsViewModel gameDetailsViewModel = new GameDetailsViewModel()
            {
                Id = g.Id.ToString(),
                Title = g.Title,
                Description = g.Description,
                PublishingStudio = g.PublishingStudio,
                YearPublished = g.YearPublished,
                CreatedOn = g.CreatedOn.ToString(DateTimeFormat, CultureInfo.InvariantCulture),
                Price = g.Price.ToString("C"),
                Image = g.Image,
                QuantityInStock = g.QuantityInStock,
                Type = g.Type.ToString(),
                Publisher = g.Publisher.User.UserName ?? string.Empty,
                Platforms = g.GamesPlatforms
                    .Where(gp => gp.IsDeleted == false)
                    .Select(gp => new GamePlatformsIndexViewModel()
                    {
                        Name = gp.Platform.Name
                    }).ToList(),
                Restrictions = g.GamesRestrictions
                    .Where(gr => gr.IsDeleted == false)
                    .Select(gr => new GameRestrictionsIndexViewModel()
                    {
                        Name = gr.Restriction.Name
                    }).ToList(),
                Genres = g.GamesGenres
                    .Where(g => g.IsDeleted == false)
                    .Select(g=> new GenreIndexViewModel()
                    {
                        Name = g.Genre.Name
                    }).ToList(),
                Reviews = g.Reviews
                    .Where(r => r.IsDeleted == false)
                    .Select(r => new GameReviewsIndexViewModel()
                    {
                        Id = r.Id.ToString(),
                        Content = r.Content,
                        Rating = r.Rating,
                        CreatedOn = r.CreatedOn.ToString(DateTimeFormat, CultureInfo.InvariantCulture),
                        Reviewer = r.Reviewer.UserName ?? string.Empty,
                    }).ToList(),
                AverageRating = g.Reviews
                    .Where(r => r.IsDeleted == false)
                    .Select(r => r.Rating)
                    .DefaultIfEmpty()
                    .Average()
            };

            return gameDetailsViewModel;
        }

        /// <summary>
        /// Checks if a specific moderator is associated with a game's publisher.
        /// </summary>
        /// <param name="moderatorId">The ID of the moderator.</param>
        /// <param name="gameId">The ID of the game.</param>
        /// <returns><c>true</c> if the moderator is associated with the game's publisher; otherwise, <c>false</c>.</returns>
        public async Task<bool> HasPublisherWithIdAsync(string moderatorId, string gameId)
        {
            Game? game = await _gameRepository.AllAsReadOnly().FirstOrDefaultAsync(g =>
                g.Id.ToString() == gameId && g.PublisherId.ToString() == moderatorId && g.IsDeleted == false);

            if (game == null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks if a game exists with the specified title and type.
        /// </summary>
        /// <param name="title">The title of the game.</param>
        /// <param name="type">The type of the game.</param>
        /// <returns><c>true</c> if the game exists; otherwise, <c>false</c>.</returns>
        public async Task<bool> GameExistByTitleAndTypeAsync(string title, GameType type)
        {
            Game? game = await _gameRepository.AllAsReadOnly()
                .FirstOrDefaultAsync(g => g.IsDeleted == false && g.Title == title && g.Type == type);

            if (game == null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Retrieves a paginated list of games, with optional sorting and filtering.
        /// </summary>
        /// <param name="currentPage">The current page number.</param>
        /// <param name="gamesPerPage">The number of games per page.</param>
        /// <param name="sortOrder">The sorting order of the games.</param>
        /// <param name="searchString">An optional search term to filter games.</param>
        /// <param name="gameSelectedGameTypeSortOrder">An optional filter for the game type.</param>
        /// <returns>A collection of games as view models.</returns>
        public async Task<IEnumerable<GameIndexViewModel>> GetAllGamesAsync(int currentPage, int gamesPerPage, EntitySortOrder sortOrder, string? searchString, GameType? gameSelectedGameTypeSortOrder)
        {
            IQueryable<Game> query =  _gameRepository
                .GetWithIncludeAsync(g => g.Publisher.User)
                .AsNoTracking()
                .Where(g => g.IsDeleted == false);

            if (searchString != null)
            {
                query = query.Where(g => g.Title.Contains(searchString));
            }

            if (gameSelectedGameTypeSortOrder != null)
            {
                query = query.Where(g => g.Type == gameSelectedGameTypeSortOrder);
            }

            query = sortOrder == EntitySortOrder.Newest
                ? query.OrderByDescending(g => g.CreatedOn)
                : query.OrderBy(g => g.CreatedOn);

            IEnumerable<GameIndexViewModel> gameIndexViewModels = await query
                .Skip((currentPage - 1) * gamesPerPage)
                .Take(gamesPerPage)
                .Select(g => new GameIndexViewModel()
                {
                    Id = g.Id.ToString(),
                    Title = g.Title,
                    CreatedOn = g.CreatedOn.ToString(DateTimeFormat, CultureInfo.InvariantCulture),
                    Price = g.Price.ToString("C"),
                    Image = g.Image,
                    QuantityInStock = g.QuantityInStock,
                    Publisher = g.Publisher.User.UserName ?? string.Empty
                }).ToListAsync();

            return gameIndexViewModels;
        }

        /// <summary>
        /// Retrieves the last three added games.
        /// </summary>
        /// <returns>A collection of the last three games as view models.</returns>
        public async Task<IEnumerable<GameIndexViewModel>> GetLast3GamesAsync()
        {
            IEnumerable<GameIndexViewModel> last3Games = await _gameRepository
                .GetWithIncludeAsync(g=> g.Publisher.User)
                .Where(g => g.IsDeleted == false)
                .OrderByDescending(g => g.Id)
                .Take(3)
                .Select(g => new GameIndexViewModel()
                {
                    Id = g.Id.ToString(),
                    Title = g.Title,
                    CreatedOn = g.CreatedOn.ToString(DateTimeFormat, CultureInfo.InvariantCulture),
                    Price = g.Price.ToString("C"),
                    Image = g.Image,
                    QuantityInStock = g.QuantityInStock,
                    Publisher = g.Publisher.User.UserName ?? string.Empty
                }).ToListAsync();

            return last3Games;
        }

        /// <summary>
        /// Retrieves the total number of games in the system.
        /// </summary>
        /// <returns>The total number of games.</returns>
        public async Task<int> GetTotalGamesCountAsync()
        {
            int totalGamesCount = await _gameRepository.AllAsReadOnly().CountAsync(g => g.IsDeleted == false);

            return totalGamesCount;
        }

        /// <summary>
        /// Retrieves a collection of all available game types.
        /// </summary>
        /// <returns>A collection of game type view models.</returns>
        public IEnumerable<GameTypeViewModel> GetGameTypes()
        {
            IEnumerable<GameTypeViewModel> gameTypes = Enum
                .GetValues(typeof(GameType))
                .Cast<GameType>()
                .Select(gt => new GameTypeViewModel()
                {
                    Value = (int)gt,
                    Text = gt.ToString()
                }).ToList();

            return gameTypes;
        }

        /// <summary>
        /// Retrieves a list of all available genres for games.
        /// </summary>
        /// <returns>A collection of genres as select list items.</returns>
        public async Task<IEnumerable<GenreSelectList>> GetGenresAsync()
        {
            IEnumerable<GenreSelectList> genres = await _genreRepository
                .AllAsReadOnly()
                .Select(g => new GenreSelectList()
                {
                    Id = g.Id,
                    Name = g.Name
                }).ToListAsync();

            return genres;
        }

        /// <summary>
        /// Retrieves a list of all available platforms for games.
        /// </summary>
        /// <returns>A collection of platforms as select list items.</returns>
        public async Task<IEnumerable<PlatformSelectList>> GetPlatformsAsync()
        {
            IEnumerable<PlatformSelectList> platforms = await _platformRepository
                .AllAsReadOnly()
                .Select(p => new PlatformSelectList()
                {
                    Id = p.Id,
                    Name = p.Name
                })
                .ToListAsync();

            return platforms;
        }

        /// <summary>
        /// Retrieves a list of all available age restrictions for games.
        /// </summary>
        /// <returns>A collection of restrictions as select list items.</returns>
        public async Task<IEnumerable<RestrictionSelectList>> GetRestrictionsAsync()
        {
            IEnumerable<RestrictionSelectList> restrictions = await _restrictionRepository
                .AllAsReadOnly()
                .Select(r => new RestrictionSelectList()
                {
                    Id = r.Id,
                    Name = r.Name
                })
                .ToListAsync();

            return restrictions;
        }

        /// <summary>
        /// Updates the quantity of a game in stock.
        /// </summary>
        /// <param name="gameId">The ID of the game.</param>
        /// <param name="quantityInStock">The new quantity to add to stock.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task UpdateGameQuantityInStockAsync(string gameId, int quantityInStock)
        {
            Game? game =
                await _gameRepository.FirstOrDefaultAsync(g => g.Id.ToString() == gameId && g.IsDeleted == false);

            if (game != null)
            {
                game.QuantityInStock += quantityInStock;
                await _gameRepository.SaveChangesAsync();
            }
        }
    }
}
