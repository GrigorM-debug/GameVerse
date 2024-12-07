

using GameVerse.Common.Enums;
using GameVerse.Data;
using GameVerse.Data.Models.ApplicationUsers;
using GameVerse.Data.Models.Games;
using GameVerse.Data.Models.Games.Genres;
using GameVerse.Data.Models.Games.Platform;
using GameVerse.Data.Models.Games.Restrictions;
using GameVerse.Data.Models.Games.Review;
using GameVerse.Data.Repositories;
using GameVerse.Data.Repositories.Interfaces;
using GameVerse.Services.Interfaces;
using GameVerse.Web.ViewModels.Game;
using GameVerse.Web.ViewModels.Game.Details;
using GameVerse.Web.ViewModels.Game.SelectLists;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Mail;

namespace GameVerse.Services.Tests
{
    [TestFixture]
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

            ApplicationUser user2 = new ApplicationUser()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                UserName = "TestUser2",
                NormalizedUserName = "TESTUSER2",
                Email = "test2@abv.bg",
                NormalizedEmail = "test2@abv.bg",
                FirstName = "Test2",
                LastName = "Testov2"
            };

            Moderator moderator = new Moderator()
            {
                Id = Guid.NewGuid(),
                User = user,
                UserId = user.Id,
                TotalEventsCreated = 0,
                TotalGamesCreated = 0,
            };

            GameReview review = new GameReview()
            {
                Id = Guid.NewGuid(),
                Content = "Test review",
                Rating = 5,
                IsDeleted = false,
                ReviewerId = user2.Id,
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

            game.Reviews.Add(review);

            await _dbContext.Users.AddRangeAsync(user, user2);
            await _dbContext.Moderators.AddAsync(moderator);
            await _dbContext.Restrictions.AddAsync(restriction);
            await _dbContext.Genres.AddAsync(genre);
            await _dbContext.Platforms.AddAsync(platform);
            await _dbContext.Games.AddRangeAsync(game, game2);
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
            int totalGamesCountExpected = 2;

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
            Game game2 = await _dbContext.Games.LastAsync();
            _dbContext.Games.RemoveRange(game, game2);
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
            Game game2 = await _dbContext.Games.LastAsync();
            //Act
            IEnumerable<GameIndexViewModel> result = await _gameService.GetLast3GamesAsync();

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Count(), Is.EqualTo(2));

            List<GameIndexViewModel> resultList = result.ToList();

            Assert.That(resultList[0].Title, Is.EqualTo(game2.Title));
            Assert.That(resultList[1].Title, Is.EqualTo(game.Title));
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
            string nonExistentGameId = "00000000-0000-0000-0000-000000000013"; 
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
            Assert.That(result.Count(), Is.EqualTo(2)); 
            Assert.That(result.First().Title, Is.EqualTo("Test Game2")); 
        }

        [Test]
        public async Task GetAllGamesAsync_ShouldFilterGames_BySearchString()
        {
            // Arrange
            int currentPage = 1;
            int gamesPerPage = 5;
            var sortOrder = EntitySortOrder.Newest;
            string searchString = "Test Game2"; 
            GameType? gameSelectedGameTypeSortOrder = null;

            // Act
            IEnumerable<GameIndexViewModel> result = await _gameService.GetAllGamesAsync(currentPage, gamesPerPage, sortOrder, searchString, gameSelectedGameTypeSortOrder);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Count(), Is.EqualTo(1)); 
            Assert.That(result.First().Title, Is.EqualTo("Test Game2"));
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
            Assert.That(result.Count(), Is.EqualTo(2)); 
        }

        [Test]
        public async Task GetAllGamesAsync_ShouldReturnEmptyCollection_WhenNoGamesExist()
        {
            // Arrange
            Game game = await _dbContext.Games.FirstAsync();
            Game game2 = await _dbContext.Games.LastAsync();
            _dbContext.Remove(game);
            _dbContext.Remove(game2);
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

            Assert.IsTrue(resultList.Count() == 2); // Ensure there is more than one result to test sorting
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
            Assert.IsTrue(resultList.Count > 1); 

            for (int i = 1; i < resultList.Count; i++)
            {
                Assert.IsTrue(
                    DateTime.Parse(resultList[i - 1].CreatedOn) <= DateTime.Parse(resultList[i].CreatedOn)
                );
            }
        }

        [Test]
        public async Task EditGameGetAsync_ShouldReturnGameInputViewModel_WhenGameExistsAndIsAccessibleByModerator()
        {
            // Arrange
            string gameId = "00000000-0000-0000-0000-000000000002"; 
            string moderatorId = _dbContext.Moderators.First().Id.ToString(); 
            bool isAdmin = false;
            Game game1 = await _dbContext.Games.FirstOrDefaultAsync(g=> g.Id.ToString() == gameId);

            // Act
            GameInputViewModel result = await _gameService.EditGameGetAsync(gameId, moderatorId, isAdmin);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Title, Is.EqualTo(game1.Title));
            Assert.That(result.Description, Is.EqualTo(game1.Description));
            Assert.That(result.PublishingStudio, Is.EqualTo(game1.PublishingStudio));
            Assert.That(result.YearPublished, Is.EqualTo(game1.YearPublished));
            Assert.That(result.Price, Is.EqualTo(game1.Price));

            Assert.NotNull(result.GenreSelectList);
            Assert.NotNull(result.PlatformSelectList);
            Assert.NotNull(result.RestrictionSelectList);
            Assert.NotNull(result.GameTypes);

            Assert.That(result.SelectedGenres.Count(), Is.EqualTo(1));
            Assert.That(result.SelectedPlatforms.Count(), Is.EqualTo(1));
            Assert.That(result.SelectedRestrictions.Count(), Is.EqualTo(1));
        }

        [Test]
        public async Task EditGameGetAsync_ShouldReturnGameInputViewModel_WhenGameExistsAndIsAccessibleByAdmin()
        {
            // Arrange
            string gameId = "00000000-0000-0000-0000-000000000002"; 
            string moderatorId = "not-a-real-id"; 
            bool isAdmin = true; 
            Game game1 = await _dbContext.Games.FirstOrDefaultAsync(g => g.Id.ToString() == gameId);

            // Act
            GameInputViewModel result = await _gameService.EditGameGetAsync(gameId, moderatorId, isAdmin);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Title, Is.EqualTo(game1.Title)); 
            Assert.That(result.Price, Is.EqualTo(game1.Price));
            Assert.That(result.Description, Is.EqualTo(game1.Description));
            Assert.That(result.PublishingStudio, Is.EqualTo(game1.PublishingStudio));
            Assert.That(result.YearPublished, Is.EqualTo(game1.YearPublished));

            Assert.NotNull(result.GenreSelectList);
            Assert.NotNull(result.PlatformSelectList);
            Assert.NotNull(result.RestrictionSelectList);
            Assert.NotNull(result.GameTypes);

            Assert.That(result.SelectedGenres.Count(), Is.EqualTo(1));
            Assert.That(result.SelectedPlatforms.Count(), Is.EqualTo(1));
            Assert.That(result.SelectedRestrictions.Count(), Is.EqualTo(1));
        }

        [Test]
        public async Task EditGameGetAsync_ShouldReturnNull_WhenGameDoesNotExistOrIsDeleted()
        {
            // Arrange
            string nonExistentGameId = "00000000-0000-0000-0000-000000000004"; 
            string moderatorId = _dbContext.Moderators.First().Id.ToString();
            bool isAdmin = false;

            // Act
            GameInputViewModel result = await _gameService.EditGameGetAsync(nonExistentGameId, moderatorId, isAdmin);

            // Assert
            Assert.IsNull(result); 
        }

        [Test]
        public async Task AddGamePostAsync_ShouldAddGameSuccessfully_WithAllDetails()
        {
            // Arrange
            var inputModel = new GameInputViewModel
            {
                Title = "New Test Game",
                Description = "This is a test game.",
                PublishingStudio = "Test Studio",
                YearPublished = 2023,
                Price = 50.0m,
                Image = "test-image-url",
                QuantityInStock = 100,
                Type = GameType.DigitalKey,
                SelectedGenres = new List<Guid> { _dbContext.Genres.First().Id },
                SelectedPlatforms = new List<Guid> { _dbContext.Platforms.First().Id },
                SelectedRestrictions = new List<Guid> { _dbContext.Restrictions.First().Id }
            };

            DateTime createdOn = DateTime.UtcNow;
            string moderatorId = _dbContext.Moderators.First().Id.ToString();

            // Act
            string result = await _gameService.AddGamePostAsync(inputModel, createdOn, moderatorId);

            // Assert
            Assert.NotNull(result);

            var addedGame = await _dbContext.Games.FindAsync(Guid.Parse(result));
            Assert.NotNull(addedGame);
            Assert.That(addedGame.Title, Is.EqualTo("New Test Game"));
            Assert.That(addedGame.Price, Is.EqualTo(50.0m));
            Assert.That(addedGame.PublishingStudio, Is.EqualTo("Test Studio"));
            Assert.That(addedGame.CreatedOn, Is.EqualTo(createdOn));

            Assert.That(addedGame.GamesGenres.Count, Is.EqualTo(1));
            Assert.That(addedGame.GamesPlatforms.Count, Is.EqualTo(1));
            Assert.That(addedGame.GamesRestrictions.Count, Is.EqualTo(1));
        }

        [Test]
        public async Task EditGamePostAsync_ShouldUpdateGameDetails_WhenModeratorHasAccess()
        {
            // Arrange
            string gameId = "00000000-0000-0000-0000-000000000002"; 
            string moderatorId = _dbContext.Moderators.First().Id.ToString();
            DateTime createdOn = DateTime.UtcNow;

            GameInputViewModel inputModel = new GameInputViewModel
            {
                Title = "Updated Test Game",
                Description = "Updated description for the test game.",
                PublishingStudio = "Updated Studio",
                YearPublished = 2025,
                Price = 60.0m,
                Image = "updated-image-url",
                QuantityInStock = 120,
                Type = GameType.PhysicalCopy,
                SelectedGenres = new List<Guid> { _dbContext.Genres.First().Id },
                SelectedPlatforms = new List<Guid> { _dbContext.Platforms.First().Id },
                SelectedRestrictions = new List<Guid> { _dbContext.Restrictions.First().Id }
            };

            // Act
            string result = await _gameService.EditGamePostAsync(inputModel, createdOn, gameId, moderatorId, false);

            // Assert
            Assert.NotNull(result);

            Game updatedGame = await _dbContext.Games.FindAsync(Guid.Parse(result));
            Assert.NotNull(updatedGame);
            Assert.That(updatedGame.Title, Is.EqualTo("Updated Test Game"));
            Assert.That(updatedGame.Price, Is.EqualTo(60.0m));
            Assert.That(updatedGame.PublishingStudio, Is.EqualTo("Updated Studio"));
            Assert.That(updatedGame.YearPublished, Is.EqualTo(2025));

            // Verify associations
            Assert.That(updatedGame.GamesGenres.Count(g => !g.IsDeleted), Is.EqualTo(1));
            Assert.That(updatedGame.GamesPlatforms.Count(p => !p.IsDeleted), Is.EqualTo(1));
            Assert.That(updatedGame.GamesRestrictions.Count(r => !r.IsDeleted), Is.EqualTo(1));
        }


        [Test]
        public async Task EditGamePostAsync_ShouldUpdateGameDetails_WhenAdminHasAccess()
        {
            // Arrange
            string gameId = "00000000-0000-0000-0000-000000000002";
            string moderatorId = "not-a-real-id"; 
            DateTime createdOn = DateTime.UtcNow;

            GameInputViewModel inputModel = new GameInputViewModel
            {
                Title = "Admin Updated Game",
                Description = "Admin updated description.",
                PublishingStudio = "Admin Updated Studio",
                YearPublished = 2026,
                Price = 70.0m,
                Image = "admin-updated-image-url",
                QuantityInStock = 150,
                Type = GameType.DigitalKey,
                SelectedGenres = new List<Guid> { _dbContext.Genres.First().Id },
                SelectedPlatforms = new List<Guid> { _dbContext.Platforms.First().Id },
                SelectedRestrictions = new List<Guid> { _dbContext.Restrictions.First().Id }
            };

            // Act
            string result = await _gameService.EditGamePostAsync(inputModel, createdOn, gameId, moderatorId, true);

            // Assert
            Assert.NotNull(result);

            Game updatedGame = await _dbContext.Games.FindAsync(Guid.Parse(result));
            Assert.NotNull(updatedGame);
            Assert.That(updatedGame.Title, Is.EqualTo("Admin Updated Game"));
            Assert.That(updatedGame.Price, Is.EqualTo(70.0m));
            Assert.That(updatedGame.PublishingStudio, Is.EqualTo("Admin Updated Studio"));
            Assert.That(updatedGame.YearPublished, Is.EqualTo(2026));
        }

        [Test]
        public async Task EditGamePostAsync_ShouldUpdateGameAssociationsCorrectly()
        {
            // Arrange
            string gameId = "00000000-0000-0000-0000-000000000002";
            string moderatorId = _dbContext.Moderators.First().Id.ToString();
            DateTime createdOn = DateTime.UtcNow;

            var inputModel = new GameInputViewModel
            {
                Title = "Association Test Game",
                Description = "Testing associations.",
                PublishingStudio = "Test Studio",
                YearPublished = 2024,
                Price = 55.0m,
                Image = "association-test-image-url",
                QuantityInStock = 80,
                Type = GameType.PhysicalCopy,
                SelectedGenres = new List<Guid>(), // No genres
                SelectedPlatforms = new List<Guid> { _dbContext.Platforms.First().Id },
                SelectedRestrictions = new List<Guid>() // No restrictions
            };

            // Act
            string result = await _gameService.EditGamePostAsync(inputModel, createdOn, gameId, moderatorId, false);

            // Assert
            Assert.NotNull(result);

            Game updatedGame = await _dbContext.Games.FindAsync(Guid.Parse(result));
            Assert.NotNull(updatedGame);

            // Verify associations
            Assert.That(updatedGame.GamesGenres.Count(g => !g.IsDeleted), Is.EqualTo(0)); // No genres
            Assert.That(updatedGame.GamesPlatforms.Count(p => !p.IsDeleted), Is.EqualTo(1)); // One platform
            Assert.That(updatedGame.GamesRestrictions.Count(r => !r.IsDeleted), Is.EqualTo(0));
        }


        [Test]
        public async Task GetGameDetailsByIdAsync_ShouldReturnGameDetails_WhenGameExists()
        {
            // Arrange
            string gameId = "00000000-0000-0000-0000-000000000002"; 
            Game game = await _dbContext.Games.FirstOrDefaultAsync(g => g.Id.ToString() == gameId);

            // Act
            GameDetailsViewModel result = await _gameService.GetGameDetailsByIdAsync(gameId);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Title, Is.EqualTo(game.Title));
            Assert.That(result.Description, Is.EqualTo(game.Description));
            Assert.That(result.PublishingStudio, Is.EqualTo(game.PublishingStudio));
            Assert.That(result.YearPublished, Is.EqualTo(game.YearPublished));
            Assert.That(result.Publisher, Is.EqualTo(game.Publisher.User.UserName));

            // Verify related data
            Assert.That(result.Platforms.Count(), Is.EqualTo(1));
            Assert.That(result.Platforms.First().Name, Is.EqualTo("Test Platform"));

            Assert.That(result.Restrictions.Count(), Is.EqualTo(1));
            Assert.That(result.Restrictions.First().Name, Is.EqualTo("Test Restriction"));

            Assert.That(result.Genres.Count(), Is.EqualTo(1));
            Assert.That(result.Genres.First().Name, Is.EqualTo("Test Genre"));

            Assert.That(result.Reviews.Count(), Is.EqualTo(1));
            Assert.That(result.Reviews.First().Rating, Is.EqualTo(5));

            Assert.That(result.AverageRating, Is.EqualTo(5.0));
        }

        [Test]
        public async Task GetGameDetailsByIdAsync_ShouldCalculateAverageRatingCorrectly()
        {
            // Arrange
            string gameId = "00000000-0000-0000-0000-000000000002";

            List<GameReview> reviews = new List<GameReview>
            {
                new GameReview
                {
                    Id = Guid.NewGuid(),
                    GameId = Guid.Parse(gameId),
                    Content = "Great game!",
                    Rating = 4,
                    CreatedOn = DateTime.UtcNow,
                    ReviewerId = _dbContext.Users.First().Id,
                    IsDeleted = false
                },
                new GameReview
                {
                    Id = Guid.NewGuid(),
                    GameId = Guid.Parse(gameId),
                    Content = "Not bad.",
                    Rating = 3,
                    CreatedOn = DateTime.UtcNow,
                    ReviewerId = _dbContext.Users.First().Id,
                    IsDeleted = false
                }
            };

            await _dbContext.GameReviews.AddRangeAsync(reviews);
            await _dbContext.SaveChangesAsync();

            // Act
            GameDetailsViewModel result = await _gameService.GetGameDetailsByIdAsync(gameId);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Reviews.Count(), Is.EqualTo(3));
            Assert.That(result.AverageRating, Is.EqualTo(4));
        }

        [Test]
        public async Task GetGameDetailsByIdAsync_ShouldHandleGameWithNoReviews()
        {
            // Arrange
            string gameId = Guid.NewGuid().ToString();
            Genre genre = _dbContext.Genres.First();
            Platform platform = _dbContext.Platforms.First();
            Restriction restriction = _dbContext.Restrictions.First();

            Game game = new Game
            {
                Id = Guid.Parse(gameId),
                Title = "No Reviews Test Game",
                Description = "This game has genres, platforms, and restrictions but no reviews.",
                PublishingStudio = "Test Studio",
                YearPublished = 2023,
                CreatedOn = DateTime.UtcNow,
                Price = 30.0m,
                Image = "test-image-url",
                QuantityInStock = 20,
                Type = GameType.DigitalKey,
                PublisherId = _dbContext.Moderators.First().Id,
                IsDeleted = false
            };

            game.GamesGenres.Add(new GameGenre
            {
                GameId = game.Id,
                GenreId = genre.Id,
                IsDeleted = false
            });

            game.GamesPlatforms.Add(new GamePlatform
            {
                GameId = game.Id,
                PlatformId = platform.Id,
                IsDeleted = false
            });

            game.GamesRestrictions.Add(new GameRestriction
            {
                GameId = game.Id,
                RestrictionId = restriction.Id,
                IsDeleted = false
            });

            await _dbContext.Games.AddAsync(game);
            await _dbContext.SaveChangesAsync();

            // Act
            GameDetailsViewModel result = await _gameService.GetGameDetailsByIdAsync(gameId);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Title, Is.EqualTo("No Reviews Test Game"));

            // Verify genres, platforms, and restrictions are returned correctly
            Assert.IsNotEmpty(result.Genres);
            Assert.That(result.Genres.First().Name, Is.EqualTo(genre.Name));

            Assert.IsNotEmpty(result.Platforms);
            Assert.That(result.Platforms.First().Name, Is.EqualTo(platform.Name));

            Assert.IsNotEmpty(result.Restrictions);
            Assert.That(result.Restrictions.First().Name, Is.EqualTo(restriction.Name));

            // Verify reviews are empty and average rating is 0
            Assert.IsEmpty(result.Reviews);
            Assert.That(result.AverageRating, Is.EqualTo(0.0));
        }

        [Test]
        public async Task HasPublisherWithIdAsync_ShouldReturnTrue_WhenGameHasPublisherWithGivenModeratorId()
        {
            //Arrange
            string gameId = "00000000-0000-0000-0000-000000000002";
            Moderator moderator = await _dbContext.Moderators.FirstAsync();
            string moderatorId = moderator.Id.ToString();

            //Act
            bool result = await _gameService.HasPublisherWithIdAsync(moderatorId, gameId);

            //Assert
            Assert.True(result);
        }

        [Test]
        public async Task HasPublisherWithIdAsync_ShouldReturnFalse_WhenGameHasNotPublisherWithGivenModeratorId()
        {
            //Arrange
            string gameId = "00000000-0000-0000-0000-000000000002";
            string moderatorId = Guid.NewGuid().ToString();

            //Act
            bool result = await _gameService.HasPublisherWithIdAsync(moderatorId, gameId);

            //Assert
            Assert.False(result);
        }
    }
}
