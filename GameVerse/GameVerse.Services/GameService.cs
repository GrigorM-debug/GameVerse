

using System.Globalization;
using System.Runtime.InteropServices.JavaScript;
using GameVerse.Common.Enums;
using GameVerse.Data.Models.Games;
using GameVerse.Data.Models.Games.Genres;
using GameVerse.Data.Models.Games.Platform;
using GameVerse.Data.Models.Games.Restrictions;
using GameVerse.Data.Repositories.Interfaces;
using GameVerse.Services.Interfaces;
using GameVerse.Web.ViewModels.Game;
using GameVerse.Web.ViewModels.Game.Details;
using GameVerse.Web.ViewModels.Game.Details.Genres;
using GameVerse.Web.ViewModels.Game.Details.Platforms;
using GameVerse.Web.ViewModels.Game.Details.Restrictions;
using GameVerse.Web.ViewModels.Game.Details.Reviews;
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

        public GameService(IGenericRepository<Game, Guid> gameRepository, IGenericRepository<Genre, Guid> genreRepository, IGenericRepository<Platform, Guid> platformRepository, IGenericRepository<Restriction, Guid> restrictionRepository)
        {
            _gameRepository = gameRepository;
            _genreRepository = genreRepository;
            _platformRepository = platformRepository;
            _restrictionRepository = restrictionRepository;
        }

        public async Task<string> AddGameAsync(GameInputViewModel inputModel, DateTime createdOn, string moderatorId)
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
                Type = inputModel.SelectedType,
                PublisherId = Guid.Parse(moderatorId),
            };

            game.GamesGenres =
                inputModel.SelectedGenres.Select(genreId => new GameGenre() { GameId = game.Id, GenreId = genreId }).ToList();

            game.GamesPlatforms = inputModel.SelectedPlatforms
                .Select(platformId => new GamePlatform() { GameId = game.Id, PlatformId = platformId }).ToList();

            game.GamesRestrictions = inputModel.SelectedRestrictions.Select(restrictionId =>
                new GameRestriction() { GameId = game.Id, RestrictionId = restrictionId }).ToList();

            await _gameRepository.AddAsync(game);
            await _gameRepository.SaveChangesAsync();

            return game.Id.ToString();
        }

        public async Task<GameDetailsViewModel> GetGameDetailsByIdAsync(string gameId)
        {
            Game? g = await _gameRepository
                .GetWithIncludeAsync(
                    g=> g.Publisher.User,
                    g => g.GamesGenres.Where(gg => gg.IsDeleted == false), 
                    g => g.GamesPlatforms.Where(gp => gp.IsDeleted == false), 
                    g => g.GamesRestrictions.Where(gr => gr.IsDeleted == false),
                    g => g.Reviews.Where(r => r.IsDeleted == false)
                    )
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
                    .Select(gp => new GamePlatformsIndexViewModel()
                    {
                        Name = gp.Platform.Name
                    }),
                Restrictions = g.GamesRestrictions
                    .Select(gr => new GameRestrictionsIndexViewModel()
                    {
                        Name = gr.Restriction.Name
                    }),
                Genres = g.GamesGenres
                    .Select(g=> new GenreIndexViewModel()
                    {
                        Name = g.Genre.Name
                    }),
                Reviews = g.Reviews
                    .Select(r => new GameReviewsIndexViewModel()
                    {
                        Id = r.Id.ToString(),
                        Content = r.Content,
                        Rating = r.Rating,
                        CreatedOn = r.CreatedOn.ToString(DateTimeFormat, CultureInfo.InvariantCulture),
                        Reviewer = r.Reviewer.UserName
                    })
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

        public async Task<bool> GameExistByTitleAsync(string title)
        {
            Game? game = await _gameRepository.AllAsReadOnly()
                .FirstOrDefaultAsync(g => g.IsDeleted == false && g.Title == title);

            if (game == null)
            {
                return false;
            }

            return true;
        }

        public async Task<IEnumerable<GameIndexViewModel>> GetAllGamesAsync(int currentPage, int gamesPerPage)
        {
            IEnumerable<GameIndexViewModel> games = await _gameRepository
                .GetWithIncludeAsync(g => g.Publisher.User)
                .AsNoTracking()
                .Where(g => g.IsDeleted == false)
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

            return games;
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

        public async Task<IEnumerable<Genre>> GetGenresAsync()
        {
            IEnumerable<Genre> genres = await _genreRepository.AllAsReadOnly().ToListAsync();

            return genres;
        }

        public async Task<IEnumerable<Platform>> GetPlatformAsync()
        {
            IEnumerable<Platform> platforms = await _platformRepository.AllAsReadOnly().ToListAsync();

            return platforms;
        }

        public async Task<IEnumerable<Restriction>> GetRestrictionsAsync()
        {
            IEnumerable<Restriction> restrictions = await _restrictionRepository.AllAsReadOnly().ToListAsync();

            return restrictions;
        }
    }
}
