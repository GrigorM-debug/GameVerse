

using GameVerse.Common.Enums;
using GameVerse.Data;
using GameVerse.Data.Models.ApplicationUsers;
using GameVerse.Data.Models.Games;
using GameVerse.Data.Models.Games.Genres;
using GameVerse.Data.Models.Games.Platform;
using GameVerse.Data.Models.Games.Restrictions;
using GameVerse.Data.Repositories;
using GameVerse.Data.Repositories.Interfaces;
using GameVerse.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameVerse.Services.Tests
{
    public class GameServiceTests
    {
        private DbContextOptions<GameVerseDbContext> _dbContextOptions;
        private GameVerseDbContext _dbContext;
        private IGameService _gameService;
        private IGenericRepository<Game, Guid> _gameRepository;
        private IGenericRepository<Genre,  Guid> _genreRepository;
        private IGenericRepository<Platform, Guid> _platformRepository;
        private IGenericRepository<Restriction, Guid> _restrictionRepository;

        [SetUp]
        public async Task SetUp()
        {
            _dbContextOptions = new DbContextOptionsBuilder<GameVerseDbContext>()
                .UseInMemoryDatabase("GameVerseInMemoryTest" + Guid.NewGuid().ToString())
                .Options;

            _dbContext = new GameVerseDbContext(_dbContextOptions);

            await SeedDatabase();

            _gameRepository = new GenericRepository<Game, Guid>(_dbContext);
            _genreRepository = new GenericRepository<Genre, Guid>(_dbContext);
            _platformRepository = new GenericRepository<Platform, Guid>(_dbContext);
            _restrictionRepository = new GenericRepository<Restriction, Guid>(_dbContext);

            _gameService = new GameService(
                _gameRepository,
                _genreRepository,
                _platformRepository,
                _restrictionRepository
            );
        }

        [TearDown]
        public async Task TearDown()
        {
            await _dbContext.Database.EnsureDeletedAsync();
            await _dbContext.DisposeAsync();
        }

        private async Task SeedDatabase()
        {
            ApplicationUser user = new ApplicationUser()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                UserName = "TestUser",
                NormalizedUserName = "TESTUSER",
                Email = "test@abv.bg",
                NormalizedEmail = "test@abv.bg",
                FirstName = "Test",
                LastName = "Testov"
            };

            Moderator moderator = new Moderator()
            {
                Id = Guid.NewGuid(),
                User = user,
                UserId = user.Id,
                TotalEventsCreated = 0,
                TotalGamesCreated = 0,
            };

            Restriction restriction = new Restriction()
            {
                Id = Guid.NewGuid(),
                Name = "Test Restriction"
            };

            Genre genre = new Genre()
            {
                Id = Guid.NewGuid(),
                Name = "Test Genre"
            };

            Platform platform = new Platform()
            {
                Id = Guid.NewGuid(),
                Name = "Test Platform"
            };

            Game game = new Game()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                Title = "Test Game",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                PublishingStudio = "Test Studio",
                YearPublished = 2010,
                CreatedOn = DateTime.UtcNow,
                Price = 20,
                Image = "wdffffffffffffffffffffff",
                QuantityInStock = 10,
                Type = GameType.DigitalKey,
                IsDeleted = false,
                PublisherId = moderator.Id
            };

            game.GamesGenres.Add(new GameGenre()
            {
                Genre = genre,
                Game = game,
            });

            game.GamesPlatforms.Add(new GamePlatform()
            {
                Game = game,
                Platform = platform
            });

            game.GamesRestrictions.Add(new GameRestriction()
            {
                Game = game,
                Restriction = restriction
            });

            await _dbContext.Users.AddAsync(user);
            await _dbContext.Moderators.AddAsync(moderator);
            await _dbContext.Restrictions.AddAsync(restriction);
            await _dbContext.Genres.AddAsync(genre);
            await _dbContext.Platforms.AddAsync(platform);
            await _dbContext.Games.AddAsync(game);
            await _dbContext.SaveChangesAsync();
        }

        [Test]
        public async Task GetGameByIdAsync_ReturnsGame_WhenGameExist()
        {
            //Arrange
            Game game = await _dbContext.Games.FirstAsync();
            string gameId = game.Id.ToString();

            //Act
            Game? result = await _gameService.GetGameByIdAsync(gameId);

            //Assert
            Assert.IsNotNull(result);
            Assert.That(game.Id, Is.EqualTo(result.Id));
            Assert.That(game.Title, Is.EqualTo(result.Title));
            Assert.That(game.Image, Is.EqualTo(result.Image));
            Assert.That(game.Description, Is.EqualTo(result.Description));
            Assert.That(game.CreatedOn, Is.EqualTo(result.CreatedOn));
            Assert.That(game.Price, Is.EqualTo(result.Price));
            Assert.That(game.Type, Is.EqualTo(result.Type));
            Assert.That(game.PublisherId, Is.EqualTo(result.PublisherId));
        }

        [Test]
        public async Task GetGameByIdAsync_ReturnsNull_WhenGameDoesNotExist()
        {
            //Arrange
            string gameId = Guid.NewGuid().ToString();

            //Act
            Game? result = await _gameService.GetGameByIdAsync(gameId);

            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task GetGameByIdAsTrackingAsync_ReturnsGame_WhenGameExist()
        {
            //Arrange
            Game game = await _dbContext.Games.FirstAsync();
            string gameId = game.Id.ToString();

            //Act
            Game? result = await _gameService.GetGameByIdAsTrackingAsync(gameId);

            //Assert
            Assert.IsNotNull(result);
            Assert.That(game.Id, Is.EqualTo(result.Id));
            Assert.That(game.Title, Is.EqualTo(result.Title));
            Assert.That(game.Image, Is.EqualTo(result.Image));
            Assert.That(game.Description, Is.EqualTo(result.Description));
            Assert.That(game.CreatedOn, Is.EqualTo(result.CreatedOn));
            Assert.That(game.Price, Is.EqualTo(result.Price));
            Assert.That(game.Type, Is.EqualTo(result.Type));
            Assert.That(game.PublisherId, Is.EqualTo(result.PublisherId));
        }

        [Test]
        public async Task GetGameByIdAsTrackingAsync_ReturnsNull_WhenGameDoesNotExist()
        {
            //Arrange
            string gameId = Guid.NewGuid().ToString();

            //Act
            Game? result = await _gameService.GetGameByIdAsTrackingAsync(gameId);

            //Assert
            Assert.IsNull(result);
        }


    }
}
