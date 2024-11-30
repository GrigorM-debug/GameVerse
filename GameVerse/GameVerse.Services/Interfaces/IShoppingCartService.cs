

using GameVerse.Data.Models.Carts;
using GameVerse.Data.Models.Events;
using GameVerse.Data.Models.Games;
using GameVerse.Web.ViewModels.ShoppingCart;

namespace GameVerse.Services.Interfaces
{
    /// <summary>
    /// Provides functionality for managing shopping cart operations, such as adding, removing, 
    /// and purchasing items from a user's shopping cart.
    /// </summary>
    public interface IShoppingCartService
    {
        /// <summary>
        /// Retrieves the items in the shopping cart for the specified user.
        /// </summary>
        /// <param name="userId">The unique ID of the user.</param>
        /// <returns>A task containing a <see cref="ShoppingCartViewModel"/> with the shopping cart items.</returns>
        Task<ShoppingCartViewModel> GetShoppingCartItemsAsync(string userId);

        /// <summary>
        /// Adds a game to the user's shopping cart.
        /// </summary>
        /// <param name="gameId">The unique ID of the game.</param>
        /// <param name="userId">The unique ID of the user.</param>
        /// <param name="game">The game object to add to the cart.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task AddGameToCartAsync(string gameId, string userId, Game game);

        /// <summary>
        /// Adds an event to the user's shopping cart.
        /// </summary>
        /// <param name="eventId">The unique ID of the event.</param>
        /// <param name="userId">The unique ID of the user.</param>
        /// <param name="e">The event object to add to the cart.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task AddEventToCartAsync(string eventId, string userId, Event e);

        /// <summary>
        /// Removes a game from the user's shopping cart.
        /// </summary>
        /// <param name="gameId">The unique ID of the game to remove.</param>
        /// <param name="userId">The unique ID of the user.</param>
        /// <param name="gamePrice">The price of the game being removed.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task RemoveGameFromCartAsync(string gameId, string userId, decimal gamePrice);

        /// <summary>
        /// Removes an event from the user's shopping cart.
        /// </summary>
        /// <param name="eventId">The unique ID of the event to remove.</param>
        /// <param name="userId">The unique ID of the user.</param>
        /// <param name="eventTicketPrice">The price of the event ticket being removed.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task RemoveEventFromCartAsync(string eventId, string userId, decimal eventTicketPrice);

        /// <summary>
        /// Retrieves the user's shopping cart or creates a new one if it does not exist.
        /// </summary>
        /// <param name="userId">The unique ID of the user.</param>
        /// <returns>A task containing the <see cref="Cart"/> object for the user.</returns>
        Task<Cart> GetOrCreateUserCart(string userId);

        /// <summary>
        /// Checks if a specific game is already in the user's shopping cart.
        /// </summary>
        /// <param name="gameId">The unique ID of the game.</param>
        /// <param name="userId">The unique ID of the user.</param>
        /// <returns>
        /// A task containing <c>true</c> if the game exists in the shopping cart; otherwise, <c>false</c>.
        /// </returns>
        Task<bool> GameItemExistInTheShoppingCart(string gameId, string userId);

        /// <summary>
        /// Checks if a specific event is already in the user's shopping cart.
        /// </summary>
        /// <param name="eventId">The unique ID of the event.</param>
        /// <param name="userId">The unique ID of the user.</param>
        /// <returns>
        /// A task containing <c>true</c> if the event exists in the shopping cart; otherwise, <c>false</c>.
        /// </returns>
        Task<bool> EventItemExistInTheShoppingCart(string eventId, string userId);

        /// <summary>
        /// Processes the purchase of all items in the user's shopping cart.
        /// </summary>
        /// <param name="userId">The unique ID of the user.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task PurchaseItemsInShoppingCart(string userId);

        /// <summary>
        /// Clears all items from the specified shopping cart.
        /// </summary>
        /// <param name="cart">The shopping cart to clear.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task ClearCart(Cart cart);

        /// <summary>
        /// Increases the quantity of a specific game for a user.
        /// </summary>
        /// <param name="gameId">The unique identifier of the game.</param>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task IncreaseGameQuantityAsync(string gameId, string userId);

        /// <summary>
        /// Decreases the quantity of a specific game for a user.
        /// </summary>
        /// <param name="gameId">The unique identifier of the game.</param>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task DecreaseGameQuantityAsync(string gameId, string userId);

        /// <summary>
        /// Increases the quantity of a specific event item for a user.
        /// </summary>
        /// <param name="eventId">The unique identifier of the event item.</param>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task IncreaseEventItemQuantity(string eventId, string userId);

        /// <summary>
        /// Decreases the quantity of a specific event item for a user.
        /// </summary>
        /// <param name="eventId">The unique identifier of the event item.</param>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task DecreaseEventItemQuantityAsync(string eventId, string userId);
    }
}
