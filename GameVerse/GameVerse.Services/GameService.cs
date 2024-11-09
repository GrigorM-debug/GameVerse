

using System.Globalization;
using System.Linq;
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
    public class GameService : IGameService
    {
        private readonly IGenericRepository<Game, Guid> _gameRepository;
        private readonly IGenericRepository<Genre, Guid>
            _genreRepository;
        private readonly IGenericRepository<Platform, Guid> _platformRepository;
        private readonly IGenericRepository<Restriction, Guid> _restrictionRepository;
      
        private readonly GameVerseDbContext _context;
        public GameService(IGenericRepository<Game, Guid> gameRepository, IGenericRepository<Genre, Guid> genreRepository, IGenericRepository<Platform, Guid> platformRepository, IGenericRepository<Restriction, Guid> restrictionRepository, GameVerseDbContext context)
        {
            _gameRepository = gameRepository;
            _genreRepository = genreRepository;
            _platformRepository = platformRepository;
            _restrictionRepository = restrictionRepository;
            _context = context;
        }

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

        public async Task<GameInputViewModel> EditGameGetAsync(string gameId, string moderatorId)
        {
            Game? game = await _gameRepository
                .GetWithIncludeAsync(g => g.GamesGenres, g=> g.GamesPlatforms, g => g.GamesRestrictions)
                .AsNoTracking()
                .FirstOrDefaultAsync(g =>
                    g.Id.ToString() == gameId && g.PublisherId.ToString() == moderatorId && g.IsDeleted == false);

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

        public async Task<string> EditGamePostAsync(GameInputViewModel inputModel, DateTime createdOn,string gameId, string moderatorId)
        {
            Game? game = await _gameRepository
                .GetWithIncludeAsync(g=> g.GamesGenres, g => g.GamesPlatforms, g => g.GamesRestrictions)
                .FirstOrDefaultAsync(g =>
                    g.Id.ToString() == gameId && g.PublisherId.ToString() == moderatorId && g.IsDeleted == false);

            game.Title = inputModel.Title;
            game.Description = inputModel.Description;
            game.PublishingStudio = inputModel.PublishingStudio;
            game.YearPublished = inputModel.YearPublished;
            game.CreatedOn = createdOn;
            game.Price = inputModel.Price;
            game.Image = inputModel.Image;
            game.QuantityInStock = inputModel.QuantityInStock;
            game.Type = inputModel.Type;
            game.PublisherId = Guid.Parse(moderatorId);

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

        public async Task<GameDeleteViewModel> DeleteGameGetAsync(string gameId, string moderatorId)
        {
            //Not done yet
            Game? game = await _gameRepository
                .GetWithIncludeAsync(g => g.Publisher.User)
                .AsNoTracking()
                .FirstOrDefaultAsync(g => g.Id.ToString() == gameId && g.PublisherId.ToString() == moderatorId &&
                                          g.IsDeleted == false);

            GameDeleteViewModel model = new GameDeleteViewModel()
            {
                Id = game.Id.ToString(),
                Title = game.Title,
                PublisherId = game.PublisherId.ToString(),
                PublisherName = game.Publisher.User.UserName
            };

            return model;
        }

        public async Task<string> DeleteGamePostAsync(string gameId, string moderatorId)
        {
            //Not done yet
            Game? game = await _gameRepository
                .GetWithIncludeAsync(g => 
                    g.GamesGenres.Where(g => g.IsDeleted == false),
                    g => g.GamesPlatforms.Where(p => p.IsDeleted == false),
                    g => g.GamesRestrictions.Where(r => r.IsDeleted == false)
                    )
                .FirstOrDefaultAsync(g =>
                    g.Id.ToString() == gameId && g.PublisherId.ToString() == moderatorId && g.IsDeleted == false);

            if (game != null)
            {
                game.IsDeleted = true;

                foreach (var genre in game.GamesGenres.ToList())
                {
                    genre.IsDeleted = true;
                }

                foreach (var platform in game.GamesPlatforms.ToList())
                {
                    platform.IsDeleted = true;
                }

                foreach (var restriction in game.GamesRestrictions.ToList())
                {
                    restriction.IsDeleted = true;
                }

                await _gameRepository.SaveChangesAsync();
            }

            return game.Id.ToString();
        }

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

        public async Task<GameDetailsViewModel> GetGameDetailsByIdAsync(string gameId)
        {
            //Game? g = await _gameRepository
            //    .GetWithIncludeAsync(
            //        g=> g.Publisher.User,
            //        g => g.GamesGenres, 
            //        g => g.GamesPlatforms, 
            //        g => g.GamesRestrictions,
            //        g => g.Reviews
            //        )
            //    .AsNoTracking()
            //    .FirstOrDefaultAsync(g => g.Id.ToString() == gameId && g.IsDeleted == false);

            Game? g = await _context.Games
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
                Publisher = g.Publisher.User.UserName,
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
                        Reviewer = r.Reviewer.UserName
                    }).ToList()
            };

            return gameDetailsViewModel;
        }

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
                ? query.OrderByDescending(g => g.Id)
                : query.OrderBy(g => g.Id);

            var gameIndexViewModels = await query
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
                    Publisher = g.Publisher.User.UserName
                }).ToListAsync();

            return gameIndexViewModels;
        }

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
                    Publisher = g.Publisher.User.UserName
                }).ToListAsync();

            return last3Games;
        }

        public async Task<int> GetTotalGamesCountAsync()
        {
            int totalGamesCount = await _gameRepository.AllAsReadOnly().CountAsync(g => g.IsDeleted == false);

            return totalGamesCount;
        }

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
    }
}
