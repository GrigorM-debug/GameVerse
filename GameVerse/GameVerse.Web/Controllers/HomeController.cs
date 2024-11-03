using AspNetCoreHero.ToastNotification.Abstractions;
using GameVerse.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using GameVerse.Services.Interfaces;
using GameVerse.Web.ViewModels;
using GameVerse.Web.ViewModels.Event;

namespace GameVerse.Web.Controllers
{
    public class HomeController(ILogger<HomeController> logger, IEventService eventService) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;
        private readonly IEventService _eventService = eventService;

        public async Task<IActionResult> Index()
        {
            IEnumerable<EventIndexViewModel> latest3Events = await _eventService.GetLatest3EventsAsync();

            HomeViewModel model = new HomeViewModel()
            {
                Last3Events = latest3Events
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

            if(statusCode == 404)
            {
                return View("Error404");
            }

            if(statusCode == 401)
            {
                return View("Error401");
            }

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
