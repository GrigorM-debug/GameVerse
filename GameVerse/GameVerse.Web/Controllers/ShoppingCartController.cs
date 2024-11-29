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
    [Authorize]
    [OnlyUsersWithoutRoles]
    public class ShoppingCartController(
        INotyfService notyf, 
        IGameService gameService,
        IEventService eventService,
        IShoppingCartService shoppingCartService
        ) : BaseController
    {
        private readonly INotyfService _notyf = notyf;
        private readonly IShoppingCartService _shoppingCartService = shoppingCartService;
        private readonly IGameService _gameService = gameService;
        private readonly IEventService _eventService = eventService;

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
                await _shoppingCartService.PurchaseItemsInShoppingCart(userId);

                Log.Information("User with {UserId} made an {Action} in {Controller}", userId, nameof(PurchaseItemsInShoppingCart), nameof(ShoppingCartController));

                _notyf.Success("Items successfully purchased. You can see them in Bought Games and Event Registrations Pages");

                return RedirectToAction("Index", "ShoppingCart", new {area=""});
            }
            catch (InvalidOperationException ex)
            {
                _notyf.Error(ex.Message);
                Log.Error("An error occur in {Action} from {Controller} with {Message}", nameof(PurchaseItemsInShoppingCart), nameof(ShoppingCartController), ex.Message);

                return RedirectToAction("Index", "ShoppingCart", new {area = ""});
            }
        }

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
    }
}
