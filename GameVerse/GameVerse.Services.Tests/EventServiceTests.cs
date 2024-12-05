

using GameVerse.Data;
using GameVerse.Data.Models.ApplicationUsers;
using GameVerse.Data.Models.Events;
using GameVerse.Data.Repositories;
using GameVerse.Data.Repositories.Interfaces;
using GameVerse.Services.Interfaces;
using GameVerse.Web.ViewModels.Event;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework.Internal;

namespace GameVerse.Services.Tests
{
    public class EventServiceTests
    {
        private DbContextOptions<GameVerseDbContext> _dbContextOptions;
        private GameVerseDbContext _dbContext;
        private IEventService _eventService;
        private IGenericRepository<Event, Guid> _eventRepository;

        [SetUp]
        public async Task SetUp()
        {
            _dbContextOptions = new DbContextOptionsBuilder<GameVerseDbContext>()
                .UseInMemoryDatabase("GameVerseInMemoryTest" + Guid.NewGuid().ToString())
                .Options;

            _dbContext = new GameVerseDbContext(_dbContextOptions);

            await SeedDatabase();

            _eventRepository = new GenericRepository<Event, Guid>(_dbContext);

            _eventService = new EventService(_eventRepository);
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

            await _dbContext.Users.AddAsync(user);
            await _dbContext.Moderators.AddAsync(moderator);
            await _dbContext.Events.AddAsync(e);
            await _dbContext.SaveChangesAsync();
        }

        [Test]
        public async Task GetTotalEventsCountAsync_ShouldReturnCorrectCount_WhenEventsExist()
        {
            // Act
            int totalEventsCount = await _eventService.GetTotalEventsCountAsync();

            // Assert
            Assert.That(totalEventsCount, Is.EqualTo(1));
        }

        [Test]
        public async Task GetTotalEventsCountAsync_ShouldReturnZero_WhenNoEventsExist()
        {
            // Arrange
            foreach (var eventItem in _dbContext.Events)
            {
                _dbContext.Events.Remove(eventItem);
            }
            await _dbContext.SaveChangesAsync();

            // Act
            int totalEventsCount = await _eventService.GetTotalEventsCountAsync();

            // Assert
            Assert.That(totalEventsCount, Is.EqualTo(0));
        }

        [Test]
        public async Task GetEventByIdAsync_ShouldReturnNull_WhenEventDoesNotExist()
        {
            // Arrange
            string invalidEventId = Guid.NewGuid().ToString(); 

            // Act
            Event result = await _eventService.GetEventByIdAsync(invalidEventId);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task GetEventByIdAsync_ShouldReturnEvent_WhenEventExists()
        {
            // Arrange
            Event e = await _dbContext.Events.FirstAsync(); 
            string eventId = e.Id.ToString();

            // Act
            Event result = await _eventService.GetEventByIdAsync(eventId);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Id.ToString(), Is.EqualTo(eventId));
            Assert.That(result.Topic, Is.EqualTo("Test Event")); 
            Assert.That(result.IsDeleted, Is.EqualTo(false));
        }

        [Test]
        public async Task GetEventDetailsByIdAsync_ShouldReturnEventDetails_WhenEventExists()
        {
            // Arrange
            Event e = await _dbContext.Events.FirstAsync();
            string eventId = e.Id.ToString();
            

            // Act
            EventDetailsViewModel result = await _eventService.GetEventDetailsByIdAsync(eventId);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Id, Is.EqualTo(eventId));
            Assert.That(result.Topic, Is.EqualTo(e.Topic)); 
            Assert.That(result.Description, Is.EqualTo(e.Description));
            Assert.That(result.Seats, Is.EqualTo(e.Seats));
            Assert.That(result.TicketPrice, Is.EqualTo(e.TicketPrice.ToString("C"))); 
            Assert.That(result.Image, Is.EqualTo(e.Image));
            Assert.That(result.PublisherName, Is.EqualTo(e.Publisher.User.UserName)); 
        }

        [Test]
        public async Task EventExistByTitle_ShouldReturnTrue_WhenEventExists()
        {
            // Arrange
            string topic = "Test Event"; 

            // Act
            bool result = await _eventService.EventExistByTitle(topic);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task EventExistByTitle_ShouldReturnFalse_WhenEventDoesNotExist()
        {
            // Arrange
            string nonExistentTopic = "Non-Existent Event";

            // Act
            bool result = await _eventService.EventExistByTitle(nonExistentTopic);

            // Assert
            Assert.IsFalse(result);
        }


    }
}
