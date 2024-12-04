

using GameVerse.Data.Models.Events;
using GameVerse.Data.Models.Games;
using GameVerse.Data.Repositories.Interfaces;
using GameVerse.Data;
using GameVerse.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using GameVerse.Data.Models.ApplicationUsers;
using GameVerse.Data.Repositories;

namespace GameVerse.Services.Tests
{
    public class ModeratorServiceTests
    {
        private DbContextOptions<GameVerseDbContext> _dbContextOptions;
        private GameVerseDbContext _dbContext;
        private IModeratorService _moderatorService;
        private IGenericRepository<Moderator, Guid> _moderatorRepository;

        [SetUp]
        public async Task Setup()
        {
            _dbContextOptions = new DbContextOptionsBuilder<GameVerseDbContext>()
                .UseInMemoryDatabase("GameVerseInMemoryTest" + Guid.NewGuid().ToString())
                .Options;

            _dbContext = new GameVerseDbContext(_dbContextOptions);

            //Seed the db
            await SeedDatabase();

            _moderatorRepository = new GenericRepository<Moderator, Guid>(_dbContext);

            _moderatorService = new ModeratorService(_moderatorRepository);
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
                Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                UserId = user.Id,
                User = user,
                TotalEventsCreated = 0,
                TotalGamesCreated = 0,
                OwnedEvents = new HashSet<Event>(),
                OwnedGames = new HashSet<Game>(),
            };

            await _dbContext.Users.AddAsync(user);
            await _dbContext.Moderators.AddAsync(moderator);
            await _dbContext.SaveChangesAsync();
        }

        [Test]
        public async Task GetModeratorIdByUserIdAsync_ReturnsModeratorId_IfUserIsModerator()
        {
            //Arrange
            Moderator moderator = await _dbContext.Moderators.FirstAsync();
            string userId = "00000000-0000-0000-0000-000000000001";

            //Act
            string? moderatorId = await _moderatorService.GetModeratorIdByUserIdAsync(userId);

            //Assert
            Assert.IsNotNull(moderatorId);
            Assert.That(moderatorId, Is.EqualTo(moderator.Id.ToString()));
        }

        [Test]
        public async Task GetModeratorIdByUserIdAsync_ReturnsNull_IfUserIsNotModerator()
        {
            //Arrange
            Moderator moderator = await _dbContext.Moderators.FirstAsync();
            string userId = "00000000-0000-0000-0000-0000000000010";

            //Act
            string? moderatorId = await _moderatorService.GetModeratorIdByUserIdAsync(userId);

            //Assert
            Assert.IsNull(moderatorId);
            Assert.That(userId, Is.Not.EqualTo(moderator.Id.ToString()));
        }

        [Test]
        public async Task InCreaseCreatedTotalEventsCount_IncreaseTotalEventsCreated_WhenModeratorExist()
        {
            //Arrange
            Moderator moderator = await _dbContext.Moderators.FirstAsync();
            string moderatorId = moderator.Id.ToString();
            int expectecTotalEventsCount = 1;

            //Act
            await _moderatorService.InCreaseCreatedTotalEventsCount(moderatorId);

            //Assert
            Moderator updatedModerator = await _dbContext.Moderators.FirstAsync();
            Assert.That(updatedModerator.TotalEventsCreated, Is.EqualTo(expectecTotalEventsCount));
        }

        [Test]
        public async Task InCreaseCreatedTotalEventsCount_DoesNotIncreaseTotalEventsCreated_WhenModeratorDoesNotExist()
        {
            //Arrange
            string modetatorId = Guid.NewGuid().ToString();
            int expectecTotalEventsCount = 0;

            //Act
            await _moderatorService.InCreaseCreatedTotalEventsCount(modetatorId);

            //Arrange
            Moderator moderator = await _dbContext.Moderators.FirstAsync();
            Assert.That(moderator.TotalEventsCreated, Is.EqualTo(expectecTotalEventsCount));
        }
    }
}
