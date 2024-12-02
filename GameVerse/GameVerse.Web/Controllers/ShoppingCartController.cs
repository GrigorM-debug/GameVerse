using System.Globalization;
using AspNetCoreHero.ToastNotification.Abstractions;
using GameVerse.Data.Models.Carts;
using GameVerse.Data.Models.Events;
using GameVerse.Data.Models.Games;
using GameVerse.Data.Repositories.Interfaces;
using GameVerse.Services.Interfaces;
using GameVerse.Web.Extensions;
using GameVerse.Web.Filters;
using GameVerse.Web.ViewModels.ShoppingCart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using static GameVerse.Common.ApplicationConstants.EventConstants;

namespace GameVerse.Web.Controllers
{
    /// <summary>
    /// Handles operations related to the shopping cart, including adding, removing, and managing items.
    /// </summary>
    [Authorize]
    [OnlyUsersWithoutRoles]
    public class ShoppingCartController(
        INotyfService _notyf, 
        IGameService _gameService,
        IEventService _eventService,
        IShoppingCartService _shoppingCartService
        ) : BaseController
    {
        /// <summary>
        /// Displays the items in the user's shopping cart.
        /// </summary>
        /// <returns>The shopping cart view.</returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string? userId = User.GetId();

            if (userId == null)
            {
                _notyf.Warning("You don't have the permission to do this");
                return Unauthorized();
            }

            ShoppingCartViewModel model = await _shoppingCartService.GetShoppingCartItemsAsync(userId);

            return View(model);
        }

        /// <summary>
        /// Adds a game to the user's shopping cart.
        /// </summary>
        /// <param name="gameId">The unique identifier of the game.</param>
        /// <returns>Redirects to the shopping cart or appropriate error response.</returns>
        [HttpPost]
        public async Task<IActionResult> AddGameToCart(string gameId)
        {
            string? userId = User.GetId();

            if (userId == null)
            {
                _notyf.Warning("You don't have the permission to do this");
                return Unauthorized();
            }

            Game? game = await _gameService.GetGameByIdAsync(gameId);

            if (game == null)
            {
                _notyf.Error("Game doesn't exist");
                return NotFound();
            }

            if (game.QuantityInStock == 0)
            {
                _notyf.Error("This game is currently out of stock");
                return RedirectToAction("Details", "GameStore", new { id = gameId, area = "" });
            }

            await _shoppingCartService.AddGameToCartAsync(gameId, userId, game);

            _notyf.Success("Game added successfully in the Shopping Cart");

            Log.Information("User with ID {UserId} made {Action} in {Controller}", userId, nameof(AddGameToCart), nameof(ShoppingCartController));

            return RedirectToAction("Index", "ShoppingCart", new { area = "" });
        }

        /// <summary>
        /// Adds an event ticket to the user's shopping cart.
        /// </summary>
        /// <param name="eventId">The unique identifier of the event.</param>
        /// <returns>Redirects to the shopping cart or appropriate error response.</returns>
        [HttpPost]
        public async Task<IActionResult> AddEventToCart(string eventId)
        {
            string? userId = User.GetId();

            if (userId == null)
            {
                _notyf.Warning("You don't have the permission to do this");
                return Unauthorized();
            }

            Event? e = await _eventService.GetEventByIdAsync(eventId);

            if (e == null)
            {
                _notyf.Error("Event doesn't exist");
                return NotFound();
            }

            if (e.Seats == 0)
            {
                _notyf.Error("No available tickets for the Event");
                return RedirectToAction("Details", "Event", new { id = eventId, area = "" });
            }

            await _shoppingCartService.AddEventToCartAsync(eventId, userId, e);

            _notyf.Success("Event ticket added successfully in the Shopping Cart");

            Log.Information("User with ID {UserId} made {Action} in {Controller}", userId, nameof(AddEventToCart), nameof(ShoppingCartController));

            return RedirectToAction("Index", "ShoppingCart", new{ area = "" });
        }

        /// <summary>
        /// Removes a game from the user's shopping cart.
        /// </summary>
        /// <param name="gameId">The unique identifier of the game.</param>
        /// <returns>Redirects to the game details or shopping cart view.</returns>
        [HttpPost]
        public async Task<IActionResult> RemoveGameFromCart(string gameId)
        {
            string? userId = User.GetId();

            if (userId == null)
            {
                _notyf.Warning("You don't have the permission to do this");
                return Unauthorized();
            }

            Game? game = await _gameService.GetGameByIdAsync(gameId);

            if (game == null)
            {
                _notyf.Error("Game doesn't exist");
                return NotFound();
            }

            bool gameItemExistInTheShoppingCart =
                await _shoppingCartService.GameItemExistInTheShoppingCart(gameId, userId);

            if (!gameItemExistInTheShoppingCart)
            {
                _notyf.Error("Item doesn't exist in your shopping cart");
                return RedirectToAction("Index", "ShoppingCart", new { area = "" });
            }

            await _shoppingCartService.RemoveGameFromCartAsync(gameId, userId, game.Price);

            _notyf.Success("Game successfully removed from Shopping Cart");

            Log.Information("User with ID {UserId} perform {Action} in {Controller}", userId, nameof(RemoveGameFromCart), nameof(ShoppingCartController));

            return RedirectToAction("Details", "GameStore", new{id = gameId, area = "" });
        }

        /// <summary>
        /// Removes a game from the user's shopping cart.
        /// </summary>
        /// <param name="gameId">The unique identifier of the game.</param>
        /// <returns>Redirects to the game details or shopping cart view.</returns>
        [HttpPost]
        public async Task<IActionResult> RemoveEventFromCart(string eventId)
        {
            string? userId = User.GetId();

            if (userId == null)
            {
                _notyf.Warning("You don't have the permission to do this");
                return Unauthorized();
            }

            Event? e = await _eventService.GetEventByIdAsync(eventId);

            if (e == null)
            {
                _notyf.Error("Event doesn't exist");
                return NotFound();
            }

            bool isEventItemExistInTheShoppingCart =
                await _shoppingCartService.EventItemExistInTheShoppingCart(eventId, userId);

            if (!isEventItemExistInTheShoppingCart)
            {
                _notyf.Error("Item doesn't exist in your shopping cart");
                return RedirectToAction("Index", "ShoppingCart", new { area = "" });
            }

            await _shoppingCartService.RemoveEventFromCartAsync(eventId, userId, e.TicketPrice);

            _notyf.Success("Event ticket successfully removed from Shopping Cart");

            Log.Information("User with ID {UserId} perform {Action} in {Controller}", userId, nameof(RemoveEventFromCart), nameof(ShoppingCartController));

            return RedirectToAction("Details", "Event", new {id = eventId, area=""});
        }

        /// <summary>
        /// Purchases all items in the user's shopping cart.
        /// </summary>
        /// <returns>Redirects to the shopping cart view or appropriate error response.</returns>
        [HttpPost]
        public async Task<IActionResult> PurchaseItemsInShoppingCart()
        {
            string? userId = User.GetId();

            if (userId == null)
            {
                _notyf.Error("You don't have the permission to do this");
                return Unauthorized();
            }

            try
            {
                Cart userCart = await _shoppingCartService.GetOrCreateUserCart(userId);

                var hasEvents = userCart.EventsCarts.Any();
                var hasGames = userCart.GamesCarts.Any();

                var eventIds = string.Join(", ", userCart.EventsCarts.Where(ec => ec.IsDeleted == false).Select(ec => ec.EventId));
                var gameIds = string.Join(", ", userCart.GamesCarts.Where(gc => gc.IsDeleted == false).Select(gc => gc.GameId));

                await _shoppingCartService.PurchaseItemsInShoppingCart(userId);

                //Log.Information("User with {UserId} made an {Action} in {Controller}", userId, nameof(PurchaseItemsInShoppingCart), nameof(ShoppingCartController));

                if (hasEvents && !hasGames)
                {
                    _notyf.Success("Items successfully purchased. You can see them in Events Registrations Page");
                    Log.Information("User with Id: {UserId} bought ticket/s for Event/s with Ids {EventIds}", userId, eventIds);
                }
                else if (!hasEvents && hasGames)
                {
                    _notyf.Success("Items successfully purchased. You can see them in Bought Games Page");
                    Log.Information("User with Id: {UserId} bought game/s with Ids: {GameIds}", userId, gameIds);
                }
                else
                {
                    Log.Information("User with {UserId} made an {Action} in {Controller}. Items purchased Ids: {EventIds}, {GameIds}", userId, nameof(PurchaseItemsInShoppingCart), nameof(ShoppingCartController), eventIds, gameIds);
                    _notyf.Success("Items successfully purchased. You can see them in Bought Games and Event Registrations Pages");
                }

                //_notyf.Success("Items successfully purchased. You can see them in Bought Games and Event Registrations Pages");

                return RedirectToAction("Index", "ShoppingCart", new {area=""});
            }
            catch (InvalidOperationException ex)
            {
                _notyf.Error(ex.Message);
                Log.Error("An error occur in {Action} from {Controller} with {Message}", nameof(PurchaseItemsInShoppingCart), nameof(ShoppingCartController), ex.Message);

                return RedirectToAction("Index", "ShoppingCart", new {area = ""});
            }
        }

        /// <summary>
        /// Increases the quantity of a specific game item in the user's shopping cart.
        /// </summary>
        /// <param name="gameId">The unique identifier of the game.</param>
        /// <returns>Redirects to the shopping cart view or an appropriate error response.</returns>
        [HttpPost]
        public async Task<IActionResult> IncreaseGameItemQuantity(string gameId)
        {
            string? userId = User.GetId();

            if (userId == null)
            {
                _notyf.Warning("You don't have the permission to do this");
                return Unauthorized();
            }

            Game? game = await _gameService.GetGameByIdAsync(gameId);

            if (game == null)
            {
                _notyf.Error("Game doesn't exist");
                return NotFound();
            }

            bool gameItemExistInTheShoppingCart =
                await _shoppingCartService.GameItemExistInTheShoppingCart(gameId, userId);

            if (!gameItemExistInTheShoppingCart)
            {
                _notyf.Error("Item doesn't exist in your shopping cart");
                return RedirectToAction("Index", "ShoppingCart", new { area = "" });
            }

            await _shoppingCartService.IncreaseGameQuantityAsync(gameId, userId);

            _notyf.Success("Game quantity increased successfully");

            Log.Information("User with ID {UserId} perform {Action} in {Controller}", userId, nameof(IncreaseGameItemQuantity), nameof(ShoppingCartController));

            return RedirectToAction("Index", "ShoppingCart", new { area = "" });
        }

        /// <summary>
        /// Decreases the quantity of a specific game item in the user's shopping cart.
        /// </summary>
        /// <param name="gameId">The unique identifier of the game.</param>
        /// <returns>Redirects to the shopping cart view or an appropriate error response.</returns>

        [HttpPost]
        public async Task<IActionResult> DecreaseGameItemQuantity(string gameId)
        {
            string? userId = User.GetId();

            if (userId == null)
            {
                _notyf.Warning("You don't have the permission to do this");
                return Unauthorized();
            }

            Game? game = await _gameService.GetGameByIdAsync(gameId);

            if (game == null)
            {
                _notyf.Error("Game doesn't exist");
                return NotFound();
            }

            bool gameItemExistInTheShoppingCart =
                await _shoppingCartService.GameItemExistInTheShoppingCart(gameId, userId);

            if (!gameItemExistInTheShoppingCart)
            {
                _notyf.Error("Item doesn't exist in your shopping cart");
                return RedirectToAction("Index", "ShoppingCart", new { area = "" });
            }

            await _shoppingCartService.DecreaseGameQuantityAsync(gameId, userId);

            _notyf.Success("Game quantity decreased successfully");

            Log.Information("User with ID {UserId} perform {Action} in {Controller}", userId, nameof(DecreaseGameItemQuantity), nameof(ShoppingCartController));

            return RedirectToAction("Index", "ShoppingCart", new { area = "" });
        }

        /// <summary>
        /// Increases the quantity of a specific event ticket in the user's shopping cart.
        /// </summary>
        /// <param name="eventId">The unique identifier of the event.</param>
        /// <returns>Redirects to the shopping cart view or an appropriate error response.</returns>
        [HttpPost]
        public async Task<IActionResult> IncreaseEventItemQuantity(string eventId)
        {
            string? userId = User.GetId();

            if (userId == null)
            {
                _notyf.Warning("You don't have the permission to do this");
                return Unauthorized();
            }

            Event? e = await _eventService.GetEventByIdAsync(eventId);

            if (e == null)
            {
                _notyf.Error("Event doesn't exist");
                return NotFound();
            }

            bool isEventItemExistInTheShoppingCart =
                await _shoppingCartService.EventItemExistInTheShoppingCart(eventId, userId);

            if (!isEventItemExistInTheShoppingCart)
            {
                _notyf.Error("Item doesn't exist in your shopping cart");
                return RedirectToAction("Index", "ShoppingCart", new { area = "" });
            }

            await _shoppingCartService.IncreaseEventItemQuantity(eventId, userId);

            _notyf.Success("Event ticket quantity successfully increased");

            Log.Information("User with ID {UserId} perform {Action} in {Controller}", userId, nameof(IncreaseEventItemQuantity), nameof(ShoppingCartController));

            return RedirectToAction("Index", "ShoppingCart", new { area = "" });
        }

        /// <summary>
        /// Decreases the quantity of a specific event ticket in the user's shopping cart.
        /// </summary>
        /// <param name="eventId">The unique identifier of the event.</param>
        /// <returns>Redirects to the shopping cart view or an appropriate error response.</returns>
        [HttpPost]
        public async Task<IActionResult> DecreaseEventItemQuantity(string eventId)
        {
            string? userId = User.GetId();

            if (userId == null)
            {
                _notyf.Warning("You don't have the permission to do this");
                return Unauthorized();
            }

            Event? e = await _eventService.GetEventByIdAsync(eventId);

            if (e == null)
            {
                _notyf.Error("Event doesn't exist");
                return NotFound();
            }

            bool isEventItemExistInTheShoppingCart =
                await _shoppingCartService.EventItemExistInTheShoppingCart(eventId, userId);

            if (!isEventItemExistInTheShoppingCart)
            {
                _notyf.Error("Item doesn't exist in your shopping cart");
                return RedirectToAction("Index", "ShoppingCart", new { area = "" });
            }

            await _shoppingCartService.DecreaseEventItemQuantityAsync(eventId, userId);

            _notyf.Success("Event ticket quantity successfully decreased");

            Log.Information("User with ID {UserId} perform {Action} in {Controller}", userId, nameof(DecreaseEventItemQuantity), nameof(ShoppingCartController));

            return RedirectToAction("Index", "ShoppingCart", new { area = "" });
        }
    }
}
