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
using GameVerse.Web.ViewModels.Game.Review;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameVerse.Services.Tests
{
    [TestFixture]
    public class ReviewServiceTests
    {
        private DbContextOptions<GameVerseDbContext> _dbContextOptions;
        private GameVerseDbContext _dbContext;
        private IReviewService _reviewService;
        private IGenericRepository<GameReview, Guid> _reviewRepository;

        [SetUp]
        public async Task Setup()
        {
            _dbContextOptions = new DbContextOptionsBuilder<GameVerseDbContext>()
                .UseInMemoryDatabase("GameVerseInMemoryTest" + Guid.NewGuid().ToString())
                .Options;

            _dbContext = new GameVerseDbContext(_dbContextOptions);

            //Seed database
            await SeedDataBase();

            _reviewRepository = new GenericRepository<GameReview, Guid>(_dbContext);

            _reviewService = new ReviewService(_reviewRepository);
        }

        [TearDown]
        public async Task TearDown()
        {
            await _dbContext.Database.EnsureDeletedAsync();
            await _dbContext.DisposeAsync();
        }

        private async Task SeedDataBase()
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

            ApplicationUser reviewer = new ApplicationUser()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                UserName = "TestUser",
                NormalizedUserName = "TESTUSER",
                Email = "test@abv.bg",
                NormalizedEmail = "test@abv.bg",
                FirstName = "Test",
                LastName = "Testov"
            };

            GameReview reviewSeed = new GameReview()
            {
                Id = Guid.NewGuid(),
                ReviewerId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                GameId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                Content = "Existing review",
                Rating = 5,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
                Game = game,
                Reviewer = reviewer,
            };

            await _dbContext.Restrictions.AddAsync(restriction);
            await _dbContext.Genres.AddAsync(genre);
            await _dbContext.Platforms.AddAsync(platform);
            await _dbContext.Games.AddAsync(game);  
            await _dbContext.Users.AddAsync(reviewer);
            await _dbContext.GameReviews.AddAsync(reviewSeed);

            await _dbContext.SaveChangesAsync();
        }

        [Test]
        public async Task ReviewAlreadyExistByGameIdAndUserIdAsync_ReturnsTrue_WhenReviewExist()
        {
            //Arrange
            string userId = "00000000-0000-0000-0000-000000000001";
            string gameId = "00000000-0000-0000-0000-000000000002";

            //Act
            bool result = await _reviewService.ReviewAlreadyExistByGameIdAndUserIdAsync(userId, gameId);

            //Assert
            Assert.True(result);
        }

        [Test]
        public async Task ReviewAlreadyExistByGameIdAndUserIdAsync_ReturnsFalse_WhenReviewDoesNotExistByUserIdAndGameId()
        {
            //Arrange 
            string gameId = Guid.NewGuid().ToString();
            string userId = Guid.NewGuid().ToString();

            //Act
            bool result = await _reviewService.ReviewAlreadyExistByGameIdAndUserIdAsync(userId, gameId);

            //Assert
            Assert.False(result);
        }

        [Test]
        public async Task ReviewAlreadyExistByGameIdAndUserIdAsync_ReturnsFalse_WhenUserIdIsWrong()
        {
            //Arrange
            string userId = Guid.NewGuid().ToString();
            string gameId = "00000000-0000-0000-0000-000000000002";

            //Act
            bool result = await _reviewService.ReviewAlreadyExistByGameIdAndUserIdAsync(userId, gameId);

            //Assert
            Assert.False(result);
        }

        [Test]
        public async Task ReviewAlreadyExistByGameIdAndUserIdAsync_ReturnsFalse_WhenGameIdIsWrong()
        {
            //Arrange
            string userId = "00000000-0000-0000-0000-000000000001";
            string gameId = Guid.NewGuid().ToString();

            //Act
            bool result = await _reviewService.ReviewAlreadyExistByGameIdAndUserIdAsync(userId, gameId);

            //Assert
            Assert.False(result);
        }

        [Test]
        public async Task AddReviewAsync_ShouldMarkReviewAsNotDeleted_WhenReviewExistsAndIsDeleted()
        {
            //Arrange
            GameReview review = new GameReview
            {
                Id = Guid.NewGuid(),
                GameId = Guid.NewGuid(),
                ReviewerId = Guid.NewGuid(),
                Content = "Deleted Review",
                Rating = 3,
                CreatedOn = DateTime.UtcNow.AddDays(-1),
                IsDeleted = true
            };

            await _dbContext.GameReviews.AddAsync(review);
            await _dbContext.SaveChangesAsync();

            ReviewInputViewModel inputModel = new ReviewInputViewModel
            {
                Content = "Updated Review Content",
                Rating = 5
            };

            string userId = review.ReviewerId.ToString();
            string gameId = review.GameId.ToString();
            DateTime createdOn = DateTime.UtcNow;

            //Act
            bool result = await _reviewService.AddReviewAsync(inputModel, userId, gameId, createdOn);

            GameReview? updatedReview = await _dbContext.GameReviews.FirstOrDefaultAsync(r => r.Id == review.Id);

            Assert.IsTrue(result);
            Assert.IsNotNull(updatedReview);
            Assert.IsFalse(updatedReview.IsDeleted);
        }

        [Test]
        public async Task AddReviewAsync_AddsNewReview_WhenReviewDoesNotExist()
        {
            //Arrange
            string userId = Guid.NewGuid().ToString();
            string gameId = Guid.NewGuid().ToString();
            DateTime createdOn = DateTime.UtcNow;

            ReviewInputViewModel inputModel = new ReviewInputViewModel()
            {
                Content = "New review",
                Rating = 4
            };

            //Act
            bool result = await _reviewService.AddReviewAsync(inputModel, userId, gameId, createdOn);

            //Assert
            Assert.True(result);

            GameReview? review = await _dbContext.GameReviews.FirstOrDefaultAsync(r => r.GameId.ToString() == gameId && r.ReviewerId.ToString() == userId && r.IsDeleted == false);

            Assert.IsNotNull(review);
            Assert.That(review.Content, Is.EqualTo("New review"));
            Assert.That(4, Is.EqualTo(review.Rating));
        }

        [Test]
        public async Task EditReviewPostAsync_UpdatesReview_WhenReviewExist()
        {
            //Arrange
            GameReview? existringReview = await _dbContext.GameReviews.FirstAsync();

            ReviewInputViewModel inputModel = new ReviewInputViewModel()
            {
                Content = "Updated review content",
                Rating = 4
            };

            DateTime createdOn = DateTime.UtcNow;

            //Act
            bool result = await _reviewService.EditReviewPostAsync(inputModel, createdOn, existringReview.Id.ToString(), existringReview.ReviewerId.ToString(), existringReview.GameId.ToString());

            //Assert
            Assert.True(result);

            GameReview updatedReview = await _dbContext.GameReviews.FirstAsync();

            Assert.That(updatedReview.Content, Is.EqualTo("Updated review content"));
            Assert.That(updatedReview.Rating, Is.EqualTo(4));
        }

        [Test]
        public async Task EditReviewPostAsync_ReturnsFalse_WhenReviewDoesNotExist()
        {
            //Arrange
            string userId = Guid.NewGuid().ToString();
            string gameId = Guid.NewGuid().ToString();
            string reviewId = Guid.NewGuid().ToString();
            DateTime createdOn = DateTime.UtcNow;

            ReviewInputViewModel inputModel = new ReviewInputViewModel()
            {
                Content = "Updated review content",
                Rating = 4
            };

            //Act 
            bool result = await _reviewService.EditReviewPostAsync(inputModel, createdOn, reviewId, userId, gameId);

            //Assert
            Assert.False(result);
        }

        [Test]
        public async Task EditReviewGetAsync_ReturnsCorrectViewModel_WhenReviewExists()
        {
            //Arrange
            GameReview review = await _dbContext.GameReviews.FirstAsync();
            string reviewId = review.Id.ToString();
            string userId = review.ReviewerId.ToString();
            string gameId = review.GameId.ToString();

            //Act
            ReviewInputViewModel result = await _reviewService.EditViewGetAsync(reviewId, gameId, userId);

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.Content, Is.EqualTo(review.Content));
            Assert.That(result.Rating, Is.EqualTo(review.Rating));
            Assert.That(result.GameId, Is.EqualTo(review.GameId.ToString()));
        }

        [Test]
        public async Task DeleteReviewGetAsync_ReturnsCorrectViewModel_WhenReviewExists()
        {
            //Arrange
            GameReview review = await _dbContext.GameReviews.FirstAsync();
            string reviewId = review.Id.ToString();
            string userId = review.ReviewerId.ToString();
            string gameId = review.GameId.ToString();

            //Act
            ReviewDeleteViewModel result = await _reviewService.DeleteReviewGetAsync(reviewId, userId, gameId);

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(reviewId));
            Assert.That(result.Content, Is.EqualTo(review.Content));
            Assert.That(result.Rating, Is.EqualTo(review.Rating));
            Assert.That(result.ReviewerId, Is.EqualTo(review.ReviewerId.ToString()));
            Assert.That(result.ReviewerName, Is.EqualTo(review.Reviewer.UserName));
            Assert.That(result.GameId, Is.EqualTo(review.GameId.ToString()));
            Assert.That(result.GameName, Is.EqualTo(review.Game.Title));
        }
    }
}
