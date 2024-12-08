using GameVerse.Data.Models.Events;
using GameVerse.Data.Repositories.Interfaces;
using GameVerse.Data;
using GameVerse.Web.Areas.Administrator.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameVerse.Data.Repositories;
using GameVerse.Web.Areas.Administrator.Services;
using GameVerse.Data.Models.ApplicationUsers;
using GameVerse.Services.Interfaces;
using GameVerse.Web.Areas.Administrator.Models;

namespace GameVerse.Services.Tests
{
    [TestFixture]
    public class EventsRegistrationsServiceTests
    {
        private DbContextOptions<GameVerseDbContext> _dbContextOptions;
        private GameVerseDbContext _dbContext;
        private IGenericRepository<EventRegistration, object> _eventRegistrationRepository;
        private IEventsRegistrationsService _eventsRegistrationsService;
        private IQrCodeService _qrCodeService;

        [SetUp]
        public async Task SetUp()
        {
            _dbContextOptions = new DbContextOptionsBuilder<GameVerseDbContext>()
                .UseInMemoryDatabase("GameVerseInMemoryTest" + Guid.NewGuid().ToString())
                .Options;

            _dbContext = new GameVerseDbContext(_dbContextOptions);

            _qrCodeService = new QrCodeService();

            await SeedDatabase();

            _eventRegistrationRepository = new GenericRepository<EventRegistration, object>(_dbContext);


            _eventsRegistrationsService = new EventsRegistrationsService(_eventRegistrationRepository);
        }

        [TearDown]
        public async Task TearDown()
        {
            await _dbContext.Database.EnsureDeletedAsync();
            await _dbContext.DisposeAsync();
        }

        private async Task SeedDatabase()
        {
            ApplicationUser user1 = new ApplicationUser()
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
                Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                UserName = "TestUser2",
                NormalizedUserName = "TESTUSER2",
                Email = "test2@abv.bg",
                NormalizedEmail = "test2@abv.bg",
                FirstName = "Test2",
                LastName = "Testov2"
            };

            ApplicationUser user3 = new ApplicationUser()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                UserName = "TestUser3",
                NormalizedUserName = "TESTUSER3",
                Email = "test3@abv.bg",
                NormalizedEmail = "test3@abv.bg",
                FirstName = "Test3",
                LastName = "Testov3"
            };

            Moderator moderator = new Moderator()
            {
                User = user3,
                TotalGamesCreated = 0,
                TotalEventsCreated = 2,
                IsActive = true
            };

            Event event1 = new Event()
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                Topic = "Event 1",
                Description = "Test Event 1",
                Seats = 100,
                TicketPrice = 20,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(2),
                IsDeleted = false,
                PublisherId = moderator.Id,
                Image = "testImage.png"
            };

            Event event2 = new Event()
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000002"),
                Topic = "Event 2",
                Description = "Test Event 2",
                Seats = 50,
                TicketPrice = 15,
                StartDate = DateTime.Now.AddDays(4),
                EndDate = DateTime.Now.AddDays(6),
                IsDeleted = false,
                PublisherId = moderator.Id,
                Image = "testImage.png"
            };

            EventRegistration registration1 = new EventRegistration()
            {
                UserId = user1.Id,
                EventId = event1.Id,
                TicketQuantity = 2
            };

            registration1.QrCode = _qrCodeService.GenerateQrCode(
                $"EventId:{registration1.EventId.ToString()};UserId:{registration1.UserId.ToString()};Date:{DateTime.Now}");

            EventRegistration registration2 = new EventRegistration()
            {
                UserId = user2.Id,
                EventId = event2.Id,
                TicketQuantity = 1,
            };

            registration2.QrCode = _qrCodeService.GenerateQrCode(
                $"EventId:{registration2.EventId.ToString()};UserId:{registration2.UserId.ToString()};Date:{DateTime.Now}");

            await _dbContext.Users.AddRangeAsync(user1, user2, user3);
            await _dbContext.Moderators.AddAsync(moderator);
            await _dbContext.Events.AddRangeAsync(event1, event2);
            await _dbContext.EventsRegistrations.AddRangeAsync(registration1, registration2);
            await _dbContext.SaveChangesAsync();
        }

        [Test]
        public async Task GetTotalEventsRegistrationsCountAsync_ShouldReturnTotalCountWhenEventsRegistrationsExists()
        {
            // Act
            int result = await _eventsRegistrationsService.GetTotalEventsRegistrationsCountAsync();

            // Assert
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public async Task GetTotalEventsRegistrationsCountAsync_ShouldReturnZero_WhenEventsRegistrationsDoesNotExist()
        {
            //Arrange
            IEnumerable<EventRegistration> eventsRegistrations = await _dbContext.EventsRegistrations.ToListAsync();
            _dbContext.RemoveRange(eventsRegistrations);
            await _dbContext.SaveChangesAsync();

            //Act 
            int result = await _eventsRegistrationsService.GetTotalEventsRegistrationsCountAsync();

            //Assert
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public async Task GetUserEventRegistrationInfo_ShouldReturnValidRegistrationInfo()
        {
            // Arrange
            var qrCodeData = new DecodedDataViewModel
            {
                UserId = "00000000-0000-0000-0000-000000000001",
                EventId = "10000000-0000-0000-0000-000000000001"
            };

            // Act
            UserEventRegistrationInfoViewModel result = await _eventsRegistrationsService.GetUserEventRegistrationInfo(qrCodeData);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.UserName, Is.EqualTo("TestUser"));
            Assert.That(result.FullName, Is.EqualTo("Test Testov"));
            Assert.That(result.EventTopic, Is.EqualTo("Event 1"));
            Assert.That(result.NumberOfTickets, Is.EqualTo(2));
            Assert.That(result.PricePaid, Is.EqualTo("40,00 лв."));
            Assert.IsFalse(string.IsNullOrEmpty(result.RegistrationDate));
        }

        [Test]
        public async Task GetUserEventRegistrationInfo_ShouldReturnNullForInvalidQrCodeData()
        {
            // Arrange
            var qrCodeData = new DecodedDataViewModel
            {
                UserId = "00000000-0000-0000-0000-000000000004", // Non-existent User ID
                EventId = "10000000-0000-0000-0000-000000000001"
            };

            // Act
            UserEventRegistrationInfoViewModel result = await _eventsRegistrationsService.GetUserEventRegistrationInfo(qrCodeData);

            // Assert
            Assert.IsNull(result);
        }

    }
}
