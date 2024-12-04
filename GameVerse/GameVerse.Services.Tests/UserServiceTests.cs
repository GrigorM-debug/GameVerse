
using GameVerse.Data.Models.Games.Review;
using GameVerse.Data.Repositories.Interfaces;
using GameVerse.Data;
using GameVerse.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using GameVerse.Data.Models.Games;
using GameVerse.Data.Models.Events;
using GameVerse.Data.Repositories;

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
        }

        [TearDown]
        public async Task TearDown()
        {
            await _dbContext.Database.EnsureDeletedAsync();
            await _dbContext.DisposeAsync();
        }

        private async Task SeedDatabase()
        {

        }
    }
}
