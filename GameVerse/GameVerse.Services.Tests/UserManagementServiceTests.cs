

using GameVerse.Data;
using GameVerse.Data.Models.ApplicationUsers;
using GameVerse.Data.Repositories.Interfaces;
using GameVerse.Web.Areas.Administrator.Services;
using GameVerse.Web.Areas.Administrator.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Moq;
using NUnit.Framework;

using static GameVerse.Services.Tests.MockHelper;

namespace GameVerse.Services.Tests
{
    public class UserManagementServiceTests
    {
        private DbContextOptions<GameVerseDbContext> _dbContextOptions;
        private GameVerseDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        private IGenericRepository<ApplicationUser, Guid> _userRepository;
        private IGenericRepository<Moderator, Guid> _moderatorRepository;
        private IUserManagementService _service;

        [SetUp]
        public async Task SetUp()
        {
            _dbContextOptions = new DbContextOptionsBuilder<GameVerseDbContext>()
                .UseInMemoryDatabase("GameVerseInMemoryTest" + Guid.NewGuid().ToString())
                .Options;

            _context = new GameVerseDbContext(_dbContextOptions);

            await _context.Users.AddRangeAsync(new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    UserName = "TestUser",
                    NormalizedUserName = "TESTUSER",
                    Email = "test@abv.bg",
                    NormalizedEmail = "test@abv.bg",
                    FirstName = "Test",
                    LastName = "Testov"
                },
                new ApplicationUser
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    UserName = "TestUser2",
                    NormalizedUserName = "TESTUSER2",
                    Email = "test2@abv.bg",
                    NormalizedEmail = "test2@abv.bg",
                    FirstName = "Test2",
                    LastName = "Testov2"
                }
            });

            await _context.Moderators.AddRangeAsync(new List<Moderator>
            {
                new Moderator
                {
                    UserId = Guid.Parse("00000000-0000-0000-0000-000000000001"), 
                    IsActive = true, 
                    TotalGamesCreated = 10, 
                    TotalEventsCreated = 5
                }
            });

            await _context.SaveChangesAsync();

            var userManagerMock = MockUserManager<ApplicationUser>();
            userManagerMock.Setup(um => um.Users).Returns(_context.Users);

            var userRepositoryMock = new Mock<IGenericRepository<ApplicationUser, Guid>>();
            userRepositoryMock.Setup(repo => repo.AllAsReadOnly())
                .Returns(_context.Users.AsQueryable());

            var moderatorRepositoryMock = new Mock<IGenericRepository<Moderator, Guid>>();
            moderatorRepositoryMock.Setup(repo => repo.AllAsReadOnly())
                .Returns(_context.Moderators.AsQueryable());

            _service = new UserManagementService(
                userManagerMock.Object,
                userRepositoryMock.Object,
                moderatorRepositoryMock.Object
            );
        }

        [TearDown]
        public async Task TearDown()
        {
            await _context.Database.EnsureDeletedAsync();
            await _context.DisposeAsync();
        }

        [Test]
        public async Task UserExistByIdAsync_UserExists_ReturnsTrue()
        {
            // Arrange
            var user = _context.Users.First();

            var userManagerMock = MockHelper.MockUserManager<ApplicationUser>();
            userManagerMock.Setup(um => um.FindByIdAsync(user.Id.ToString()))
                .ReturnsAsync(user);


            var service = new UserManagementService(
                userManagerMock.Object,
                _userRepository,
                _moderatorRepository);

            // Act
            var result = await service.UserExistByIdAsync(user.Id.ToString());

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task UserExistByIdAsync_UserDoesNotExist_ReturnsFalse()
        {
            // Arrange
            var userId = Guid.NewGuid().ToString();

            var userManagerMock = MockHelper.MockUserManager<ApplicationUser>();
            
            userManagerMock.Setup(um => um.FindByIdAsync(userId))
                .ReturnsAsync((ApplicationUser)null);


            var service = new UserManagementService(
                userManagerMock.Object,
                _userRepository,
                _moderatorRepository);

            // Act
            var result = await service.UserExistByIdAsync(userId);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task AdministratorExistByIdAsync_AdminExist_ReturnsTrue()
        {
            //Arrange
            var user = await _context.Users.LastAsync();

            var userManagerMock = MockUserManager<ApplicationUser>();
            userManagerMock.Setup(um => um.FindByIdAsync(user.Id.ToString()))
                .ReturnsAsync(user);

            userManagerMock.Setup(um => um.IsInRoleAsync(user, "Admin")).ReturnsAsync(true);

            var service = new UserManagementService(
                userManagerMock.Object,
                _userRepository,
                _moderatorRepository);

            //Act 
            bool result = await service.AdministratorExistByIdAsync(user.Id.ToString());

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task AdministratorExistByIdAsync_UserIsNotAdmin_ReturnsFalse()
        {
            //Arrange
            var user = await _context.Users.LastAsync();

            var userManagerMock = MockUserManager<ApplicationUser>();
                
            userManagerMock
                .Setup(um => um.FindByIdAsync(user.Id.ToString()))
                .ReturnsAsync(user);

            userManagerMock
                .Setup(um => um.IsInRoleAsync(user, "Admin"))
                .ReturnsAsync(false);

            var service = new UserManagementService(
                userManagerMock.Object,
                _userRepository,
                _moderatorRepository);

            //Act 
            bool result = await service.AdministratorExistByIdAsync(user.Id.ToString());

            Assert.IsFalse(result);
        }

        [Test]
        public async Task AdministratorExistByIdAsync_UserDoesNotExist_ReturnFalse()
        {
            //Arrange
            var user = _context.Users.LastAsync();

            var userManagerMock = MockUserManager<ApplicationUser>();

            userManagerMock.Setup(um => um.FindByIdAsync(user.Id.ToString()))
                .ReturnsAsync((ApplicationUser)null);

            var service = new UserManagementService(
                userManagerMock.Object,
                _userRepository,
                _moderatorRepository
            );

            //Act
            bool result = await service.AdministratorExistByIdAsync(user.Id.ToString());

            Assert.IsFalse(result);
        }

        [Test]
        public async Task GetTotalModeratorsCountAsync_ReturnsZero_WhenNoModeratorsExist()
        {
            // Arrange
            var userManagerMock = MockHelper.MockUserManager<ApplicationUser>();
            userManagerMock.Setup(um => um.GetUsersInRoleAsync("Moderator"))
                .ReturnsAsync(new List<ApplicationUser>());

            var service = new UserManagementService(
                userManagerMock.Object,
                _userRepository,
                _moderatorRepository
            );

            // Act
            int result = await service.GetTotalModeratorsCountAsync();

            // Assert
            Assert.That(result, Is.EqualTo(0));
        }


        [Test]
        public async Task GetTotalModeratorsCountAsync_ReturnsModeratorsCount_WhenModeratorsExists()
        {
            var user = await _context.Users.LastAsync();

            var userManagerMock = MockHelper.MockUserManager<ApplicationUser>();

            userManagerMock
                .Setup(um => um.AddToRoleAsync(user, "Moderator"))
                .ReturnsAsync(IdentityResult.Success);

            userManagerMock.Setup(um => um.GetUsersInRoleAsync("Moderator"))
                .ReturnsAsync(new List<ApplicationUser> { user });

            var service = new UserManagementService(
                userManagerMock.Object,
                _userRepository,
                _moderatorRepository
            );

            int result = await service.GetTotalModeratorsCountAsync();

            Assert.That(result, Is.EqualTo(1));
        }


    }
}
