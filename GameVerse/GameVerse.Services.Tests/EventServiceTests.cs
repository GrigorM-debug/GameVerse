

using GameVerse.Common.Enums;
using GameVerse.Data;
using GameVerse.Data.Models.ApplicationUsers;
using GameVerse.Data.Models.Events;
using GameVerse.Data.Repositories;
using GameVerse.Data.Repositories.Interfaces;
using GameVerse.Services.Interfaces;
using GameVerse.Web.ViewModels.Event;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions;
using NUnit.Framework.Internal;

namespace GameVerse.Services.Tests
{
    [TestFixture]
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

        [Test]
        public async Task EventExistById_ShouldReturnTrue_WhenEventExists()
        {
            // Arrange
            Event e = await _dbContext.Events.FirstAsync();
            string existingEventId = e.Id.ToString();

            // Act
            bool result = await _eventService.EventExistById(existingEventId);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task EventExistById_ShouldReturnFalse_WhenEventDoesNotExist()
        {
            // Arrange
            string nonExistentEventId = Guid.NewGuid().ToString(); 

            // Act
            bool result = await _eventService.EventExistById(nonExistentEventId);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task AddEventAsync_ShouldAddEventSuccessfully()
        {
            // Arrange
            EventInputViewModel inputModel = new EventInputViewModel
            {
                Topic = "New Event",
                Description = "This is a test event.",
                Latitude = 12.345,
                Longitude = 67.890,
                Seats = 100,
                TicketPrice = 50.0m,
                Image = "test-image-url"
            };

            string moderatorId = _dbContext.Moderators.First().Id.ToString(); 
            DateTime startDate = DateTime.UtcNow.AddDays(1); 
            DateTime endDate = startDate.AddHours(2); 

            // Act
            string result = await _eventService.AddEventAsync(inputModel, moderatorId, startDate, endDate);

            // Assert
            Assert.NotNull(result);

            Event addedEvent = await _dbContext.Events.FindAsync(Guid.Parse(result));

            Assert.NotNull(addedEvent);
            Assert.That(addedEvent.Topic, Is.EqualTo(inputModel.Topic));
            Assert.That(addedEvent.Description, Is.EqualTo(inputModel.Description));
            Assert.That(addedEvent.StartDate, Is.EqualTo(startDate));
            Assert.That(addedEvent.EndDate, Is.EqualTo(endDate));
            Assert.That(addedEvent.Latitude, Is.EqualTo(inputModel.Latitude));
            Assert.That(addedEvent.Longitude, Is.EqualTo(inputModel.Longitude));
            Assert.That(addedEvent.Seats, Is.EqualTo(inputModel.Seats));
            Assert.That(addedEvent.TicketPrice, Is.EqualTo(inputModel.TicketPrice));
            Assert.That(addedEvent.Image, Is.EqualTo(inputModel.Image));
            Assert.That(addedEvent.PublisherId.ToString(), Is.EqualTo(moderatorId));
        }

        [Test]
        public async Task DeleteEventGetAsync_ShouldReturnEventDeleteViewModel_WhenEventExistsAndUSerISModerator()
        {
            // Arrange
            Event e = await _dbContext.Events.FirstAsync();
            string eventId = e.Id.ToString();
            Moderator moderator = await _dbContext.Moderators.FirstAsync();
            string moderatorId = moderator.Id.ToString(); 
            bool isAdmin = false; 

            // Act
            EventDeleteViewModel? result = await _eventService.DeleteEventGetAsync(eventId, moderatorId, isAdmin);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Id, Is.EqualTo(eventId));
            Assert.That(result.Topic, Is.EqualTo(e.Topic)); 
            Assert.That(result.PublisherId, Is.EqualTo(moderatorId));
            Assert.That(result.PublisherName, Is.EqualTo(e.Publisher.User.UserName)); 
        }

        [Test]
        public async Task DeleteEventGetAsync_ShouldReturnEventDeleteViewModel_WhenEventExistsAndUserIsNotModeratorButIsAdmin()
        {
            // Arrange
            Event e = await _dbContext.Events.FirstAsync();
            string eventId = e.Id.ToString();
            bool isAdmin = true;
            string moderatorId = Guid.NewGuid().ToString();

            // Act
            EventDeleteViewModel? result = await _eventService.DeleteEventGetAsync(eventId, moderatorId, isAdmin);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Id, Is.EqualTo(eventId));
            Assert.That(result.Topic, Is.EqualTo(e.Topic));
            Assert.That(result.PublisherId, Is.EqualTo(e.PublisherId.ToString()));
            Assert.That(result.PublisherName, Is.EqualTo(e.Publisher.User.UserName));
        }

        [Test]
        public async Task DeleteEventPostAsync_ShouldDoNothing_WhenEventDoesNotExistOrUserLacksAccess()
        {
            // Arrange
            string nonExistentEventId = Guid.NewGuid().ToString(); 
            string invalidModeratorId = "invalid-moderator-id"; 
            bool isAdmin = false; 

            // Act
            await _eventService.DeleteEventPostAsync(nonExistentEventId, invalidModeratorId, isAdmin);

            // Assert
            IEnumerable<Event> events = _dbContext.Events.ToList(); 
            Assert.IsTrue(events.All(e => !e.IsDeleted));
        }

        [Test]
        public async Task DeleteEventPostAsync_ShouldMarkEventAsDeleted_WhenEventExistsAndUserHasAccess()
        {
            // Arrange
            Event e = await _dbContext.Events.FirstAsync();
            string eventId = e.Id.ToString();
            Moderator moderator = await _dbContext.Moderators.FirstAsync();
            string moderatorId = moderator.Id.ToString();
            bool isAdmin = false; 

            // Act
            await _eventService.DeleteEventPostAsync(eventId, moderatorId, isAdmin);

            // Assert
            Event? deletedEvent = await _dbContext.Events.FindAsync(Guid.Parse(eventId));
            Assert.NotNull(deletedEvent);
            Assert.IsTrue(deletedEvent.IsDeleted);
        }

        [Test]
        public async Task EditEventGetAsync_ShouldReturnEventInputViewModel_WhenEventExistsAndUserHasAccess()
        {
            // Arrange
            Event e = await _dbContext.Events.FirstAsync();
            string eventId = e.Id.ToString();
            Moderator moderator = await _dbContext.Moderators.FirstAsync();
            string moderatorId = moderator.Id.ToString();
            bool isAdmin = false; 

            // Act
            EventInputViewModel? result = await _eventService.EditEventGetAsync(eventId, moderatorId, isAdmin);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Topic, Is.EqualTo(e.Topic)); 
            Assert.That(result.Description, Is.EqualTo(e.Description));
            Assert.That(result.Latitude, Is.EqualTo(e.Latitude));
            Assert.That(result.Longitude, Is.EqualTo(e.Longitude));
            Assert.That(result.Seats, Is.EqualTo(e.Seats));
            Assert.That(result.TicketPrice, Is.EqualTo(e.TicketPrice));
            Assert.That(result.Image, Is.EqualTo(e.Image));
        }

        [Test]
        public async Task EditEventGetAsync_ShouldReturnNull_WhenEventDoesNotExistOrUserLacksAccess()
        {
            // Arrange
            string nonExistentEventId = Guid.NewGuid().ToString(); 
            string invalidModeratorId = "invalid-moderator-id"; 
            bool isAdmin = false; 

            // Act
            EventInputViewModel? result = await _eventService.EditEventGetAsync(nonExistentEventId, invalidModeratorId, isAdmin);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task EditEventPostAsync_ShouldUpdateEventSuccessfully_WhenEventExistsAndUserHasAccess()
        {
            // Arrange
            Event e = await _dbContext.Events.FirstAsync();
            string eventId = e.Id.ToString();
            Moderator moderator = await _dbContext.Moderators.FirstAsync();
            string moderatorId = moderator.Id.ToString();
            DateTime startDate = DateTime.UtcNow.AddDays(1);
            DateTime endDate = DateTime.UtcNow.AddDays(2);

            EventInputViewModel inputModel = new EventInputViewModel
            {
                Topic = "Updated Event Topic",
                Description = "Updated Event Description",
                Latitude = 50.0,
                Longitude = 60.0,
                Seats = 200,
                TicketPrice = 100.0m,
                Image = "updated-image-url"
            };

            // Act
            string result = await _eventService.EditEventPostAsync(inputModel, eventId, moderatorId, startDate, endDate, false);

            // Assert
            Event updatedEvent = await _dbContext.Events.FindAsync(Guid.Parse(result));

            Assert.NotNull(updatedEvent);
            Assert.That(updatedEvent.Topic, Is.EqualTo(inputModel.Topic));
            Assert.That(updatedEvent.Description, Is.EqualTo(inputModel.Description));
            Assert.That(updatedEvent.StartDate, Is.EqualTo(startDate));
            Assert.That(updatedEvent.EndDate, Is.EqualTo(endDate));
            Assert.That(updatedEvent.Latitude, Is.EqualTo(inputModel.Latitude));
            Assert.That(updatedEvent.Longitude, Is.EqualTo(inputModel.Longitude));
            Assert.That(updatedEvent.Seats, Is.EqualTo(inputModel.Seats));
            Assert.That(updatedEvent.TicketPrice, Is.EqualTo(inputModel.TicketPrice));
            Assert.That(updatedEvent.Image, Is.EqualTo(inputModel.Image));
        }

        [Test]
        public async Task EditEventPostAsync_ShouldNotUpdateEvent_WhenEventDoesNotExistOrUserLacksAccess()
        {
            // Arrange
            string nonExistentEventId = Guid.NewGuid().ToString(); 
            string invalidModeratorId = "invalid-moderator-id"; 
            DateTime startDate = DateTime.UtcNow.AddDays(1);
            DateTime endDate = DateTime.UtcNow.AddDays(2);

            EventInputViewModel inputModel = new EventInputViewModel
            {
                Topic = "Non-Existent Event",
                Description = "This event does not exist.",
                Latitude = 50.0,
                Longitude = 60.0,
                Seats = 200,
                TicketPrice = 100.0m,
                Image = "non-existent-image-url"
            };

            // Act
            await _eventService.EditEventPostAsync(inputModel, nonExistentEventId, invalidModeratorId, startDate, endDate, false);

            // Assert
            IEnumerable<Event> events = _dbContext.Events.ToList();
            foreach (var existingEvent in events)
            {
                Assert.That(existingEvent.Topic, Is.Not.EqualTo("Non-Existent Event"));
                Assert.That(existingEvent.Description, Is.Not.EqualTo("This event does not exist."));
                Assert.That(existingEvent.Latitude, Is.Not.EqualTo(50.0));
                Assert.That(existingEvent.Longitude, Is.Not.EqualTo(60.0));
                Assert.That(existingEvent.Seats, Is.Not.EqualTo(200));
                Assert.That(existingEvent.TicketPrice, Is.Not.EqualTo(100.0m));
                Assert.That(existingEvent.Image, Is.Not.EqualTo("non-existent-image-url"));
            }
        }

        [Test]
        public async Task GetAllEventsAsync_ShouldReturnEmptyCollection_WhenNoEventsExist()
        {
            // Arrange
            foreach (var eventItem in _dbContext.Events)
            {
                _dbContext.Events.Remove(eventItem);
            }
            await _dbContext.SaveChangesAsync();

            int currentPage = 1;
            int eventsPerPage = 2;
            var sortOrder = EntitySortOrder.Newest;

            // Act
            IEnumerable<EventIndexViewModel> result = await _eventService.GetAllEventsAsync(currentPage, eventsPerPage, sortOrder);

            // Assert
            Assert.NotNull(result);
            Assert.IsEmpty(result);
        }


        [Test]
        public async Task GetAllEventsAsync_ShouldReturnPaginatedEventsWithSorting_WhenEventsExist()
        {
            // Arrange
            Moderator moderator = await _dbContext.Moderators.FirstAsync();
            Guid moderatorId = moderator.Id;
            List<Event> events = new List<Event>
            {
                new Event
                {
                    Topic = "Event 1",
                    Description = "First Event",
                    StartDate = DateTime.UtcNow.AddDays(5),
                    EndDate = DateTime.UtcNow.AddDays(5).AddHours(1),
                    Seats = 50,
                    TicketPrice = 10.0m,
                    Image = "event1.jpg",
                    PublisherId = moderatorId,
                    IsDeleted = false
                },
                new Event
                {
                    Topic = "Event 2",
                    Description = "Second Event",
                    StartDate = DateTime.UtcNow.AddDays(1),
                    EndDate = DateTime.UtcNow.AddDays(2),
                    Seats = 100,
                    TicketPrice = 15.0m,
                    Image = "event2.jpg",
                    PublisherId = moderatorId,
                    IsDeleted = false
                },
            };

            await _dbContext.Events.AddRangeAsync(events);
            await _dbContext.SaveChangesAsync();

            int currentPage = 1;
            int eventsPerPage = 2;
            EntitySortOrder sortOrder = EntitySortOrder.Oldest;

            // Act
            IEnumerable<EventIndexViewModel> result = await _eventService.GetAllEventsAsync(currentPage, eventsPerPage, sortOrder);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Count(), Is.EqualTo(2)); 

            List<EventIndexViewModel> resultList = result.ToList();
            Assert.That(resultList[0].Topic, Is.EqualTo("Test Event"));
            Assert.That(resultList[1].Topic, Is.EqualTo("Event 2")); 
        }


        [Test]
        public async Task GetLatest3EventsAsync_ShouldReturnLatest3Events_WhenEventsExist()
        {
            // Arrange
            Guid moderatorId = _dbContext.Moderators.First().Id;
            List<Event> events = new List<Event>
            {
                new Event
                {
                    Topic = "Event 1",
                    Description = "First Event",
                    StartDate = DateTime.UtcNow.AddDays(5),
                    EndDate = DateTime.UtcNow.AddDays(5).AddHours(1),
                    Latitude = 10.0,
                    Longitude = 20.0,
                    Seats = 50,
                    TicketPrice = 10.0m,
                    Image = "event1.jpg",
                    PublisherId = moderatorId,
                    IsDeleted = false
                },
                new Event
                {
                    Topic = "Event 2",
                    Description = "Second Event",
                    StartDate = DateTime.UtcNow.AddDays(1),
                    EndDate = DateTime.UtcNow.AddDays(2),
                    Latitude = 15.0,
                    Longitude = 25.0,
                    Seats = 100,
                    TicketPrice = 15.0m,
                    Image = "event2.jpg",
                    PublisherId = moderatorId,
                    IsDeleted = false
                },
            };

            await _dbContext.Events.AddRangeAsync(events);
            await _dbContext.SaveChangesAsync();

            // Act
            IEnumerable<EventIndexViewModel> result = await _eventService.GetLatest3EventsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Count(), Is.EqualTo(3));

            var resultList = result.ToList();
            Assert.That(resultList[0].Topic, Is.EqualTo("Event 1")); 
            Assert.That(resultList[1].Topic, Is.EqualTo("Event 2"));
            Assert.That(resultList[2].Topic, Is.EqualTo("Test Event"));
        }

        [Test]
        public async Task GetLatest3EventsAsync_ShouldReturnEmptyCollection_WhenEventsDoNotExist()
        {
            //Arrange
            Event e = await _dbContext.Events.FirstAsync();
            _dbContext.Events.Remove(e);
            await _dbContext.SaveChangesAsync();

            //Act
            IEnumerable<EventIndexViewModel> result = await _eventService.GetLatest3EventsAsync();

            //Assert
            Assert.IsEmpty(result);
        }

        [Test]
        public async Task HasPublisherWithIdAsync_ShouldReturnTrue_WhenEventHasPublisherWithGivenModeratorId()
        {
            //Arrange
            Event e = await _dbContext.Events.FirstAsync();
            string eventId = e.Id.ToString();
            Moderator moderator = await _dbContext.Moderators.FirstAsync();
            string moderatorId = moderator.Id.ToString();

            //Act
            bool result = await _eventService.HasPublisherWithIdAsync(moderatorId, eventId);

            //Assert
            Assert.True(result);
        }

        [Test]
        public async Task HasPublisherWithIdAsync_ShouldReturnFalse_WhenEventHasNotPublisherWithGivenModeratorId()
        {
            //Arrange
            Event e = await _dbContext.Events.FirstAsync();
            string eventId = e.Id.ToString();
            string moderatorId = Guid.NewGuid().ToString();

            //Act
            bool result = await _eventService.HasPublisherWithIdAsync(moderatorId, eventId);

            //Assert
            Assert.False(result);
        }
    }
}
