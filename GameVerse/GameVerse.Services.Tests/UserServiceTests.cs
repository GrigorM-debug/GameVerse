﻿
using GameVerse.Data.Models.Games.Review;
using GameVerse.Data.Repositories.Interfaces;
using GameVerse.Data;
using GameVerse.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using GameVerse.Data.Models.Games;
using GameVerse.Data.Models.Events;
using GameVerse.Data.Repositories;
using GameVerse.Data.Models.ApplicationUsers;
using GameVerse.Common.Enums;
using GameVerse.Data.Models.Games.Genres;
using GameVerse.Data.Models.Games.Platform;
using GameVerse.Data.Models.Games.Restrictions;
using GameVerse.Data.Models.Carts;

namespace GameVerse.Services.Tests
{
    public class UserServiceTests
    {
        private DbContextOptions<GameVerseDbContext> _dbContextOptions;
        private GameVerseDbContext _dbContext;
        private IUserService _userService;
        private IGenericRepository<UserBoughtGame, object> _userBoughtGameRepository;
        private IGenericRepository<EventRegistration, object> _eventRegistrationRepository;

        [SetUp]
        public async Task Setup()
        {
            _dbContextOptions = new DbContextOptionsBuilder<GameVerseDbContext>()
                .UseInMemoryDatabase("GameVerseInMemoryTest" + Guid.NewGuid().ToString())
                .Options;

            _dbContext = new GameVerseDbContext(_dbContextOptions);

            //Seed the db
            await SeedDatabase();

            _userBoughtGameRepository = new GenericRepository<UserBoughtGame, object>(_dbContext);
            _eventRegistrationRepository = new GenericRepository<EventRegistration, object>(_dbContext);

            _userService = new UserService(_userBoughtGameRepository, _eventRegistrationRepository);
        }

        [TearDown]
        public async Task TearDown()
        {
            await _dbContext.Database.EnsureDeletedAsync();
            await _dbContext.DisposeAsync();
        }

        private async Task SeedDatabase()
        {
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
                PublisherId = Guid.NewGuid()
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

            Event e = new Event()
            {
                Id = Guid.NewGuid(),
                Topic = "Test Event",
                Description = "Test Test Test Description",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddHours(2),
                Latitude = 10.234,
                Longitude = 10.456,
                Seats = 2,
                TicketPrice = 20,
                Image = "testimage",
                PublisherId = Guid.NewGuid(),
                IsDeleted = false,
                EventsCarts = new HashSet<EventCart>()
            };

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

            EventRegistration testEventRegistration = new EventRegistration()
            {
                EventId = e.Id,
                Event = e,
                UserId = user.Id,
                User = user,
                QrCode = "testQrCode",
                RegistrationDate = DateTime.UtcNow,
                TicketQuantity = 1,
            };

            UserBoughtGame testGameBought = new UserBoughtGame()
            {
                GameId = game.Id,
                Game = game,
                UserId = user.Id,
                User = user,
                BoughtOn = DateTime.UtcNow,
                Quantity = 1,
            };

            await _dbContext.Restrictions.AddAsync(restriction);
            await _dbContext.Genres.AddAsync(genre);
            await _dbContext.Platforms.AddAsync(platform);
            await _dbContext.Games.AddAsync(game);
            await _dbContext.Events.AddAsync(e);
            await _dbContext.Users.AddAsync(user);
            await _dbContext.EventsRegistrations.AddAsync(testEventRegistration);
            await _dbContext.UserBoughtGames.AddAsync(testGameBought);
            
            await _dbContext.SaveChangesAsync();
        }

        [Test]
        public async Task GetUserBoughtGamesAsync_ReturnsCorrectViewModel()
        {
            //Arrange 
            Game game = await _dbContext.Games.FirstAsync();
            string userId = "00000000-0000-0000-0000-000000000001";

            var result = await _userService.GetUserBoughtGamesAsync(userId);

            Assert.IsNotNull(result);
        }
    }
}
