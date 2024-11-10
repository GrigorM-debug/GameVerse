using GameVerse.Data.Models.Carts;
using GameVerse.Data.Models.Events;
using GameVerse.Data.Models.Games;
using GameVerse.Data.Repositories.Interfaces;
using GameVerse.Web.Extensions;
using GameVerse.Web.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameVerse.Web.Controllers
{
    [Authorize]
    public class CartController(IGenericRepository<Cart, Guid> cartRepository, IGenericRepository<Game, Guid> gameRespository, IGenericRepository<Event, Guid> eventRepository, IGenericRepository<EventRegistration, object> eventRegistrationRepository, IGenericRepository<UserBoughtGame, object> userBoughtGamesRepository) : BaseController
    {
        private readonly IGenericRepository<Cart, Guid> _cartRepository = cartRepository;
        private readonly IGenericRepository<Game, Guid> _gameRepository = gameRespository;
        private readonly IGenericRepository<Event, Guid> _eventRepository = eventRepository;
        private readonly IGenericRepository<EventRegistration, object> _eventRegistrationRepository = eventRegistrationRepository;
        private readonly IGenericRepository<UserBoughtGame, object> _userBoughtGamesRepository = userBoughtGamesRepository;

        //[HttpGet]
        //[NotModerator]
        //public async Task<IActionResult> Index()
        //{
        //    string userId = User.GetId();

        //    if (userId == null)
        //    {
        //        return Unauthorized();
        //    }

        //    var cart = await _cartRepository
        //        .GetWithIncludeAsync(
        //        c => c.GamesCarts.Where(gc => gc.IsDeleted == false),
        //        c => c.EventsCarts.Where(ec => ec.IsDeleted == false))
        //        .AsNoTracking()
        //        .FirstOrDefaultAsync(c => c.UserId.ToString() == userId);


        //    return View();
        //}

        //[HttpPost]
        //[NotModerator]
        //public async Task<IActionResult> AddGameToCart(string gameId, string userId)
        //{
        //    var game = await _gameRepository.AllAsReadOnly().FirstOrDefaultAsync(g => g.Id.ToString() == gameId && g.IsDeleted == false);

        //    if (game == null)
        //    {
        //        //Add toaster message and redirect to 404 page
        //    }

        //    var cart = await _cartRepository
        //        .GetWithIncludeAsync(c => c.GamesCarts.Where(gc => gc.IsDeleted == false))
        //        .FirstOrDefaultAsync(c => c.UserId.ToString() == userId);

        //    var gameItem = cart.GamesCarts.FirstOrDefault(gc => gc.GameId.ToString() == gameId);

        //    if (gameItem != null)
        //    {
        //        if(gameItem.IsDeleted == false)
        //        {
        //            gameItem.Quantity++;
        //        }
        //        else
        //        {
        //            gameItem.IsDeleted = false;
        //            gameItem.Quantity = 1;
        //        }
        //    }
        //    else
        //    {
        //        gameItem = new GameCart()
        //        {
        //            Game = game,
        //            Quantity = 1,
        //            IsDeleted = false,
        //            AddedOn = DateTime.Now,
        //        };

        //        cart.GamesCarts.Add(gameItem);
        //    }

        //    await _cartRepository.SaveChangesAsync();

        //    return RedirectToAction(nameof(Index));
        //}

        //public async Task<IActionResult> AddEventToCart(string eventId, string userId)
        //{
        //    var e = await _eventRepository.AllAsReadOnly().FirstOrDefaultAsync(e => e.Id.ToString() == eventId && e.IsDeleted == false);

        //    if(e == null)
        //    {
        //        //add toaster message and redirect to 404 page
        //    }

        //    var cart = await _cartRepository
        //        .GetWithIncludeAsync(c => c.EventsCarts.Where(gc => gc.IsDeleted == false))
        //        .FirstOrDefaultAsync(c => c.UserId.ToString() == userId);

        //    var eventItem = cart.EventsCarts.FirstOrDefault(gc => gc.EventId.ToString() == eventId);

        //    if (eventItem != null)
        //    {
        //        if (eventItem.IsDeleted == false)
        //        {
        //            eventItem.TicketQuantity++;
        //        }
        //        else
        //        {
        //            eventItem.IsDeleted = false;
        //            eventItem.TicketQuantity = 1;
        //        }
        //    }
        //    else
        //    {
        //        eventItem = new EventCart()
        //        {
        //            Event = e,
        //            TicketQuantity = 1,
        //            IsDeleted = false,
        //            AddedOn = DateTime.Now
        //        };

        //        cart.EventsCarts.Add(eventItem);
        //    }

        //    await _cartRepository.SaveChangesAsync();

        //    return RedirectToAction(nameof(Index));
        //}

        //[HttpPost]
        //[NotModerator]
        //public async Task<IActionResult> Purchase()
        //{
        //    string userId = User.GetId();

        //    if(userId == null)
        //    {
        //        return Unauthorized();
        //    }

        //    var cart = await _cartRepository
        //        .GetWithIncludeAsync(c => c.GamesCarts.Where(gc => gc.IsDeleted == false), c=> c.EventsCarts.Where(ec => ec.IsDeleted == false))
        //        .FirstOrDefaultAsync(c => c.UserId.ToString() == userId);

        //    var gameItems = cart.GamesCarts.ToList();
        //    var eventItems = cart.EventsCarts.ToList();

        //    if(eventItems != null)
        //    {
        //        foreach(var eventItem in eventItems)
        //        {
        //            var eventRegistration = new EventRegistration()
        //            {
        //                UserId = Guid.Parse(userId),
        //                EventId = eventItem.EventId,
        //                RegistrationDate = DateTime.Now,
        //            };

        //            await _eventRegistrationRepository.AddAsync(eventRegistration); 
        //        }
        //        await _eventRegistrationRepository.SaveChangesAsync();
        //    }

        //    if(gameItems != null)
        //    {
        //        foreach(var gameItem in gameItems)
        //        {
        //            var userBoughtGame = new UserBoughtGame()
        //            {
        //                UserId= Guid.Parse(userId),
        //                GameId = gameItem.GameId,
        //                BoughtOn = DateTime.Now,
        //            };

        //            await _userBoughtGamesRepository.AddAsync(userBoughtGame);
        //        }

        //        await _userBoughtGamesRepository.SaveChangesAsync();
        //    }

        //    //For example redirect to Home Page and add Toaster message
        //}
    }
}
