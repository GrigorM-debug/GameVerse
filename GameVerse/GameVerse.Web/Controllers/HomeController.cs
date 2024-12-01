using AspNetCoreHero.ToastNotification.Abstractions;
using GameVerse.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using GameVerse.Services.Interfaces;
using GameVerse.Web.Extensions;
using GameVerse.Web.ViewModels;
using GameVerse.Web.ViewModels.Event;
using GameVerse.Web.ViewModels.Game;
using Serilog;

namespace GameVerse.Web.Controllers
{
    public class HomeController(
        ILogger<HomeController> _logger, 
        IEventService _eventService, 
        IGameService _gameService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            if (User.IsAdmin())
            {
                return RedirectToAction("DashBoard", "Admin", new { area = "Administrator" });
            }

            if (User.IsInRole("Moderator"))
            {
                return RedirectToAction("Dashboard", "Moderator", new { area = "Moderator" });
            }

            IEnumerable<EventIndexViewModel> latest3Events = await _eventService.GetLatest3EventsAsync();
            IEnumerable<GameIndexViewModel> last3Games = await _gameService.GetLast3GamesAsync();

            HomeViewModel model = new HomeViewModel()
            {
                Last3Events = latest3Events,
                Last3Games = last3Games
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            var requestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;

            switch (statusCode)
            {
                case 404:
                    Log.Error("404 Error occurred. Trace ID: {TraceId}", requestId);
                    return View("Error404");

                case 401:
                    Log.Error("401 Unauthorized Error occurred. Trace ID: {TraceId}", requestId);
                    return View("Error401");

                default:
                    Log.Error("An unexpected error occurred with status code {StatusCode}. Trace ID: {TraceId}", statusCode, requestId);
                    break;
            }

            //if (statusCode == 404)
            //{
            //    return View("Error404");
            //}

            //if(statusCode == 401)
            //{
            //    return View("Error401");
            //}

            return View(new ErrorViewModel { RequestId = requestId });
        }
    }
}
