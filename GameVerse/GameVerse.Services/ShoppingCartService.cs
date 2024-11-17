

using GameVerse.Data.Models.Carts;
using GameVerse.Data.Models.Events;
using GameVerse.Data.Models.Games;
using GameVerse.Data.Repositories.Interfaces;
using GameVerse.Services.Interfaces;
using GameVerse.Web.ViewModels.ShoppingCart;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using static GameVerse.Common.ApplicationConstants.EventConstants;

namespace GameVerse.Services
{
    public class ShoppingCartService(
        IGenericRepository<Cart, Guid> cartRepository,
        IGenericRepository<Game, Guid> gameRespository,
        IGenericRepository<Event, Guid> eventRepository,
        IGenericRepository<EventRegistration, object> eventRegistrationRepository,
        IGenericRepository<UserBoughtGame, object> userBoughtGamesRepository
        ) : BaseService, IShoppingCartService
    {

        private readonly IGenericRepository<Cart, Guid> _cartRepository = cartRepository;
        private readonly IGenericRepository<Game, Guid> _gameRepository = gameRespository;
        private readonly IGenericRepository<Event, Guid> _eventRepository = eventRepository;
        private readonly IGenericRepository<EventRegistration, object> _eventRegistrationRepository = eventRegistrationRepository;
        private readonly IGenericRepository<UserBoughtGame, object> _userBoughtGamesRepository = userBoughtGamesRepository;

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

        public async Task AddGameToCartAsync(string gameId, string userId, Game game)
        {
            Cart cart = await GetOrCreateUserCart(userId);

            GameCart? gameItem = cart.GamesCarts.FirstOrDefault(gc => gc.GameId.ToString() == gameId);

            if (gameItem != null)
            {
                if (gameItem.IsDeleted == false)
                {
                    cart.TotalPrice -= gameItem.Quantity * game.Price;
                    gameItem.Quantity++;
                }
                else
                {
                    gameItem.IsDeleted = false;
                    gameItem.Quantity = 1;
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

                cart.GamesCarts.Add(gameItem);
            }

            cart.TotalPrice += game.Price * gameItem.Quantity;

            await _cartRepository.SaveChangesAsync();
        }

        public async Task AddEventToCartAsync(string eventId, string userId, Event e)
        {
            Cart cart = await GetOrCreateUserCart(userId);

            EventCart? eventItem = cart.EventsCarts.FirstOrDefault(gc => gc.EventId.ToString() == eventId);

            if (eventItem != null)
            {
                if (eventItem.IsDeleted == false)
                {
                    cart.TotalPrice -= eventItem.TicketQuantity * e.TicketPrice;
                    eventItem.TicketQuantity++;
                }
                else
                {
                    eventItem.IsDeleted = false;
                    eventItem.TicketQuantity = 1;
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

                cart.EventsCarts.Add(eventItem);
            }

            cart.TotalPrice += eventItem.TicketQuantity * e.TicketPrice;

            await _cartRepository.SaveChangesAsync();
        }

        public async Task RemoveGameFromCartAsync(string gameId, string userId, decimal gamePrice)
        {
            Cart cart = await GetOrCreateUserCart(userId);

            GameCart? gameItem = cart.GamesCarts.FirstOrDefault(gc => gc.GameId.ToString() == gameId && gc.IsDeleted == false);


            gameItem.IsDeleted = true;

            cart.TotalPrice -= gameItem.Quantity * gamePrice;

            await _cartRepository.SaveChangesAsync();
        }

        public async Task RemoveEventFromCartAsync(string eventId, string userId, decimal eventTicketPrice)
        {
            Cart cart = await GetOrCreateUserCart(userId);

            EventCart? eventItem = cart.EventsCarts.FirstOrDefault(gc => gc.EventId.ToString() == eventId && gc.IsDeleted == false);

            eventItem.IsDeleted = true;

            cart.TotalPrice -= eventItem.TicketQuantity * eventTicketPrice;

            await _cartRepository.SaveChangesAsync();
        }

        public async Task<Cart> GetOrCreateUserCart(string userId)
        {
            Cart? cart = await _cartRepository
                .GetAllAttached()
                .Include(c => c.GamesCarts)
                .ThenInclude(gc => gc.Game)
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
    }
}
