

using GameVerse.Common.Enums;
using GameVerse.Data;
using GameVerse.Data.Models.ApplicationUsers;
using GameVerse.Data.Models.Carts;
using GameVerse.Data.Models.Events;
using GameVerse.Data.Models.Games;
using GameVerse.Data.Models.Games.Genres;
using GameVerse.Data.Models.Games.Platform;
using GameVerse.Data.Models.Games.Restrictions;
using GameVerse.Data.Repositories;
using GameVerse.Data.Repositories.Interfaces;
using GameVerse.Services.Interfaces;
using GameVerse.Web.ViewModels.ShoppingCart;
using Microsoft.EntityFrameworkCore;
using static Azure.Core.HttpHeader;

namespace GameVerse.Services.Tests
{
    public class ShoppingCartServiceTests
    {
        private DbContextOptions<GameVerseDbContext> _dbContextOptions;
        private GameVerseDbContext _dbContext;
        private IGenericRepository<Cart, Guid> _cartRepository;
        private IGenericRepository<Game, Guid> _gameRepository;
        private IGenericRepository<Event, Guid> _eventRepository;
        private IGenericRepository<UserBoughtGame, object> _userBoughtGameRepository;
        private IGenericRepository<EventRegistration, object> _eventRegistrationRepository;
        private IQrCodeService _qrCodeService;
        private IShoppingCartService _shoppingCartService;

        [SetUp]
        public async Task SetUp()
        {
            _dbContextOptions = new DbContextOptionsBuilder<GameVerseDbContext>()
                .UseInMemoryDatabase("GameVerseInMemoryTest" + Guid.NewGuid().ToString())
                .Options;

            _dbContext = new GameVerseDbContext(_dbContextOptions);

            await SeedDatabase();

            _cartRepository = new GenericRepository<Cart, Guid>(_dbContext);
            _gameRepository = new GenericRepository<Game, Guid>(_dbContext);
            _eventRepository = new GenericRepository<Event, Guid>(_dbContext);
            _userBoughtGameRepository = new GenericRepository<UserBoughtGame, object>(_dbContext);
            _eventRegistrationRepository = new GenericRepository<EventRegistration, object>(_dbContext);

            _qrCodeService = new QrCodeService();

            _shoppingCartService = new ShoppingCartService(
                    _cartRepository,
                    _gameRepository,
                    _eventRepository,
                    _eventRegistrationRepository,
                    _userBoughtGameRepository,
                    _qrCodeService
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
                TotalEventsCreated = 2,
                TotalGamesCreated = 2,
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
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                YearPublished = 2011,
                CreatedOn = DateTime.UtcNow.AddDays(2),
                Price = 10,
                Image = "wdffffffffffffffffffffff",
                QuantityInStock = 10,
                Type = GameType.DigitalKey,
                IsDeleted = false,
                PublisherId = moderator.Id,
                PublishingStudio = "Test Studio2"
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

            Event e2 = new Event()
            {
                Topic = "Test Event2",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                StartDate = DateTime.Now.AddDays(2),
                EndDate = DateTime.Now.AddDays(4),
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
            await _dbContext.Restrictions.AddAsync(restriction);
            await _dbContext.Genres.AddAsync(genre);
            await _dbContext.Platforms.AddAsync(platform);
            await _dbContext.Games.AddRangeAsync(game, game2);
            await _dbContext.Events.AddRangeAsync(e, e2);
            await _dbContext.SaveChangesAsync();
        }

        [Test]
        public async Task AddGameToCartAsync_ShouldAddGameToCart()
        {
            //Arrange
            ApplicationUser user = await _dbContext.Users.FirstAsync();
            string userId = user.Id.ToString();
            Game game = await _dbContext.Games.FirstAsync();
            string gameId = game.Id.ToString();

            //Act
            await _shoppingCartService.AddGameToCartAsync(gameId, userId, game);

            //Assert
            Cart? cart = await _dbContext.Carts.Include(c => c.GamesCarts).FirstOrDefaultAsync(c => c.UserId.ToString() == userId);

            Assert.IsNotNull(cart);
            Assert.That(cart.GamesCarts.Count, Is.EqualTo(1));
            Assert.That(cart.GamesCarts.First().GameId.ToString(), Is.EqualTo(gameId));
            Assert.That(cart.GamesCarts.First().Game.Title, Is.EqualTo(game.Title));
            Assert.That(cart.GamesCarts.First().Game.Description, Is.EqualTo(game.Description));
            Assert.That(cart.GamesCarts.First().Game.Price, Is.EqualTo(game.Price));
            Assert.That(cart.TotalPrice, Is.EqualTo(20));
        }

        [Test]
        public async Task AddGameToCartAsync_ShouldInCrementQuantityIfGameExist()
        {
            //Arrange
            ApplicationUser user = await _dbContext.Users.FirstAsync();
            Game game = await _dbContext.Games.FirstAsync();


            Cart cart = new Cart() { User = user, TotalPrice = 20};

            cart.GamesCarts.Add(new GameCart { Cart
            = cart, Game = game, AddedOn = DateTime.Now, IsDeleted = false, Quantity = 1 });
            await _dbContext.Carts.AddAsync(cart);  
            await _dbContext.SaveChangesAsync();

            //Act
            await _shoppingCartService.AddGameToCartAsync(game.Id.ToString(), user.Id.ToString(), game);

            //Assert
            Cart updatedCart = await _dbContext.Carts.FirstAsync();

            Assert.IsNotNull(updatedCart);
            Assert.That(updatedCart.GamesCarts.First().Quantity, Is.EqualTo(2));
            Assert.That(updatedCart.TotalPrice, Is.EqualTo(40));
        }

        [Test]
        public async Task AddGameToCartAsync_ShouldReactivateDeletedGame()
        {
            //Arrange
            ApplicationUser user = await _dbContext.Users.FirstAsync();
            Game game = await _dbContext.Games.FirstAsync();

            Cart cart = new Cart() { User = user, TotalPrice = 0};

            cart.GamesCarts.Add(new GameCart()
            {
                AddedOn = DateTime.Now.AddDays(-3),
                Quantity = 2,
                Cart = cart,
                Game = game,
                IsDeleted = true
            });

            await _dbContext.Carts.AddAsync(cart);
            await _dbContext.SaveChangesAsync();

            //Act
            await _shoppingCartService.AddGameToCartAsync(game.Id.ToString(), user.Id.ToString(), game);

            //Assert
            Cart updatedCart = await _dbContext.Carts.FirstOrDefaultAsync(cart => cart.UserId == user.Id);

            GameCart reactiveItem = updatedCart.GamesCarts.FirstOrDefault(gc => gc.GameId == game.Id);

            Assert.IsNotNull(updatedCart);
            Assert.IsNotNull(reactiveItem);
            Assert.IsFalse(reactiveItem.IsDeleted);
            Assert.That(reactiveItem.Quantity, Is.EqualTo(1));
            Assert.That(updatedCart.TotalPrice, Is.EqualTo(20));
        }


        [Test]
        public async Task RemoveGameFromCartAsync_ShouldRemoveGameFromCart()
        {
            //Arrange
            ApplicationUser user = await _dbContext.Users.FirstAsync();
            Cart cart = new Cart() { User = user, TotalPrice = 20 };
            Game game = await _dbContext.Games.FirstAsync();
            cart.GamesCarts.Add(new GameCart { Game = game, Quantity = 2, AddedOn = DateTime.Now, IsDeleted = false, Cart = cart });
            await _dbContext.Carts.AddAsync(cart);
            await _dbContext.SaveChangesAsync();

            //Act
            await _shoppingCartService.RemoveGameFromCartAsync(game.Id.ToString(), user.Id.ToString(), game.Price);

            //Assert
            Cart? updatedCart = await _dbContext.Carts.Include(c => c.GamesCarts).FirstOrDefaultAsync(c => c.UserId == user.Id);

            Assert.IsNotNull(updatedCart); 
            Assert.That(updatedCart.GamesCarts.Count(gc => !gc.IsDeleted), Is.EqualTo(0));
            Assert.That(updatedCart.TotalPrice, Is.EqualTo(0));
        }

        [Test]
        public async Task RemoveGameFromCartAsync_ShouldNotChangeCartIfGameDoesNotExist()
        {
            //Arrange
            ApplicationUser user = await _dbContext.Users.FirstAsync();
            Cart cart = new Cart() { TotalPrice = 0, User = user };
            await _dbContext.Carts.AddAsync(cart);

            //Act
            await _shoppingCartService.RemoveGameFromCartAsync(Guid.NewGuid().ToString(), user.Id.ToString(), 20);

            //Assert
            Cart? updatedCart = await _dbContext.Carts.Include(gc => gc.GamesCarts).FirstOrDefaultAsync(gc => gc.UserId == user.Id);

            Assert.IsNotNull(updatedCart);
            Assert.That(updatedCart.GamesCarts.Count, Is.EqualTo(0));
            Assert.That(updatedCart.TotalPrice, Is.EqualTo(0));
        }

        [Test]
        public async Task RemoveGameFromCartAsync_ShouldRemoveOnlySpecificGame()
        {
            //Arrange
            ApplicationUser user = await _dbContext.Users.FirstAsync();
            Game game1 = await _dbContext.Games.FirstAsync();
            Game game2 = await _dbContext.Games.LastAsync();

            Cart cart = new Cart() { User = user, TotalPrice = 30};
            cart.GamesCarts.Add(new GameCart { Game = game1, Cart = cart, Quantity = 1 });
            cart.GamesCarts.Add(new GameCart { Quantity = 1, Game = game2, Cart = cart, });
            await _dbContext.Carts.AddAsync(cart);
            await _dbContext.SaveChangesAsync();

            //Act
            await _shoppingCartService.RemoveGameFromCartAsync(game1.Id.ToString(), user.Id.ToString(), game1.Price);

            //Assert
            Cart? updatedCart = await _dbContext.Carts.Include(gc => gc.GamesCarts).FirstOrDefaultAsync(gc => gc.UserId == user.Id);

            Assert.IsNotNull(updatedCart);
            Assert.That(updatedCart.GamesCarts.Count(gc => !gc.IsDeleted), Is.EqualTo(1));
            Assert.That(updatedCart.TotalPrice, Is.EqualTo(10));
            Assert.That(updatedCart.GamesCarts.First(gc => !gc.IsDeleted).GameId, Is.EqualTo(game2.Id));
        }

        [Test]
        public async Task GameItemExistInTheShoppingCart_ShouldReturnTrue_WhenItemExist()
        {
            //Arrange
            ApplicationUser user = await _dbContext.Users.FirstAsync();
            Game game1 = await _dbContext.Games.FirstAsync();

            Cart cart = new Cart() { User = user, TotalPrice = 30 };
            cart.GamesCarts.Add(new GameCart { Game = game1, Cart = cart, Quantity = 1 });

            await _dbContext.Carts.AddAsync(cart);
            await _dbContext.SaveChangesAsync();

            //Act
            bool result = await _shoppingCartService.GameItemExistInTheShoppingCart(game1.Id.ToString(), user.Id.ToString());

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task GameItemExistInTheShoppingCart_ShouldReturnFalse_WhenItemDoesNotExist()
        {
            ApplicationUser user = await _dbContext.Users.FirstAsync();

            //Act
            bool result = await _shoppingCartService.GameItemExistInTheShoppingCart(Guid.NewGuid().ToString(), user.Id.ToString());

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task EventItemExistInTheShoppingCart_ShouldReturnFalse_WhenItemDoesNotExist()
        {
            ApplicationUser user = await _dbContext.Users.FirstAsync();

            //Act
            bool result = await _shoppingCartService.EventItemExistInTheShoppingCart(Guid.NewGuid().ToString(), user.Id.ToString());

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task EventItemExistInTheShoppingCart_ShouldReturnTrue_WhenItemExist()
        {
            //Arrange
            ApplicationUser user = await _dbContext.Users.FirstAsync();
            Event e = await _dbContext.Events.FirstAsync();

            Cart cart = new Cart() { User = user, TotalPrice =20 };

            cart.EventsCarts.Add(new EventCart()
            {
                Event = e,
                TicketQuantity = 1,
                IsDeleted = false,
                Cart = cart,
                AddedOn = DateTime.UtcNow,

            });
            await _dbContext.Carts.AddAsync(cart);
            await _dbContext.SaveChangesAsync();

            //Act
            bool result = await _shoppingCartService.EventItemExistInTheShoppingCart(e.Id.ToString(), user.Id.ToString());

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task DecreaseGameQuantityAsync_ShouldDecreaseQuantityAndUpdateTotalPrice()
        {
            // Arrange
            ApplicationUser user = await _dbContext.Users.FirstAsync();
            Game game = await _dbContext.Games.FirstAsync();

            Cart cart = new Cart { User = user, TotalPrice = 40 };
            cart.GamesCarts.Add(new GameCart
            {
                Game = game,
                Cart = cart,
                Quantity = 2,
                IsDeleted = false
            });
            await _dbContext.Carts.AddAsync(cart);
            await _dbContext.SaveChangesAsync();

            // Act
            await _shoppingCartService.DecreaseGameQuantityAsync(game.Id.ToString(), user.Id.ToString());

            // Assert
            Cart updatedCart = await _dbContext.Carts
                .Include(c => c.GamesCarts)
                .FirstAsync(c => c.UserId == user.Id);

            GameCart updatedGameCart = updatedCart.GamesCarts.First(gc => gc.GameId == game.Id);

            Assert.IsNotNull(updatedCart);
            Assert.That(updatedGameCart.Quantity, Is.EqualTo(1));
            Assert.That(updatedCart.TotalPrice, Is.EqualTo(20));
        }

        [Test]
        public async Task DecreaseGameQuantityAsync_ShouldDoNothingIfGameIsDeleted()
        {
            // Arrange
            ApplicationUser user = await _dbContext.Users.FirstAsync();
            Game game = await _dbContext.Games.FirstAsync();

            Cart cart = new Cart { User = user, TotalPrice = 20 };
            cart.GamesCarts.Add(new GameCart
            {
                Game = game,
                Cart = cart,
                Quantity = 1,
                IsDeleted = true
            });
            await _dbContext.Carts.AddAsync(cart);
            await _dbContext.SaveChangesAsync();

            // Act
            await _shoppingCartService.DecreaseGameQuantityAsync(game.Id.ToString(), user.Id.ToString());

            // Assert
            Cart updatedCart = await _dbContext.Carts
                .Include(c => c.GamesCarts)
                .FirstAsync(c => c.UserId == user.Id);

            GameCart? gameCart = updatedCart.GamesCarts.FirstOrDefault(gc => gc.GameId == game.Id);

            Assert.IsNotNull(updatedCart);
            Assert.IsTrue(gameCart.IsDeleted);
            Assert.That(updatedCart.TotalPrice, Is.EqualTo(20)); 
        }

        [Test]
        public async Task DecreaseGameQuantityAsync_ShouldDoNothingIfGameDoesNotExist()
        {
            // Arrange
            ApplicationUser user = await _dbContext.Users.FirstAsync();

            Cart cart = new Cart { User = user, TotalPrice = 0 };
            await _dbContext.Carts.AddAsync(cart);
            await _dbContext.SaveChangesAsync();

            // Act
            await _shoppingCartService.DecreaseGameQuantityAsync(Guid.NewGuid().ToString(), user.Id.ToString());

            // Assert
            Cart updatedCart = await _dbContext.Carts
                .Include(c => c.GamesCarts)
                .FirstAsync(c => c.UserId == user.Id);

            Assert.IsNotNull(updatedCart);
            Assert.That(updatedCart.GamesCarts.Count, Is.EqualTo(0));
            Assert.That(updatedCart.TotalPrice, Is.EqualTo(0));
        }

        [Test]
        public async Task DecreaseGameQuantityAsync_ShouldMarkGameAsDeletedWhenQuantityIsOne()
        {
            // Arrange
            ApplicationUser user = await _dbContext.Users.FirstAsync();
            Game game = await _dbContext.Games.FirstAsync();

            Cart cart = new Cart { User = user, TotalPrice = 20 };
            cart.GamesCarts.Add(new GameCart
            {
                Game = game,
                Cart = cart,
                Quantity = 1,
                IsDeleted = false
            });
            await _dbContext.Carts.AddAsync(cart);
            await _dbContext.SaveChangesAsync();

            // Act
            await _shoppingCartService.DecreaseGameQuantityAsync(game.Id.ToString(), user.Id.ToString());

            // Assert
            Cart updatedCart = await _dbContext.Carts
                .Include(c => c.GamesCarts)
                .FirstAsync(c => c.UserId == user.Id);

            GameCart updatedGameCart = updatedCart.GamesCarts.First(gc => gc.GameId == game.Id);

            Assert.IsNotNull(updatedCart);
            Assert.IsTrue(updatedGameCart.IsDeleted);
            Assert.That(updatedCart.TotalPrice, Is.EqualTo(0));
        }

        [Test]
        public async Task DecreaseEventItemQuantityAsync_ShouldDecreaseTicketQuantityAndUpdateTotalPrice()
        {
            // Arrange
            ApplicationUser user = await _dbContext.Users.FirstAsync();
            Event e = await _dbContext.Events.FirstAsync();

            Cart cart = new Cart { User = user, TotalPrice = 40 };
            cart.EventsCarts.Add(new EventCart
            {
                Event = e,
                Cart = cart,
                TicketQuantity = 2,
                IsDeleted = false
            });
            await _dbContext.Carts.AddAsync(cart);
            await _dbContext.SaveChangesAsync();

            // Act
            await _shoppingCartService.DecreaseEventItemQuantityAsync(e.Id.ToString(), user.Id.ToString());

            // Assert
            Cart updatedCart = await _dbContext.Carts
                .Include(c => c.EventsCarts)
                .FirstAsync(c => c.UserId == user.Id);

            EventCart updatedEventCart = updatedCart.EventsCarts.First(ec => ec.EventId == e.Id);

            Assert.IsNotNull(updatedCart);
            Assert.That(updatedEventCart.TicketQuantity, Is.EqualTo(1));
            Assert.That(updatedCart.TotalPrice, Is.EqualTo(20));
        }

        [Test]
        public async Task DecreaseEventItemQuantityAsync_ShouldMarkEventAsDeletedWhenQuantityIsOne()
        {
            // Arrange
            ApplicationUser user = await _dbContext.Users.FirstAsync();
            Event e = await _dbContext.Events.FirstAsync();

            Cart cart = new Cart { User = user, TotalPrice = 20 };
            cart.EventsCarts.Add(new EventCart
            {
                Event = e,
                Cart = cart,
                TicketQuantity = 1,
                IsDeleted = false
            });
            await _dbContext.Carts.AddAsync(cart);
            await _dbContext.SaveChangesAsync();

            // Act
            await _shoppingCartService.DecreaseEventItemQuantityAsync(e.Id.ToString(), user.Id.ToString());

            // Assert
            Cart updatedCart = await _dbContext.Carts
                .Include(c => c.EventsCarts)
                .FirstAsync(c => c.UserId == user.Id);

            EventCart updatedEventCart = updatedCart.EventsCarts.First(ec => ec.EventId == e.Id);

            Assert.IsNotNull(updatedCart);
            Assert.IsTrue(updatedEventCart.IsDeleted);
            Assert.That(updatedCart.TotalPrice, Is.EqualTo(0));
        }

        [Test]
        public async Task DecreaseEventItemQuantityAsync_ShouldDoNothingIfEventDoesNotExist()
        {
            // Arrange
            ApplicationUser user = await _dbContext.Users.FirstAsync();

            Cart cart = new Cart { User = user, TotalPrice = 0 };
            await _dbContext.Carts.AddAsync(cart);
            await _dbContext.SaveChangesAsync();

            // Act
            await _shoppingCartService.DecreaseEventItemQuantityAsync(Guid.NewGuid().ToString(), user.Id.ToString());

            // Assert
            Cart updatedCart = await _dbContext.Carts
                .Include(c => c.EventsCarts)
                .FirstAsync(c => c.UserId == user.Id);

            Assert.IsNotNull(updatedCart);
            Assert.That(updatedCart.EventsCarts.Count, Is.EqualTo(0));
            Assert.That(updatedCart.TotalPrice, Is.EqualTo(0));
        }

        [Test]
        public async Task DecreaseEventItemQuantityAsync_ShouldDoNothingIfEventIsDeleted()
        {
            // Arrange
            ApplicationUser user = await _dbContext.Users.FirstAsync();
            Event e = await _dbContext.Events.FirstAsync();

            Cart cart = new Cart { User = user, TotalPrice = 20 };
            cart.EventsCarts.Add(new EventCart
            {
                Event = e,
                Cart = cart,
                TicketQuantity = 1,
                IsDeleted = true
            });
            await _dbContext.Carts.AddAsync(cart);
            await _dbContext.SaveChangesAsync();

            // Act
            await _shoppingCartService.DecreaseEventItemQuantityAsync(e.Id.ToString(), user.Id.ToString());

            // Assert
            Cart updatedCart = await _dbContext.Carts
                .Include(c => c.EventsCarts)
                .FirstAsync(c => c.UserId == user.Id);

            EventCart? eventCart = updatedCart.EventsCarts.FirstOrDefault(ec => ec.EventId == e.Id);

            Assert.IsNotNull(updatedCart);
            Assert.IsTrue(eventCart.IsDeleted);
            Assert.That(updatedCart.TotalPrice, Is.EqualTo(20));
        }

        [Test]
        public async Task IncreaseGameQuantityAsync_ShouldIncreaseGameQuantityAndUpdateTotalPrice()
        {
            // Arrange
            ApplicationUser user = await _dbContext.Users.FirstAsync();
            Game game = await _dbContext.Games.FirstAsync();

            Cart cart = new Cart { User = user, TotalPrice = 20 };
            cart.GamesCarts.Add(new GameCart
            {
                Game = game,
                Cart = cart,
                Quantity = 1,
                IsDeleted = false
            });
            await _dbContext.Carts.AddAsync(cart);
            await _dbContext.SaveChangesAsync();

            // Act
            await _shoppingCartService.IncreaseGameQuantityAsync(game.Id.ToString(), user.Id.ToString());

            // Assert
            Cart updatedCart = await _dbContext.Carts
                .Include(c => c.GamesCarts)
                .FirstAsync(c => c.UserId == user.Id);

            GameCart updatedGameCart = updatedCart.GamesCarts.First(gc => gc.GameId == game.Id);

            Assert.IsNotNull(updatedCart);
            Assert.That(updatedGameCart.Quantity, Is.EqualTo(2));
            Assert.That(updatedCart.TotalPrice, Is.EqualTo(40));
        }

        [Test]
        public async Task IncreaseGameQuantityAsync_ShouldDoNothingIfGameDoesNotExist()
        {
            // Arrange
            ApplicationUser user = await _dbContext.Users.FirstAsync();

            Cart cart = new Cart { User = user, TotalPrice = 0 };
            await _dbContext.Carts.AddAsync(cart);
            await _dbContext.SaveChangesAsync();

            // Act
            await _shoppingCartService.IncreaseGameQuantityAsync(Guid.NewGuid().ToString(), user.Id.ToString());

            // Assert
            Cart updatedCart = await _dbContext.Carts
                .Include(c => c.GamesCarts)
                .FirstAsync(c => c.UserId == user.Id);

            Assert.IsNotNull(updatedCart);
            Assert.That(updatedCart.GamesCarts.Count, Is.EqualTo(0));
            Assert.That(updatedCart.TotalPrice, Is.EqualTo(0));
        }

        [Test]
        public async Task IncreaseGameQuantityAsync_ShouldDoNothingIfGameIsDeleted()
        {
            // Arrange
            ApplicationUser user = await _dbContext.Users.FirstAsync();
            Game game = await _dbContext.Games.FirstAsync();

            Cart cart = new Cart { User = user, TotalPrice = 20 };
            cart.GamesCarts.Add(new GameCart
            {
                Game = game,
                Cart = cart,
                Quantity = 1,
                IsDeleted = true
            });
            await _dbContext.Carts.AddAsync(cart);
            await _dbContext.SaveChangesAsync();

            // Act
            await _shoppingCartService.IncreaseGameQuantityAsync(game.Id.ToString(), user.Id.ToString());

            // Assert
            Cart updatedCart = await _dbContext.Carts
                .Include(c => c.GamesCarts)
                .FirstAsync(c => c.UserId == user.Id);

            GameCart? gameCart = updatedCart.GamesCarts.FirstOrDefault(gc => gc.GameId == game.Id);

            Assert.IsNotNull(updatedCart);
            Assert.IsTrue(gameCart.IsDeleted);
            Assert.That(updatedCart.TotalPrice, Is.EqualTo(20)); 
        }

        [Test]
        public async Task IncreaseEventItemQuantity_ShouldIncreaseTicketQuantityAndUpdateTotalPrice()
        {
            // Arrange
            ApplicationUser user = await _dbContext.Users.FirstAsync();
            Event e = await _dbContext.Events.FirstAsync();

            Cart cart = new Cart { User = user, TotalPrice = 20 };
            cart.EventsCarts.Add(new EventCart
            {
                Event = e,
                Cart = cart,
                TicketQuantity = 1,
                IsDeleted = false
            });
            await _dbContext.Carts.AddAsync(cart);
            await _dbContext.SaveChangesAsync();

            // Act
            await _shoppingCartService.IncreaseEventItemQuantity(e.Id.ToString(), user.Id.ToString());

            // Assert
            Cart updatedCart = await _dbContext.Carts
                .Include(c => c.EventsCarts)
                .FirstAsync(c => c.UserId == user.Id);

            EventCart updatedEventCart = updatedCart.EventsCarts.First(ec => ec.EventId == e.Id);

            Assert.IsNotNull(updatedCart);
            Assert.That(updatedEventCart.TicketQuantity, Is.EqualTo(2));
            Assert.That(updatedCart.TotalPrice, Is.EqualTo(40));
        }

        [Test]
        public async Task IncreaseEventItemQuantity_ShouldDoNothingIfEventDoesNotExist()
        {
            // Arrange
            ApplicationUser user = await _dbContext.Users.FirstAsync();

            Cart cart = new Cart { User = user, TotalPrice = 0 };
            await _dbContext.Carts.AddAsync(cart);
            await _dbContext.SaveChangesAsync();

            // Act
            await _shoppingCartService.IncreaseEventItemQuantity(Guid.NewGuid().ToString(), user.Id.ToString());

            // Assert
            Cart updatedCart = await _dbContext.Carts
                .Include(c => c.EventsCarts)
                .FirstAsync(c => c.UserId == user.Id);

            Assert.IsNotNull(updatedCart);
            Assert.That(updatedCart.EventsCarts.Count, Is.EqualTo(0));
            Assert.That(updatedCart.TotalPrice, Is.EqualTo(0));
        }

        [Test]
        public async Task IncreaseEventItemQuantity_ShouldDoNothingIfEventIsDeleted()
        {
            // Arrange
            ApplicationUser user = await _dbContext.Users.FirstAsync();
            Event e = await _dbContext.Events.FirstAsync();

            Cart cart = new Cart { User = user, TotalPrice = 20 };
            cart.EventsCarts.Add(new EventCart
            {
                Event = e,
                Cart = cart,
                TicketQuantity = 1,
                IsDeleted = true
            });
            await _dbContext.Carts.AddAsync(cart);
            await _dbContext.SaveChangesAsync();

            // Act
            await _shoppingCartService.IncreaseEventItemQuantity(e.Id.ToString(), user.Id.ToString());

            // Assert
            Cart updatedCart = await _dbContext.Carts
                .Include(c => c.EventsCarts)
                .FirstAsync(c => c.UserId == user.Id);

            EventCart? eventCart = updatedCart.EventsCarts.FirstOrDefault(ec => ec.EventId == e.Id);

            Assert.IsNotNull(updatedCart);
            Assert.IsTrue(eventCart.IsDeleted);
            Assert.That(updatedCart.TotalPrice, Is.EqualTo(20));
        }

        [Test]
        public async Task ClearCart_ShouldMarkAllItemsAsDeletedAndResetTotalPrice()
        {
            // Arrange
            ApplicationUser user = await _dbContext.Users.FirstAsync();
            Game game = await _dbContext.Games.FirstAsync();
            Event e = await _dbContext.Events.FirstAsync();

            Cart cart = new Cart { User = user, TotalPrice = 50 };
            cart.GamesCarts.Add(new GameCart
            {
                Game = game,
                Cart = cart,
                Quantity = 1,
                IsDeleted = false
            });
            cart.EventsCarts.Add(new EventCart
            {
                Event = e,
                Cart = cart,
                TicketQuantity = 1,
                IsDeleted = false
            });
            await _dbContext.Carts.AddAsync(cart);
            await _dbContext.SaveChangesAsync();

            // Act
            await _shoppingCartService.ClearCart(cart);

            // Assert
            Cart updatedCart = await _dbContext.Carts
                .Include(c => c.GamesCarts)
                .Include(c => c.EventsCarts)
                .FirstAsync(c => c.UserId == user.Id);

            Assert.IsNotNull(updatedCart);
            Assert.IsTrue(updatedCart.GamesCarts.All(gc => gc.IsDeleted));
            Assert.IsTrue(updatedCart.EventsCarts.All(ec => ec.IsDeleted));
            Assert.That(updatedCart.TotalPrice, Is.EqualTo(0));
        }

        [Test]
        public async Task ClearCart_ShouldDoNothingIfCartHasNoItems()
        {
            // Arrange
            ApplicationUser user = await _dbContext.Users.FirstAsync();

            Cart cart = new Cart { User = user, TotalPrice = 0 };
            await _dbContext.Carts.AddAsync(cart);
            await _dbContext.SaveChangesAsync();

            // Act
            await _shoppingCartService.ClearCart(cart);

            // Assert
            Cart updatedCart = await _dbContext.Carts
                .Include(c => c.GamesCarts)
                .Include(c => c.EventsCarts)
                .FirstAsync(c => c.UserId == user.Id);

            Assert.IsNotNull(updatedCart);
            Assert.That(updatedCart.GamesCarts.Count, Is.EqualTo(0));
            Assert.That(updatedCart.EventsCarts.Count, Is.EqualTo(0));
            Assert.That(updatedCart.TotalPrice, Is.EqualTo(0));
        }

        [Test]
        public async Task ClearCart_ShouldMarkOnlyGamesAsDeletedAndResetTotalPrice()
        {
            // Arrange
            ApplicationUser user = await _dbContext.Users.FirstAsync();
            Game game = await _dbContext.Games.FirstAsync();

            Cart cart = new Cart { User = user, TotalPrice = 30 };
            cart.GamesCarts.Add(new GameCart
            {
                Game = game,
                Cart = cart,
                Quantity = 1,
                IsDeleted = false
            });
            await _dbContext.Carts.AddAsync(cart);
            await _dbContext.SaveChangesAsync();

            // Act
            await _shoppingCartService.ClearCart(cart);

            // Assert
            Cart updatedCart = await _dbContext.Carts
                .Include(c => c.GamesCarts)
                .Include(c => c.EventsCarts)
                .FirstAsync(c => c.UserId == user.Id);

            Assert.IsNotNull(updatedCart);
            Assert.IsTrue(updatedCart.GamesCarts.All(gc => gc.IsDeleted));
            Assert.That(updatedCart.EventsCarts.Count, Is.EqualTo(0));
            Assert.That(updatedCart.TotalPrice, Is.EqualTo(0));
        }

        [Test]
        public async Task ClearCart_ShouldMarkOnlyEventsAsDeletedAndResetTotalPrice()
        {
            // Arrange
            ApplicationUser user = await _dbContext.Users.FirstAsync();
            Event e = await _dbContext.Events.FirstAsync();

            Cart cart = new Cart { User = user, TotalPrice = 20 };
            cart.EventsCarts.Add(new EventCart
            {
                Event = e,
                Cart = cart,
                TicketQuantity = 1,
                IsDeleted = false
            });
            await _dbContext.Carts.AddAsync(cart);
            await _dbContext.SaveChangesAsync();

            // Act
            await _shoppingCartService.ClearCart(cart);

            // Assert
            Cart updatedCart = await _dbContext.Carts
                .Include(c => c.GamesCarts)
                .Include(c => c.EventsCarts)
                .FirstAsync(c => c.UserId == user.Id);

            Assert.IsNotNull(updatedCart);
            Assert.That(updatedCart.GamesCarts.Count, Is.EqualTo(0));
            Assert.IsTrue(updatedCart.EventsCarts.All(ec => ec.IsDeleted));
            Assert.That(updatedCart.TotalPrice, Is.EqualTo(0));
        }

        [Test]
        public async Task GetOrCreateUserCart_ShouldReturnExistingCart()
        {
            // Arrange
            ApplicationUser user = await _dbContext.Users.FirstAsync();
            Game game = await _dbContext.Games.FirstAsync();
            Event e = await _dbContext.Events.FirstAsync();

            Cart existingCart = new Cart
            {
                UserId = user.Id,
                TotalPrice = 50,
                GamesCarts = new HashSet<GameCart>
                {
                    new GameCart { Game = game, Quantity = 1, IsDeleted = false }
                },
                EventsCarts = new HashSet<EventCart>
                {
                    new EventCart { Event = e, TicketQuantity = 1, IsDeleted = false }
                }
            };

            await _dbContext.Carts.AddAsync(existingCart);
            await _dbContext.SaveChangesAsync();

            // Act
            Cart result = await _shoppingCartService.GetOrCreateUserCart(user.Id.ToString());

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.UserId, Is.EqualTo(user.Id));
            Assert.That(result.GamesCarts.Count, Is.EqualTo(1));
            Assert.That(result.EventsCarts.Count, Is.EqualTo(1));
            Assert.That(result.TotalPrice, Is.EqualTo(50));
        }

        [Test]
        public async Task GetOrCreateUserCart_ShouldCreateNewCartIfNoneExists()
        {
            // Arrange
            ApplicationUser user = await _dbContext.Users.FirstAsync();

            // Act
            Cart result = await _shoppingCartService.GetOrCreateUserCart(user.Id.ToString());

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.UserId, Is.EqualTo(user.Id));
            Assert.That(result.TotalPrice, Is.EqualTo(0));
            Assert.That(result.GamesCarts.Count, Is.EqualTo(0));
            Assert.That(result.EventsCarts.Count, Is.EqualTo(0));

            Cart? createdCart = await _dbContext.Carts.FirstOrDefaultAsync(c => c.UserId == user.Id);
            Assert.IsNotNull(createdCart);
        }

        [Test]
        public async Task GetOrCreateUserCart_ShouldRetrieveCartWithOnlyGames()
        {
            // Arrange
            ApplicationUser user = await _dbContext.Users.FirstAsync();
            Game game = await _dbContext.Games.FirstAsync();

            Cart existingCart = new Cart
            {
                UserId = user.Id,
                TotalPrice = 20,
                GamesCarts = new HashSet<GameCart>
                {
                    new GameCart { Game = game, Quantity = 1, IsDeleted = false }
                }
            };

            await _dbContext.Carts.AddAsync(existingCart);
            await _dbContext.SaveChangesAsync();

            // Act
            Cart result = await _shoppingCartService.GetOrCreateUserCart(user.Id.ToString());

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.UserId, Is.EqualTo(user.Id));
            Assert.That(result.GamesCarts.Count, Is.EqualTo(1));
            Assert.That(result.EventsCarts.Count, Is.EqualTo(0));
            Assert.That(result.TotalPrice, Is.EqualTo(20));
        }

        [Test]
        public async Task GetOrCreateUserCart_ShouldRetrieveCartWithOnlyEvents()
        {
            // Arrange
            ApplicationUser user = await _dbContext.Users.FirstAsync();
            Event e = await _dbContext.Events.FirstAsync();

            Cart existingCart = new Cart
            {
                UserId = user.Id,
                TotalPrice = 30,
                EventsCarts = new HashSet<EventCart>
                {
                    new EventCart { Event = e, TicketQuantity = 1, IsDeleted = false }
                }
            };

            await _dbContext.Carts.AddAsync(existingCart);
            await _dbContext.SaveChangesAsync();

            // Act
            Cart result = await _shoppingCartService.GetOrCreateUserCart(user.Id.ToString());

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.UserId, Is.EqualTo(user.Id));
            Assert.That(result.GamesCarts.Count, Is.EqualTo(0));
            Assert.That(result.EventsCarts.Count, Is.EqualTo(1));
            Assert.That(result.TotalPrice, Is.EqualTo(30));
        }

        [Test]
        public async Task RemoveEventFromCartAsync_ShouldMarkEventAsDeletedAndUpdateTotalPrice()
        {
            // Arrange
            ApplicationUser user = await _dbContext.Users.FirstAsync();
            Event e = await _dbContext.Events.FirstAsync();

            Cart cart = new Cart { User = user, TotalPrice = 20 };
            cart.EventsCarts.Add(new EventCart
            {
                Event = e,
                Cart = cart,
                TicketQuantity = 1,
                IsDeleted = false
            });
            await _dbContext.Carts.AddAsync(cart);
            await _dbContext.SaveChangesAsync();

            // Act
            await _shoppingCartService.RemoveEventFromCartAsync(e.Id.ToString(), user.Id.ToString(), e.TicketPrice);

            // Assert
            Cart updatedCart = await _dbContext.Carts
                .Include(c => c.EventsCarts)
                .FirstAsync(c => c.UserId == user.Id);

            EventCart updatedEventCart = updatedCart.EventsCarts.First(ec => ec.EventId == e.Id);

            Assert.IsNotNull(updatedCart);
            Assert.IsTrue(updatedEventCart.IsDeleted);
            Assert.That(updatedCart.TotalPrice, Is.EqualTo(0));
        }

        [Test]
        public async Task RemoveEventFromCartAsync_ShouldDoNothingIfEventDoesNotExist()
        {
            // Arrange
            ApplicationUser user = await _dbContext.Users.FirstAsync();

            Cart cart = new Cart { User = user, TotalPrice = 0 };
            await _dbContext.Carts.AddAsync(cart);
            await _dbContext.SaveChangesAsync();

            // Act
            await _shoppingCartService.RemoveEventFromCartAsync(Guid.NewGuid().ToString(), user.Id.ToString(), 20);

            // Assert
            Cart updatedCart = await _dbContext.Carts
                .Include(c => c.EventsCarts)
                .FirstAsync(c => c.UserId == user.Id);

            Assert.IsNotNull(updatedCart);
            Assert.That(updatedCart.EventsCarts.Count, Is.EqualTo(0));
            Assert.That(updatedCart.TotalPrice, Is.EqualTo(0));
        }

        [Test]
        public async Task RemoveEventFromCartAsync_ShouldDoNothingIfEventIsDeleted()
        {
            // Arrange
            ApplicationUser user = await _dbContext.Users.FirstAsync();
            Event e = await _dbContext.Events.FirstAsync();

            Cart cart = new Cart { User = user, TotalPrice = 20 };
            cart.EventsCarts.Add(new EventCart
            {
                Event = e,
                Cart = cart,
                TicketQuantity = 1,
                IsDeleted = true
            });
            await _dbContext.Carts.AddAsync(cart);
            await _dbContext.SaveChangesAsync();

            // Act
            await _shoppingCartService.RemoveEventFromCartAsync(e.Id.ToString(), user.Id.ToString(), e.TicketPrice);

            // Assert
            Cart updatedCart = await _dbContext.Carts
                .Include(c => c.EventsCarts)
                .FirstAsync(c => c.UserId == user.Id);

            EventCart? eventCart = updatedCart.EventsCarts.FirstOrDefault(ec => ec.EventId == e.Id);

            Assert.IsNotNull(updatedCart);
            Assert.IsTrue(eventCart.IsDeleted);
            Assert.That(updatedCart.TotalPrice, Is.EqualTo(20));
        }

        [Test]
        public async Task RemoveEventFromCartAsync_ShouldRemoveOnlySpecifiedEvent()
        {
            // Arrange
            ApplicationUser user = await _dbContext.Users.FirstAsync();
            Event e1 = await _dbContext.Events.FirstAsync();
            Event e2 = await _dbContext.Events.LastAsync();

            Cart cart = new Cart { User = user, TotalPrice = 40 };
            cart.EventsCarts.Add(new EventCart
            {
                Event = e1,
                Cart = cart,
                TicketQuantity = 1,
                IsDeleted = false
            });
            cart.EventsCarts.Add(new EventCart
            {
                Event = e2,
                Cart = cart,
                TicketQuantity = 1,
                IsDeleted = false
            });
            await _dbContext.Carts.AddAsync(cart);
            await _dbContext.SaveChangesAsync();

            // Act
            await _shoppingCartService.RemoveEventFromCartAsync(e1.Id.ToString(), user.Id.ToString(), e1.TicketPrice);

            // Assert
            Cart updatedCart = await _dbContext.Carts
                .Include(c => c.EventsCarts)
                .FirstAsync(c => c.UserId == user.Id);

            EventCart removedEvent = updatedCart.EventsCarts.First(ec => ec.EventId == e1.Id);
            EventCart remainingEvent = updatedCart.EventsCarts.First(ec => ec.EventId == e2.Id);

            Assert.IsNotNull(updatedCart);
            Assert.IsTrue(removedEvent.IsDeleted);
            Assert.IsFalse(remainingEvent.IsDeleted);
            Assert.That(updatedCart.TotalPrice, Is.EqualTo(20));
        }

        [Test]
        public async Task AddEventToCartAsync_ShouldAddNewEventToCart()
        {
            // Arrange
            ApplicationUser user = await _dbContext.Users.FirstAsync();
            Event e = await _dbContext.Events.FirstAsync();

            Cart cart = new Cart { User = user, TotalPrice = 0 };
            await _dbContext.Carts.AddAsync(cart);
            await _dbContext.SaveChangesAsync();

            // Act
            await _shoppingCartService.AddEventToCartAsync(e.Id.ToString(), user.Id.ToString(), e);

            // Assert
            Cart updatedCart = await _dbContext.Carts
                .Include(c => c.EventsCarts)
                .FirstAsync(c => c.UserId == user.Id);

            EventCart? eventCart = updatedCart.EventsCarts.FirstOrDefault(ec => ec.EventId == e.Id);

            Assert.IsNotNull(updatedCart);
            Assert.That(updatedCart.EventsCarts.Count, Is.EqualTo(1));
            Assert.IsNotNull(eventCart);
            Assert.That(eventCart.TicketQuantity, Is.EqualTo(1));
            Assert.That(updatedCart.TotalPrice, Is.EqualTo(e.TicketPrice));
        }

        [Test]
        public async Task AddEventToCartAsync_ShouldIncrementTicketQuantityForExistingEvent()
        {
            // Arrange
            ApplicationUser user = await _dbContext.Users.FirstAsync();
            Event e = await _dbContext.Events.FirstAsync();

            Cart cart = new Cart { User = user, TotalPrice = e.TicketPrice };
            cart.EventsCarts.Add(new EventCart
            {
                Event = e,
                Cart = cart,
                TicketQuantity = 1,
                IsDeleted = false
            });
            await _dbContext.Carts.AddAsync(cart);
            await _dbContext.SaveChangesAsync();

            // Act
            await _shoppingCartService.AddEventToCartAsync(e.Id.ToString(), user.Id.ToString(), e);

            // Assert
            Cart updatedCart = await _dbContext.Carts
                .Include(c => c.EventsCarts)
                .FirstAsync(c => c.UserId == user.Id);

            EventCart? eventCart = updatedCart.EventsCarts.FirstOrDefault(ec => ec.EventId == e.Id);

            Assert.IsNotNull(updatedCart);
            Assert.That(updatedCart.EventsCarts.Count, Is.EqualTo(1));
            Assert.That(eventCart.TicketQuantity, Is.EqualTo(2));
            Assert.That(updatedCart.TotalPrice, Is.EqualTo(e.TicketPrice * 2));
        }

        [Test]
        public async Task AddEventToCartAsync_ShouldReactivateDeletedEvent()
        {
            // Arrange
            ApplicationUser user = await _dbContext.Users.FirstAsync();
            Event e = await _dbContext.Events.FirstAsync();

            Cart cart = new Cart { User = user, TotalPrice = 0 };
            cart.EventsCarts.Add(new EventCart
            {
                Event = e,
                Cart = cart,
                TicketQuantity = 0,
                IsDeleted = true
            });
            await _dbContext.Carts.AddAsync(cart);
            await _dbContext.SaveChangesAsync();

            // Act
            await _shoppingCartService.AddEventToCartAsync(e.Id.ToString(), user.Id.ToString(), e);

            // Assert
            Cart updatedCart = await _dbContext.Carts
                .Include(c => c.EventsCarts)
                .FirstAsync(c => c.UserId == user.Id);

            EventCart? eventCart = updatedCart.EventsCarts.FirstOrDefault(ec => ec.EventId == e.Id);

            Assert.IsNotNull(updatedCart);
            Assert.That(updatedCart.EventsCarts.Count, Is.EqualTo(1));
            Assert.IsNotNull(eventCart);
            Assert.IsFalse(eventCart.IsDeleted);
            Assert.That(eventCart.TicketQuantity, Is.EqualTo(1));
            Assert.That(updatedCart.TotalPrice, Is.EqualTo(e.TicketPrice));
        }

        [Test]
        public async Task AddEventToCartAsync_ShouldAddMultipleEventsToCart()
        {
            // Arrange
            ApplicationUser user = await _dbContext.Users.FirstAsync();
            Event e1 = await _dbContext.Events.FirstAsync();
            Event e2 = await _dbContext.Events.LastAsync();

            Cart cart = new Cart { User = user, TotalPrice = 0 };
            await _dbContext.Carts.AddAsync(cart);
            await _dbContext.SaveChangesAsync();

            // Act
            await _shoppingCartService.AddEventToCartAsync(e1.Id.ToString(), user.Id.ToString(), e1);
            await _shoppingCartService.AddEventToCartAsync(e2.Id.ToString(), user.Id.ToString(), e2);

            // Assert
            Cart updatedCart = await _dbContext.Carts
                .Include(c => c.EventsCarts)
                .FirstAsync(c => c.UserId == user.Id);

            Assert.IsNotNull(updatedCart);
            Assert.That(updatedCart.EventsCarts.Count, Is.EqualTo(2));
            Assert.That(updatedCart.TotalPrice, Is.EqualTo(e1.TicketPrice + e2.TicketPrice));
        }

        [Test]
        public async Task GetShoppingCartItemsAsync_ShouldReturnCartWithGamesAndEvents()
        {
            // Arrange
            ApplicationUser user = await _dbContext.Users.FirstAsync();
            Game game = await _dbContext.Games.FirstAsync();
            Event e = await _dbContext.Events.FirstAsync();

            Cart cart = new Cart { User = user, TotalPrice = 50 };
            cart.GamesCarts.Add(new GameCart
            {
                Game = game,
                Quantity = 1,
                AddedOn = DateTime.Now,
                IsDeleted = false
            });
            cart.EventsCarts.Add(new EventCart
            {
                Event = e,
                TicketQuantity = 1,
                AddedOn = DateTime.Now,
                IsDeleted = false
            });
            await _dbContext.Carts.AddAsync(cart);
            await _dbContext.SaveChangesAsync();

            // Act
            ShoppingCartViewModel result = await _shoppingCartService.GetShoppingCartItemsAsync(user.Id.ToString());

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.GameCartItems.Count(), Is.EqualTo(1));
            Assert.That(result.EventCartItems.Count(), Is.EqualTo(1));
            Assert.That(result.TotalPrice, Is.EqualTo("50,00 лв.")); 
        }

        [Test]
        public async Task GetShoppingCartItemsAsync_ShouldReturnEmptyCartIfNoItems()
        {
            // Arrange
            ApplicationUser user = await _dbContext.Users.FirstAsync();
            Cart cart = new Cart { User = user, TotalPrice = 0 };
            await _dbContext.Carts.AddAsync(cart);
            await _dbContext.SaveChangesAsync();

            // Act
            ShoppingCartViewModel result = await _shoppingCartService.GetShoppingCartItemsAsync(user.Id.ToString());

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.GameCartItems.Count(), Is.EqualTo(0));
            Assert.That(result.EventCartItems.Count(), Is.EqualTo(0));
            Assert.That(result.TotalPrice, Is.EqualTo("0,00 лв.")); 
        }

        [Test]
        public async Task GetShoppingCartItemsAsync_ShouldExcludeDeletedItems()
        {
            // Arrange
            ApplicationUser user = await _dbContext.Users.FirstAsync();
            Game game = await _dbContext.Games.FirstAsync();
            Event e = await _dbContext.Events.FirstAsync();

            Cart cart = new Cart { User = user, TotalPrice = 50 };
            cart.GamesCarts.Add(new GameCart
            {
                Game = game,
                Quantity = 1,
                AddedOn = DateTime.Now,
                IsDeleted = true 
            });
            cart.EventsCarts.Add(new EventCart
            {
                Event = e,
                TicketQuantity = 1,
                AddedOn = DateTime.Now,
                IsDeleted = false
            });
            await _dbContext.Carts.AddAsync(cart);
            await _dbContext.SaveChangesAsync();

            // Act
            ShoppingCartViewModel result = await _shoppingCartService.GetShoppingCartItemsAsync(user.Id.ToString());

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.GameCartItems.Count(), Is.EqualTo(0));
            Assert.That(result.EventCartItems.Count(), Is.EqualTo(1));
            Assert.That(result.TotalPrice, Is.EqualTo("50,00 лв.")); 
        }

        [Test]
        public async Task GetShoppingCartItemsAsync_ShouldCreateCartIfNoneExists()
        {
            // Arrange
            ApplicationUser user = await _dbContext.Users.FirstAsync();

            // Act
            ShoppingCartViewModel result = await _shoppingCartService.GetShoppingCartItemsAsync(user.Id.ToString());

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.GameCartItems.Count(), Is.EqualTo(0));
            Assert.That(result.EventCartItems.Count(), Is.EqualTo(0));
            Assert.That(result.TotalPrice, Is.EqualTo("0,00 лв.")); 

            Cart? createdCart = await _dbContext.Carts.FirstOrDefaultAsync(c => c.UserId == user.Id);
            Assert.IsNotNull(createdCart);
        }

        [Test]
        public async Task PurchaseItemsInShoppingCart_ShouldPurchaseGamesAndEventsAndClearCart()
        {
            // Arrange
            ApplicationUser user = await _dbContext.Users.FirstAsync();
            Game game = await _dbContext.Games.FirstAsync();
            Event e = await _dbContext.Events.FirstAsync();

            Cart cart = new Cart { User = user, TotalPrice = 50 };
            cart.GamesCarts.Add(new GameCart
            {
                Game = game,
                Cart = cart,
                Quantity = 1,
                IsDeleted = false
            });
            cart.EventsCarts.Add(new EventCart
            {
                Event = e,
                Cart = cart,
                TicketQuantity = 1,
                IsDeleted = false
            });
            await _dbContext.Carts.AddAsync(cart);
            await _dbContext.SaveChangesAsync();

            int initialGameStock = game.QuantityInStock;
            int initialEventSeats = e.Seats;

            // Act
            await _shoppingCartService.PurchaseItemsInShoppingCart(user.Id.ToString());

            // Assert
            Cart updatedCart = await _dbContext.Carts
                .Include(c => c.GamesCarts)
                .Include(c => c.EventsCarts)
                .FirstAsync(c => c.UserId == user.Id);

            Assert.IsNotNull(updatedCart);
            Assert.That(updatedCart.GamesCarts.Count(gc => !gc.IsDeleted), Is.EqualTo(0));
            Assert.That(updatedCart.EventsCarts.Count(ec => !ec.IsDeleted), Is.EqualTo(0));

            Game updatedGame = await _dbContext.Games.FirstAsync(g => g.Id == game.Id);
            Assert.That(updatedGame.QuantityInStock, Is.EqualTo(initialGameStock - 1));

            Event updatedEvent = await _dbContext.Events.FirstAsync(ev => ev.Id == e.Id);
            Assert.That(updatedEvent.Seats, Is.EqualTo(initialEventSeats - 1));

            UserBoughtGame? boughtGame = await _dbContext.UserBoughtGames
                .FirstOrDefaultAsync(ubg => ubg.UserId == user.Id && ubg.GameId == game.Id);
            Assert.IsNotNull(boughtGame);
            Assert.That(boughtGame.Quantity, Is.EqualTo(1));

            // Verify EventRegistration is created
            EventRegistration? eventRegistration = await _dbContext.EventsRegistrations
                .FirstOrDefaultAsync(er => er.UserId == user.Id && er.EventId == e.Id);
            Assert.IsNotNull(eventRegistration);
            Assert.That(eventRegistration.TicketQuantity, Is.EqualTo(1));
        }

        [Test]
        public async Task PurchaseItemsInShoppingCart_ShouldThrowExceptionIfCartIsEmpty()
        {
            // Arrange
            ApplicationUser user = await _dbContext.Users.FirstAsync();
            Cart cart = new Cart { User = user, TotalPrice = 0 };
            await _dbContext.Carts.AddAsync(cart);
            await _dbContext.SaveChangesAsync();

            // Act & Assert
            InvalidOperationException ex = Assert.ThrowsAsync<InvalidOperationException>(
                async () => await _shoppingCartService.PurchaseItemsInShoppingCart(user.Id.ToString())
            );

            Assert.That(ex.Message, Is.EqualTo("Your shopping cart is empty"));
        }

        [Test]
        public async Task PurchaseItemsInShoppingCart_ShouldThrowExceptionIfGameStockIsInsufficient()
        {
            // Arrange
            ApplicationUser user = await _dbContext.Users.FirstAsync();
            Game game = await _dbContext.Games.FirstAsync();

            game.QuantityInStock = 0;
            await _dbContext.SaveChangesAsync();

            Cart cart = new Cart { User = user, TotalPrice = game.Price };
            cart.GamesCarts.Add(new GameCart
            {
                Game = game,
                Cart = cart,
                Quantity = 1,
                IsDeleted = false
            });
            await _dbContext.Carts.AddAsync(cart);
            await _dbContext.SaveChangesAsync();

            // Act & Assert
            InvalidOperationException ex = Assert.ThrowsAsync<InvalidOperationException>(
                async () => await _shoppingCartService.PurchaseItemsInShoppingCart(user.Id.ToString())
            );

            Assert.That(ex.Message, Is.EqualTo($"Not enough quantity in stock for game: {game.Title}"));
        }

        [Test]
        public async Task PurchaseItemsInShoppingCart_ShouldThrowExceptionIfEventSeatsAreInsufficient()
        {
            // Arrange
            ApplicationUser user = await _dbContext.Users.FirstAsync();
            Event e = await _dbContext.Events.FirstAsync();

            e.Seats = 0;
            await _dbContext.SaveChangesAsync();

            Cart cart = new Cart { User = user, TotalPrice = e.TicketPrice };
            cart.EventsCarts.Add(new EventCart
            {
                Event = e,
                Cart = cart,
                TicketQuantity = 1,
                IsDeleted = false
            });
            await _dbContext.Carts.AddAsync(cart);
            await _dbContext.SaveChangesAsync();

            // Act & Assert
            InvalidOperationException ex = Assert.ThrowsAsync<InvalidOperationException>(
                async () => await _shoppingCartService.PurchaseItemsInShoppingCart(user.Id.ToString())
            );

            Assert.That(ex.Message, Is.EqualTo($"Not enough empty seats for event: {e.Topic}"));
        }

        [Test]
        public async Task PurchaseItemsInShoppingCart_ShouldHandleMultipleGamesAndEvents()
        {
            // Arrange
            ApplicationUser user = await _dbContext.Users.FirstAsync();
            Game game1 = await _dbContext.Games.FirstAsync();
            Game game2 = await _dbContext.Games.LastAsync();
            Event e1 = await _dbContext.Events.FirstAsync();
            Event e2 = await _dbContext.Events.LastAsync();

            Cart cart = new Cart { User = user, TotalPrice = 100 };
            cart.GamesCarts.Add(new GameCart { Game = game1, Cart = cart, Quantity = 1, IsDeleted = false });
            cart.GamesCarts.Add(new GameCart { Game = game2, Cart = cart, Quantity = 1, IsDeleted = false });
            cart.EventsCarts.Add(new EventCart { Event = e1, Cart = cart, TicketQuantity = 1, IsDeleted = false });
            cart.EventsCarts.Add(new EventCart { Event = e2, Cart = cart, TicketQuantity = 1, IsDeleted = false });
            await _dbContext.Carts.AddAsync(cart);
            await _dbContext.SaveChangesAsync();

            // Act
            await _shoppingCartService.PurchaseItemsInShoppingCart(user.Id.ToString());

            // Assert
            Cart updatedCart = await _dbContext.Carts
                .Include(c => c.GamesCarts)
                .Include(c => c.EventsCarts)
                .FirstAsync(c => c.UserId == user.Id);

            Assert.That(updatedCart.GamesCarts.Count(gc => !gc.IsDeleted), Is.EqualTo(0));
            Assert.That(updatedCart.EventsCarts.Count(ec => !ec.IsDeleted), Is.EqualTo(0));
        }

    }
}
