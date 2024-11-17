

using GameVerse.Data.Models.Carts;
using GameVerse.Data.Models.Events;
using GameVerse.Data.Models.Games;
using GameVerse.Web.ViewModels.ShoppingCart;

namespace GameVerse.Services.Interfaces
{
    public interface IShoppingCartService
    {
        Task<ShoppingCartViewModel> GetShoppingCartItemsAsync(string userId);

        Task AddGameToCartAsync(string gameId, string userId, Game game);

        Task AddEventToCartAsync(string eventId, string userId, Event e);

        Task RemoveGameFromCartAsync(string gameId, string userId, decimal gamePrice);

        Task RemoveEventFromCartAsync(string eventId, string userId, decimal eventTicketPrice);

        Task<Cart> GetOrCreateUserCart(string userId);

        Task<bool> GameItemExistInTheShoppingCart(string gameId, string userId);

        Task<bool> EventItemExistInTheShoppingCart(string eventId, string userId);
    }
}
