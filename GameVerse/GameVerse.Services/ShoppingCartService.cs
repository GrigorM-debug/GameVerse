

using GameVerse.Data.Models.Carts;
using GameVerse.Data.Models.Events;
using GameVerse.Data.Models.Games;
using GameVerse.Data.Repositories.Interfaces;
using GameVerse.Services.Interfaces;
using GameVerse.Web.ViewModels.ShoppingCart;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Runtime.InteropServices.JavaScript;
using QRCoder;
using static GameVerse.Common.ApplicationConstants.EventConstants;

namespace GameVerse.Services
{
    /// <summary>
    /// Provides functionality for managing shopping carts, including adding, removing, 
    /// and purchasing games and events, as well as handling cart operations for users.
    /// </summary>
    public class ShoppingCartService(
        IGenericRepository<Cart, Guid> _cartRepository,
        IGenericRepository<Game, Guid> _gameRepository,
        IGenericRepository<Event, Guid> _eventRepository,
        IGenericRepository<EventRegistration, object> _eventRegistrationRepository,
        IGenericRepository<UserBoughtGame, object> _userBoughtGamesRepository,
        IQrCodeService _qrCodeService
        ) : BaseService, IShoppingCartService
    {
        /// <summary>
        /// Retrieves the shopping cart items for the specified user.
        /// </summary>
        /// <param name="userId">The unique ID of the user.</param>
        /// <returns>
        /// A task containing a <see cref="ShoppingCartViewModel"/> with the details of the shopping cart.
        /// </returns>
        public async Task<ShoppingCartViewModel> GetShoppingCartItemsAsync(string userId)
        {
            Cart? cart = await GetOrCreateUserCart(userId);

            ShoppingCartViewModel model = new ShoppingCartViewModel();

            IEnumerable<GameCart> activeGameCarts = cart.GamesCarts.Where(gc => !gc.IsDeleted).ToList();
            IEnumerable<EventCart> activeEventCarts = cart.EventsCarts.Where(ec => !ec.IsDeleted).ToList();

            IEnumerable<GameCartItemsViewModel> gameCartItemsViewModels = activeGameCarts.Select(gameCart => new GameCartItemsViewModel
            {
                Id = gameCart.GameId.ToString(),
                Title = gameCart.Game.Title,
                Price = gameCart.Game.Price.ToString("C"),
                AddedOn = gameCart.AddedOn.ToString(EventDateTimeFormat, CultureInfo.InvariantCulture),
                Quantity = gameCart.Quantity,
                TotalPrice = (gameCart.Game.Price * gameCart.Quantity).ToString("C"),
                Image = gameCart.Game.Image
            }).ToList();

            IEnumerable<EventCartItemsViewModel> eventCartItemsViewModels = activeEventCarts.Select(eventCart => new EventCartItemsViewModel
            {
                Id = eventCart.EventId.ToString(),
                Topic = eventCart.Event.Topic,
                TicketPrice = eventCart.Event.TicketPrice.ToString("C"),
                TicketQuantity = eventCart.TicketQuantity,
                AddedOn = eventCart.AddedOn.ToString(EventDateTimeFormat, CultureInfo.InvariantCulture),
                TotalPrice = (eventCart.Event.TicketPrice * eventCart.TicketQuantity).ToString("C"),
                Image = eventCart.Event.Image
            }).ToList();


            model.GameCartItems = gameCartItemsViewModels;
            model.EventCartItems = eventCartItemsViewModels;

            model.TotalPrice = cart.TotalPrice.ToString("C");

            return model;
        }

        /// <summary>
        /// Adds a game to the user's shopping cart.
        /// </summary>
        /// <param name="gameId">The unique ID of the game.</param>
        /// <param name="userId">The unique ID of the user.</param>
        /// <param name="game">The game object to add to the cart.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddGameToCartAsync(string gameId, string userId, Game game)
        {
            Cart cart = await GetOrCreateUserCart(userId);

            GameCart? gameItem = cart.GamesCarts.FirstOrDefault(gc => gc.GameId.ToString() == gameId);

            if (gameItem != null)
            {
                if (gameItem.IsDeleted == false)
                {
                    cart.TotalPrice += gameItem.Quantity * game.Price;
                    gameItem.Quantity++;
                }
                else
                {
                    gameItem.IsDeleted = false;
                    gameItem.Quantity = 1;
                    cart.TotalPrice += game.Price * gameItem.Quantity;
                }
            }
            else
            {
                gameItem = new GameCart()
                {
                    Game = game,
                    Cart = cart,
                    Quantity = 1,
                    IsDeleted = false,
                    AddedOn = DateTime.Now,
                };

                cart.TotalPrice += game.Price * gameItem.Quantity;
                cart.GamesCarts.Add(gameItem);
            }

            //cart.TotalPrice += game.Price * gameItem.Quantity;

            await _cartRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Adds an event to the user's shopping cart.
        /// </summary>
        /// <param name="eventId">The unique ID of the event.</param>
        /// <param name="userId">The unique ID of the user.</param>
        /// <param name="e">The event object to add to the cart.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddEventToCartAsync(string eventId, string userId, Event e)
        {
            Cart cart = await GetOrCreateUserCart(userId);

            EventCart? eventItem = cart.EventsCarts.FirstOrDefault(gc => gc.EventId.ToString() == eventId);

            if (eventItem != null)
            {
                if (eventItem.IsDeleted == false)
                {
                    cart.TotalPrice += eventItem.TicketQuantity * e.TicketPrice;
                    eventItem.TicketQuantity++;
                }
                else
                {
                    eventItem.IsDeleted = false;
                    eventItem.TicketQuantity = 1;
                    cart.TotalPrice += eventItem.TicketQuantity * e.TicketPrice;
                }
            }
            else
            {
                eventItem = new EventCart()
                {
                    Event = e,
                    TicketQuantity = 1,
                    IsDeleted = false,
                    AddedOn = DateTime.Now
                };

                cart.TotalPrice += eventItem.TicketQuantity * e.TicketPrice;

                cart.EventsCarts.Add(eventItem);
            }

            await _cartRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Removes a game from the user's shopping cart.
        /// </summary>
        /// <param name="gameId">The unique ID of the game to remove.</param>
        /// <param name="userId">The unique ID of the user.</param>
        /// <param name="gamePrice">The price of the game being removed.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task RemoveGameFromCartAsync(string gameId, string userId, decimal gamePrice)
        {
            Cart cart = await GetOrCreateUserCart(userId);

            GameCart? gameItem = cart.GamesCarts.FirstOrDefault(gc => gc.GameId.ToString() == gameId && gc.IsDeleted == false);

            //gameItem.Quantity--;

            //cart.TotalPrice -= gamePrice;

            //if (gameItem.Quantity < 1)
            //{
            //    gameItem.IsDeleted = true;
            //}

            if (gameItem != null)
            {
                gameItem.IsDeleted = true;
                cart.TotalPrice -= gamePrice;
                await _cartRepository.SaveChangesAsync();
            }

            //await _cartRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Removes an event from the user's shopping cart.
        /// </summary>
        /// <param name="eventId">The unique ID of the event to remove.</param>
        /// <param name="userId">The unique ID of the user.</param>
        /// <param name="eventTicketPrice">The price of the event ticket being removed.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task RemoveEventFromCartAsync(string eventId, string userId, decimal eventTicketPrice)
        {
            Cart cart = await GetOrCreateUserCart(userId);

            EventCart? eventItem = cart.EventsCarts.FirstOrDefault(gc => gc.EventId.ToString() == eventId && gc.IsDeleted == false);

            //eventItem.TicketQuantity--;

            //cart.TotalPrice -= eventTicketPrice;

            //if (eventItem.TicketQuantity < 1)
            //{
            //    eventItem.IsDeleted = true;
            //}

            if (eventItem != null)
            {
                eventItem.IsDeleted = true;
                cart.TotalPrice -= eventTicketPrice;
                await _cartRepository.SaveChangesAsync();
            }

            //await _cartRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Retrieves the user's shopping cart or creates a new one if it does not exist.
        /// </summary>
        /// <param name="userId">The unique ID of the user.</param>
        /// <returns>A task containing the <see cref="Cart"/> object for the user.</returns>
        public async Task<Cart> GetOrCreateUserCart(string userId)
        {
            Cart? cart = await _cartRepository
                .GetAllAttached()
                .Include(c => c.GamesCarts)
                .ThenInclude(gc => gc.Game )
                .Include(c => c.EventsCarts)
                .ThenInclude(ec => ec.Event)
                .FirstOrDefaultAsync(c => c.UserId.ToString() == userId);

            if (cart == null)
            {
                cart = new Cart
                {
                    UserId = Guid.Parse(userId),
                    TotalPrice = 0,
                    GamesCarts = new HashSet<GameCart>(),
                    EventsCarts = new HashSet<EventCart>()
                };

                await _cartRepository.AddAsync(cart);
                await _cartRepository.SaveChangesAsync();
            }

            return cart;
        }

        /// <summary>
        /// Checks if a specific game exists in the user's shopping cart.
        /// </summary>
        /// <param name="gameId">The unique ID of the game.</param>
        /// <param name="userId">The unique ID of the user.</param>
        /// <returns>
        /// A task containing <c>true</c> if the game exists in the shopping cart; otherwise, <c>false</c>.
        /// </returns>
        public async Task<bool> GameItemExistInTheShoppingCart(string gameId, string userId)
        {
            Cart cart = await GetOrCreateUserCart(userId);

            GameCart? gameItem = cart.GamesCarts.FirstOrDefault(gc => gc.GameId.ToString() == gameId && gc.IsDeleted == false);

            if (gameItem != null)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if a specific event exists in the user's shopping cart.
        /// </summary>
        /// <param name="eventId">The unique ID of the event.</param>
        /// <param name="userId">The unique ID of the user.</param>
        /// <returns>
        /// A task containing <c>true</c> if the event exists in the shopping cart; otherwise, <c>false</c>.
        /// </returns>
        public async Task<bool> EventItemExistInTheShoppingCart(string eventId, string userId)
        {
            Cart cart = await GetOrCreateUserCart(userId);

            EventCart? eventItem = cart.EventsCarts.FirstOrDefault(ec => ec.EventId.ToString() == eventId && ec.IsDeleted == false);

            if (eventItem != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Purchases all items in the user's shopping cart.
        /// </summary>
        /// <param name="userId">The unique ID of the user.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the shopping cart is empty or an item cannot be purchased due to insufficient stock or seats.
        /// </exception>

        public async Task PurchaseItemsInShoppingCart(string userId)
        {
            Cart? cart = await GetOrCreateUserCart(userId);

            IEnumerable<GameCart> gameCartItems = cart.GamesCarts.Where(gc => !gc.IsDeleted).ToList();

            IEnumerable<EventCart> eventCartItems = cart.EventsCarts.Where(ec => !ec.IsDeleted).ToList();

            if (!gameCartItems.Any() && !eventCartItems.Any())
            {
                throw new InvalidOperationException("Your shopping cart is empty");
            }

            if (gameCartItems.Any())
            {
                foreach (var gameCartItem in gameCartItems)
                {
                    Game? game = await _gameRepository.FirstOrDefaultAsync(g =>
                        g.Id == gameCartItem.GameId && g.IsDeleted == false);

                    if (game == null || game.QuantityInStock < gameCartItem.Quantity || game.QuantityInStock == 0)
                    {
                        throw new InvalidOperationException("Not enough quantity in stock for game: " + gameCartItem.Game.Title);
                    }

                    UserBoughtGame? alreadyBoughtGameByUser =
                        await _userBoughtGamesRepository.FirstOrDefaultAsync(g =>
                            g.UserId.ToString() == userId && g.GameId == game.Id);

                    if (alreadyBoughtGameByUser == null)
                    {
                        //Decrease game quantity in stock. 
                        game.QuantityInStock -= gameCartItem.Quantity;


                        UserBoughtGame userBoughtGame = new UserBoughtGame()
                        {
                            UserId = Guid.Parse(userId),
                            GameId = gameCartItem.GameId,
                            BoughtOn = DateTime.Now,
                            Quantity = gameCartItem.Quantity
                        };

                        await _userBoughtGamesRepository.AddAsync(userBoughtGame);
                    }
                    else
                    {
                        alreadyBoughtGameByUser.Quantity = gameCartItem.Quantity;
                        alreadyBoughtGameByUser.BoughtOn = DateTime.Now;

                        game.QuantityInStock -= gameCartItem.Quantity;
                    }

                    await _userBoughtGamesRepository.SaveChangesAsync();
                    await _gameRepository.SaveChangesAsync();
                    await ClearCart(cart);
                }
            }

            if (eventCartItems.Any())
            {
                foreach (var eventCartItem in eventCartItems)
                {
                    Event? e = await _eventRepository.FirstOrDefaultAsync(e =>
                        e.Id == eventCartItem.EventId && e.IsDeleted == false);

                    if (e == null || e.Seats < eventCartItem.TicketQuantity || e.Seats == 0)
                    {
                        throw new InvalidOperationException("Not enough empty seats for event: " + eventCartItem.Event.Topic);
                    }

                    string qrCodeData = $"EventId:{e.Id.ToString()};UserId:{userId};Date:{DateTime.Now}";
                    string qrCodeAsBase64String = _qrCodeService.GenerateQrCode(qrCodeData);

                    EventRegistration? existingEventRegistration = await _eventRegistrationRepository.FirstOrDefaultAsync(er =>
                        er.UserId == Guid.Parse(userId) && er.EventId == eventCartItem.EventId);

                    if (existingEventRegistration == null)
                    {
                        //Decrease the number of seats
                        e.Seats -= eventCartItem.TicketQuantity;

                        EventRegistration eventRegistration = new EventRegistration()
                        {
                            UserId = Guid.Parse(userId),
                            EventId = eventCartItem.EventId,
                            RegistrationDate = DateTime.Now,
                            TicketQuantity = eventCartItem.TicketQuantity,
                            QrCode = qrCodeAsBase64String
                        };

                        await _eventRegistrationRepository.AddAsync(eventRegistration);
                    }
                    else
                    {
                        existingEventRegistration.TicketQuantity = eventCartItem.TicketQuantity;
                        existingEventRegistration.RegistrationDate = DateTime.Now;
                        existingEventRegistration.QrCode = qrCodeAsBase64String;
                        e.Seats -= eventCartItem.TicketQuantity;
                    }

                    
                    await _eventRegistrationRepository.SaveChangesAsync();
                    await _eventRepository.SaveChangesAsync();
                    await ClearCart(cart);
                }
            }
        }

        /// <summary>
        /// Clears all items from the specified shopping cart.
        /// </summary>
        /// <param name="cart">The shopping cart to clear.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task ClearCart(Cart cart)
        {
            if (cart.EventsCarts.Any())
            {
                foreach (var eventItem in cart.EventsCarts.Where(e => e.IsDeleted == false))
                {
                    eventItem.IsDeleted = true;
                }
            }

            if (cart.GamesCarts.Any())
            {
                foreach (var gameItem in cart.GamesCarts.Where(g => g.IsDeleted == false))
                {
                    gameItem.IsDeleted = true;
                }
            }

            cart.TotalPrice = 0;

            await _cartRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Increases the quantity of a specific game for a user.
        /// </summary>
        /// <param name="gameId">The unique identifier of the game.</param>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task IncreaseGameQuantityAsync(string gameId, string userId)
        {
            Cart cart = await GetOrCreateUserCart(userId);

            GameCart? gameItem = cart.GamesCarts.FirstOrDefault(gc => gc.GameId.ToString() == gameId && gc.IsDeleted == false);

            if (gameItem != null)
            {
                gameItem.Quantity++;
                cart.TotalPrice += gameItem.Game.Price;
                await _cartRepository.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Decreases the quantity of a specific game for a user.
        /// </summary>
        /// <param name="gameId">The unique identifier of the game.</param>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task DecreaseGameQuantityAsync(string gameId, string userId)
        {
            Cart cart = await GetOrCreateUserCart(userId);

            GameCart? gameItem = cart.GamesCarts.FirstOrDefault(gc => gc.GameId.ToString() == gameId);

            if (gameItem != null && !gameItem.IsDeleted)
            {
                if (gameItem.Quantity > 1)
                {
                    gameItem.Quantity--;
                    cart.TotalPrice -= gameItem.Game.Price;
                }
                else
                {
                    gameItem.IsDeleted = true;
                    cart.TotalPrice -= gameItem.Game.Price;
                }

                await _cartRepository.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Increases the quantity of a specific event item for a user.
        /// </summary>
        /// <param name="eventId">The unique identifier of the event item.</param>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task IncreaseEventItemQuantity(string eventId, string userId)
        {
            Cart cart = await GetOrCreateUserCart(userId);

            EventCart? eventItem = cart.EventsCarts.FirstOrDefault(gc => gc.EventId.ToString() == eventId && gc.IsDeleted == false);

            if (eventItem != null)
            {
                eventItem.TicketQuantity++;
                cart.TotalPrice += eventItem.Event.TicketPrice;
                await _cartRepository.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Decreases the quantity of a specific event item for a user.
        /// </summary>
        /// <param name="eventId">The unique identifier of the event item.</param>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task DecreaseEventItemQuantityAsync(string eventId, string userId)
        {
            Cart cart = await GetOrCreateUserCart(userId);

            EventCart? eventItem = cart.EventsCarts.FirstOrDefault(gc => gc.EventId.ToString() == eventId);

            if (eventItem != null && eventItem.IsDeleted == false)
            {
                if (eventItem.TicketQuantity > 1)
                {
                    eventItem.TicketQuantity--;
                    cart.TotalPrice -= eventItem.Event.TicketPrice;
                }
                else
                {
                    eventItem.IsDeleted = true;
                    cart.TotalPrice -= eventItem.Event.TicketPrice;
                }

                await _cartRepository.SaveChangesAsync();
            }
        }
    }
}
