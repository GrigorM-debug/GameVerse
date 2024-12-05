﻿

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
using GameVerse.Web.ViewModels.Game;
using GameVerse.Web.ViewModels.Game.SelectLists;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Mail;

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

        [Test]
        public async Task AddGameGetAsync_ShouldReturnPopulatedViewModel()
        {
            //Act
            var result = await _gameService.AddGameGetAsync();

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.GenreSelectList);
            Assert.NotNull(result.PlatformSelectList);
            Assert.NotNull(result.RestrictionSelectList);
            Assert.NotNull(result.GameTypes);

            // Verify the data matches the seeded data
            Assert.That(result.GenreSelectList.Count(), Is.EqualTo(1));
            Assert.That(result.PlatformSelectList.Count(), Is.EqualTo(1));
            Assert.That(result.RestrictionSelectList.Count(), Is.EqualTo(1));
            Assert.IsNotEmpty(result.GameTypes);
        }

        [Test]
        public async Task GameExistByIdAsync_ReturnsTrue_WhenGameExists()
        {
            //Arrange
            Game game = await _dbContext.Games.FirstAsync();
            string gameId = game.Id.ToString();

            //Act
            bool result = await _gameService.GameExistByIdAsync(gameId);

            //Assert
            Assert.True(result);
        }

        [Test]
        public async Task GameExistByIdAsync_ReturnsFalse_WhenGameDoesNotExist()
        {
            //Arrange
            string gameId = Guid.NewGuid().ToString();

            //Act
            bool result = await _gameService.GameExistByIdAsync(gameId);

            //Assert
            Assert.False(result);
        }

        [Test]
        public async Task GetTotalGamesCountAsync_ReturnsTotalGamesCount()
        {
            //Arrange
            int totalGamesCountExpected = 1;

            //Act 
            int result = await _gameService.GetTotalGamesCountAsync();

            Assert.That(result, Is.EqualTo(totalGamesCountExpected));
        }

        [Test]
        public async Task GetGenresAsync_Returns_CorrectlyPopulatedViewModel()
        {
            //Arrange
            IEnumerable<Genre> genres = await _dbContext.Genres.ToListAsync();

            //Act
            IEnumerable<GenreSelectList> result = await _gameService.GetGenresAsync();

            //Assert
            Assert.IsNotEmpty(result);

            foreach(Genre genre in genres)
            {
                foreach(GenreSelectList genreSelect in result)
                {
                    Assert.That(genre.Name, Is.EqualTo(genreSelect.Name));
                    Assert.That(genreSelect.Id, Is.EqualTo(genreSelect.Id));
                }
            }
        }

        [Test]
        public async Task GetPlatformsAsync_Returns_CorrectlyPopulatedViewModel()
        {
            //Arrange
            IEnumerable<Platform> platforms = await _dbContext.Platforms.ToListAsync();

            //Act
            IEnumerable<PlatformSelectList> result = await _gameService.GetPlatformsAsync();

            //Assert
            Assert.IsNotEmpty(result);

            foreach(Platform platform in platforms)
            {
                foreach (PlatformSelectList platformSelect in result)
                {
                    Assert.That(platformSelect.Name, Is.EqualTo(platform.Name));
                    Assert.That(platformSelect.Id, Is.EqualTo(platform.Id));
                }
            }
        }

        [Test]
        public async Task GetRestrictionsAsync_Returns_CorrectlyPopulatedViewModel()
        {
            //Arrange
            IEnumerable<Restriction> restrictions = await _dbContext.Restrictions.ToListAsync();

            //Act
            IEnumerable<RestrictionSelectList> result = await _gameService.GetRestrictionsAsync();

            //Assert
            Assert.IsNotEmpty(result);
        
            foreach(Restriction restriction in restrictions)
            {
                foreach(RestrictionSelectList restrictionSelect in result)
                {
                    Assert.That(restrictionSelect.Name, Is.EqualTo(restriction.Name));
                    Assert.That(restrictionSelect.Id, Is.EqualTo(restriction.Id));
                }
            }
        }

        [Test]
        public void GetGameTypes_Retruns_CorrectlyPopulatedViewModel()
        {
            //Arrange
            List<GameTypeViewModel> expectedGameTypes = new List<GameTypeViewModel>
            {
                new GameTypeViewModel { Value = 1, Text = "PhysicalCopy" },
                new GameTypeViewModel { Value = 2, Text = "DigitalKey" },
            };

            //Act
            List<GameTypeViewModel> result = _gameService.GetGameTypes().ToList();

            //Assert
            Assert.NotNull(result);
            Assert.That(result.Count(), Is.EqualTo(expectedGameTypes.Count()));

            for (int i = 0; i < expectedGameTypes.Count(); i++)
            {
                Assert.That(result[i].Value, Is.EqualTo(expectedGameTypes[i].Value));
                Assert.That(result[i].Text, Is.EqualTo(expectedGameTypes[i].Text));
            }
        }

        [Test]
        public async Task UpdateGameQuantityInStockAsync_UpdatesQuantityInStock_WhenGameExist()
        {
            //Arrange
            Game game = await _dbContext.Games.FirstAsync();
            string gameId = game.Id.ToString();
            int expectedQuantityInStock = 11;

            //Act 
            await _gameService.UpdateGameQuantityInStockAsync(gameId, 1);

            //Assert
            Game gameUpdated = await _dbContext.Games.FirstAsync();
            Assert.That(gameUpdated.QuantityInStock, Is.EqualTo(expectedQuantityInStock));
        }

        [Test]
        public async Task UpdateGameQuantityInStockAsync_DoesNotUpdateQuantityInStock_WhenGameDoesNotExist()
        {
            //Arrange
            string gameId = Guid.NewGuid().ToString();
            int expectedQuantityInStock = 10;

            //Act 
            await _gameService.UpdateGameQuantityInStockAsync(gameId, 1);

            //Assert
            Game game = await _dbContext.Games.FirstAsync();
            Assert.That(game.QuantityInStock, Is.EqualTo(expectedQuantityInStock));
        }

        [Test]
        public async Task GetLast3GamesAsync_ShouldReturnEmptyCollection_WhenNoGamesExist()
        {
            //Arrange
            Game game = await _dbContext.Games.FirstAsync();
            _dbContext.Games.Remove(game);
            await _dbContext.SaveChangesAsync();

            // Act
            IEnumerable<GameIndexViewModel> result = await _gameService.GetLast3GamesAsync();

            // Assert
            Assert.NotNull(result);
            Assert.IsEmpty(result);
        }

        [Test]
        public async Task GetLast3GamesAsync_ShouldReturnCorrectlyPopulatedViewModel_WhenGamesExist()
        {
            //Arrange 
            Game game = await _dbContext.Games.FirstAsync();

            //Act
            IEnumerable<GameIndexViewModel> result = await _gameService.GetLast3GamesAsync();

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Count(), Is.EqualTo(1));

            List<GameIndexViewModel> resultList = result.ToList();

            Assert.That(resultList[0].Title, Is.EqualTo(game.Title));
        }

        [Test]
        public async Task GameExistByTitleAndTypeAsync_ShouldReturnTrue_WhenGameExists()
        {
            //Arrange 
            Game game = await _dbContext.Games.FirstAsync();
            string gameTitle = game.Title;
            GameType type = GameType.DigitalKey;

            //Act
            bool result = await _gameService.GameExistByTitleAndTypeAsync(gameTitle, type);

            //Assert
            Assert.True(result);
        }

        [Test]
        public async Task GameExistByTitleAndTypeAsync_ShouldReturnFalse_WhenGameDoesNotExist()
        {
            //Arrange 
            Game game = await _dbContext.Games.FirstAsync();
            string gameTitle = "Neznam";
            GameType type = GameType.PhysicalCopy;

            //Act
            bool result = await _gameService.GameExistByTitleAndTypeAsync(gameTitle, type);

            //Assert
            Assert.False(result);
        }

        [Test]
        public async Task DeleteGameGetAsync_ShouldReturnGameDeleteViewModel_WhenGameExistsAndModeratorIsPublisher()
        {
            //Arrange
            Game game = _dbContext.Games.First();
            string gameId = game.Id.ToString();
            bool isAdmin = false;

            // Act
            GameDeleteViewModel result = await _gameService.DeleteGameGetAsync(gameId, game.PublisherId.ToString(), isAdmin); // Moderator is the publisher

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Id, Is.EqualTo(game.Id.ToString()));
            Assert.That(result.Title, Is.EqualTo(game.Title));
            Assert.That(result.PublisherId, Is.EqualTo(game.PublisherId.ToString()));
            Assert.That(result.PublisherName, Is.EqualTo(game.Publisher.User.UserName));
        }

        [Test]
        public async Task DeleteGameGetAsync_ShouldReturnGameDeleteViewModel_WhenGameExistsAndUserIsAdmin()
        {
            //Arrange
            bool isAdmin = true;
            Game game = await _dbContext.Games.FirstAsync();

            //Act
            GameDeleteViewModel result = await _gameService.DeleteGameGetAsync(game.Id.ToString(), "123", isAdmin);

            //Assert
            Assert.NotNull(result);
            Assert.That(result.Id, Is.EqualTo(game.Id.ToString()));
            Assert.That(result.Title, Is.EqualTo(game.Title));
            Assert.That(result.PublisherId, Is.EqualTo(game.PublisherId.ToString()));
            Assert.That(result.PublisherName, Is.EqualTo(game.Publisher.User.UserName));
        }

        [Test]
        public async Task DeleteGameGetAsync_ShouldReturnNull_WhenGameDoesNotExistOrIsDeleted()
        {
            // Act
            GameDeleteViewModel result = await _gameService.DeleteGameGetAsync("1", "1", false);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task DeleteGamePostAsync_ShouldMarkGameAsDeleted_WhenModeratorIsPublisher()
        {
            // Arrange
            string gameId = "00000000-0000-0000-0000-000000000002";
            string moderatorId = _dbContext.Moderators.First().Id.ToString(); 
            bool isAdmin = false;

            // Act
            await _gameService.DeleteGamePostAsync(gameId, moderatorId, isAdmin);

            // Assert
            Game game = await _gameRepository.FirstOrDefaultAsync(g => g.Id.ToString() == gameId);
            Assert.NotNull(game);
            Assert.IsTrue(game.IsDeleted);
        }

        [Test]
        public async Task DeleteGamePostAsync_ShouldMarkGameAsDeleted_WhenUserIsAdmin()
        {
            // Arrange
            string gameId = "00000000-0000-0000-0000-000000000002";
            string moderatorId = "not-a-real-id"; 
            bool isAdmin = true;

            // Act
            await _gameService.DeleteGamePostAsync(gameId, moderatorId, isAdmin);

            // Assert
            Game? game = await _gameRepository.FirstOrDefaultAsync(g => g.Id.ToString() == gameId);
            Assert.NotNull(game);
            Assert.IsTrue(game.IsDeleted);
        }

        [Test]
        public async Task DeleteGamePostAsync_ShouldDoNothing_WhenGameDoesNotExist()
        {
            // Arrange
            string nonExistentGameId = "00000000-0000-0000-0000-000000000003"; 
            string moderatorId = _dbContext.Moderators.First().Id.ToString();
            bool isAdmin = false;

            // Act
            await _gameService.DeleteGamePostAsync(nonExistentGameId, moderatorId, isAdmin);

            // Assert
            Game? game = await _gameRepository.FirstOrDefaultAsync(g => g.Id.ToString() == nonExistentGameId);
            Assert.IsNull(game);
        }

        [Test]
        public async Task GetAllGamesAsync_ShouldReturnPaginatedGames_WhenNoFiltersOrSorting()
        {
            // Arrange
            int currentPage = 1;
            int gamesPerPage = 2; // Retrieve 2 games per page
            EntitySortOrder sortOrder = EntitySortOrder.Newest;
            string? searchString = null;
            GameType? gameSelectedGameTypeSortOrder = null;

            // Act
            IEnumerable<GameIndexViewModel> result = await _gameService.GetAllGamesAsync(currentPage, gamesPerPage, sortOrder, searchString, gameSelectedGameTypeSortOrder);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Count(), Is.EqualTo(1)); 
            Assert.That(result.First().Title, Is.EqualTo("Test Game")); 
        }

        [Test]
        public async Task GetAllGamesAsync_ShouldFilterGames_BySearchString()
        {
            // Arrange
            int currentPage = 1;
            int gamesPerPage = 5;
            var sortOrder = EntitySortOrder.Newest;
            string searchString = "Test Game"; 
            GameType? gameSelectedGameTypeSortOrder = null;

            // Act
            IEnumerable<GameIndexViewModel> result = await _gameService.GetAllGamesAsync(currentPage, gamesPerPage, sortOrder, searchString, gameSelectedGameTypeSortOrder);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Count(), Is.EqualTo(1)); 
            Assert.That(result.First().Title, Is.EqualTo("Test Game"));
        }

        [Test]
        public async Task GetAllGamesAsync_ShouldFilterGames_ByGameType()
        {
            // Arrange
            int currentPage = 1;
            int gamesPerPage = 5;
            var sortOrder = EntitySortOrder.Newest;
            string? searchString = null;
            GameType? gameSelectedGameTypeSortOrder = GameType.DigitalKey; 

            // Act
            IEnumerable<GameIndexViewModel> result = await _gameService.GetAllGamesAsync(currentPage, gamesPerPage, sortOrder, searchString, gameSelectedGameTypeSortOrder);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Count(), Is.EqualTo(1)); 
        }

        [Test]
        public async Task GetAllGamesAsync_ShouldReturnEmptyCollection_WhenNoGamesExist()
        {
            // Arrange
            Game game = await _dbContext.Games.FirstAsync();
            _dbContext.Remove(game);
            await _dbContext.SaveChangesAsync();
            int currentPage = 1;
            int gamesPerPage = 5;
            var sortOrder = EntitySortOrder.Newest;
            string? searchString = null;
            GameType? gameSelectedGameTypeSortOrder = null;

            // Act
            IEnumerable<GameIndexViewModel> result = await _gameService.GetAllGamesAsync(currentPage, gamesPerPage, sortOrder, searchString, gameSelectedGameTypeSortOrder);

            // Assert
            Assert.NotNull(result);
            Assert.IsEmpty(result); // Ensure the result is empty
        }


        [Test]
        public async Task GetAllGamesAsync_ShouldSortGames_ByNewestFirst()
        {
            // Arrange
            int currentPage = 1;
            int gamesPerPage = 5;
            EntitySortOrder sortOrder = EntitySortOrder.Newest;
            string? searchString = null;
            GameType? gameSelectedGameTypeSortOrder = null;

            // Act
            IEnumerable<GameIndexViewModel> result = await _gameService.GetAllGamesAsync(currentPage, gamesPerPage, sortOrder, searchString, gameSelectedGameTypeSortOrder);

            // Assert
            Assert.NotNull(result);

            List<GameIndexViewModel> resultList = result.ToList();

            Assert.IsTrue(resultList.Count() == 1); // Ensure there is more than one result to test sorting
            for (int i = 1; i < resultList.Count; i++)
            {
                Assert.IsTrue(
                    DateTime.Parse(resultList[i - 1].CreatedOn) >= DateTime.Parse(resultList[i].CreatedOn)
                );
            }
        }


        [Test]
        public async Task GetAllGamesAsync_ShouldSortGames_ByOldestFirst()
        {
            // Arrange
            int currentPage = 1;
            int gamesPerPage = 5;
            var sortOrder = EntitySortOrder.Oldest;
            string? searchString = null;
            GameType? gameSelectedGameTypeSortOrder = null;

            // Act
            IEnumerable<GameIndexViewModel> result = await _gameService.GetAllGamesAsync(currentPage, gamesPerPage, sortOrder, searchString, gameSelectedGameTypeSortOrder);

            // Assert
            Assert.NotNull(result);

            List<GameIndexViewModel> resultList = result.ToList();
            Assert.IsTrue(resultList.Count == 1); 

            for (int i = 1; i < resultList.Count; i++)
            {
                Assert.IsTrue(
                    DateTime.Parse(resultList[i - 1].CreatedOn) <= DateTime.Parse(resultList[i].CreatedOn)
                );
            }
        }


    }
}
