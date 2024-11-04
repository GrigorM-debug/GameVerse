using AspNetCoreHero.ToastNotification.Abstractions;
using GameVerse.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using GameVerse.Services.Interfaces;
using GameVerse.Web.ViewModels;
using GameVerse.Web.ViewModels.Event;
using Serilog;

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
