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
    /// <summary>
    /// Handles operations related to the home page, privacy policy, and error handling.
    /// </summary>
    public class HomeController(
        ILogger<HomeController> _logger, 
        IEventService _eventService, 
        IGameService _gameService) : Controller
    {
        /// <summary>
        /// Displays the home page. Redirects users to dashboards based on their roles or shows the latest events and games for regular users.
        /// </summary>
        /// <returns>The home page view for regular users or a redirection to the appropriate dashboard for Admins/Moderators.</returns>
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

        /// <summary>
        /// Displays the privacy policy page.
        /// </summary>
        /// <returns>The privacy policy view.</returns>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Handles error responses based on the HTTP status code.
        /// </summary>
        /// <param name="statusCode">The HTTP status code of the error.</param>
        /// <returns>The appropriate error view for the given status code.</returns>
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

            return View(new ErrorViewModel { RequestId = requestId });
        }
    }
}
