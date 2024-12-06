

using GameVerse.Common.Enums;
using GameVerse.Data;
using GameVerse.Data.Models.ApplicationUsers;
using GameVerse.Data.Models.Games.Genres;
using GameVerse.Data.Models.Games.Platform;
using GameVerse.Data.Models.Games.Restrictions;
using GameVerse.Data.Models.Games;
using GameVerse.Data.Repositories;
using GameVerse.Data.Repositories.Interfaces;
using GameVerse.Web.Areas.Moderator.Services;
using GameVerse.Web.Areas.Moderator.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using GameVerse.Data.Models.Events;

namespace GameVerse.Services.Tests
{
    [TestFixture]
    public class ModeratorArea_ModeratorServiceTests
    {
        private DbContextOptions<GameVerseDbContext> _dbContextOptions;
        private GameVerseDbContext _dbContext;
        private IModeratorService _moderatorService;
        private IGenericRepository<Moderator, Guid> _moderatorRepository;

        [SetUp]
        public async Task SetUp()
        {
            _dbContextOptions = new DbContextOptionsBuilder<GameVerseDbContext>()
                .UseInMemoryDatabase("GameVerseInMemoryTest" + Guid.NewGuid().ToString())
                .Options;

            _dbContext = new GameVerseDbContext(_dbContextOptions);

            //Seed the db
            await SeedDatabase();
            
            _moderatorRepository = new GenericRepository<Moderator, Guid>(_dbContext);
            _moderatorService = new GameVerse.Web.Areas.Moderator.Services.ModeratorService(_moderatorRepository);
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
                TotalEventsCreated = 2,
                TotalGamesCreated = 2,
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

            Game game2 = new Game()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                Title = "Test Game2",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",
                PublishingStudio = "Test Studio2",
                YearPublished = 2011,
                CreatedOn = DateTime.UtcNow.AddDays(2),
                Price = 20,
                Image = "wdffffffffffffffffffffff",
                QuantityInStock = 10,
                Type = GameType.DigitalKey,
                IsDeleted = false,
                PublisherId = moderator.Id
            };

            game2.GamesGenres.Add(new GameGenre()
            {
                Genre = genre,
                Game = game2,
            });

            game2.GamesPlatforms.Add(new GamePlatform()
            {
                Game = game2,
                Platform = platform
            });

            game2.GamesRestrictions.Add(new GameRestriction()
            {
                Game = game2,
                Restriction = restriction
            });

            Event e = new Event()
            {
                Topic = "Test Event",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddHours(2),
                Latitude = 10.200,
                Longitude = 11.20,
                Seats = 1,
                TicketPrice = 20,
                Image = "testimageurl",
                PublisherId = moderator.Id,
                IsDeleted = false,
            };

            Event e2 = new Event()
            {
                Topic = "Test Event2",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddHours(2),
                Latitude = 10.200,
                Longitude = 11.20,
                Seats = 1,
                TicketPrice = 20,
                Image = "testimageurl",
                PublisherId = moderator.Id,
                IsDeleted = false,
            };

            await _dbContext.Users.AddAsync(user);
            await _dbContext.Moderators.AddAsync(moderator);
            await _dbContext.Restrictions.AddAsync(restriction);
            await _dbContext.Genres.AddAsync(genre);
            await _dbContext.Platforms.AddAsync(platform);
            await _dbContext.Games.AddRangeAsync(game, game2);
            await _dbContext.Events.AddRangeAsync(e, e2);
            await _dbContext.SaveChangesAsync();
        }

        [Test]
        public async Task TotalEventsCreatedAsync_ShouldReturnTotalCreatedEventsCount_WhenModeratorHasEvents()
        {
            //Arrange
            ApplicationUser user = await _dbContext.Users.FirstAsync();
            string userId = user.Id.ToString();
            int expectedCount = 2;

            //Act
            int result = await _moderatorService.TotalEventsCreatedAsync(userId);

            //Assert
            Assert.That(result, Is.EqualTo(expectedCount));
        }

        [Test]
        public async Task TotalEventsCreatedAsync_ShouldReturnZero_WhenModeratorHasNotEvents()
        {
            //Arrange
            ApplicationUser user = await _dbContext.Users.FirstAsync();
            string userId = user.Id.ToString();
            Moderator moderator = await _dbContext.Moderators.FirstAsync();

            moderator.TotalEventsCreated = 0;
            await _dbContext.SaveChangesAsync();

            //Act
            int result = await _moderatorService.TotalEventsCreatedAsync(userId);

            //Assert
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public async Task TotalGamesCreatedAsync_ShouldReturnTotalCreatedGamesCount_WhenModeratorHasGames()
        {
            //Arrange
            ApplicationUser user = await _dbContext.Users.FirstAsync();
            string userId = user.Id.ToString();
            int expectedCount = 2;

            //Act
            int result = await _moderatorService.TotalGamesCreatedAsync(userId);

            //Assert
            Assert.That(result, Is.EqualTo(expectedCount));
        }

        [Test]
        public async Task TotalGamesCreatedAsync_ShouldReturnZero_WhenModeratorHasNoTGames()
        {
            //Arrange
            ApplicationUser user = await _dbContext.Users.FirstAsync();
            string userId = user.Id.ToString();
            Moderator moderator = await _dbContext.Moderators.FirstAsync();
            moderator.TotalGamesCreated = 0;
            await _dbContext.SaveChangesAsync();
            int expectedCount = 0;

            //Act
            int result = await _moderatorService.TotalGamesCreatedAsync(userId);

            //Assert
            Assert.That(result, Is.EqualTo(expectedCount));
        }
    }
}
