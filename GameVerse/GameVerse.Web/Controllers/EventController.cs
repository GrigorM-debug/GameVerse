using GameVerse.Services.Events;
using GameVerse.Services.Interfaces.Events;
using GameVerse.Web.ViewModels.Event;
using Microsoft.AspNetCore.Mvc;

namespace GameVerse.Web.Controllers
{
    public class EventController(EventService eventService) : BaseController
    {
        private readonly IEventService _eventService = eventService;

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<EventIndexViewModel> events = await _eventService.GetAllEventsAsync();

            return View(events);
        }
    }
}
