using GameVerse.Services.Events;
using GameVerse.Services.Interfaces.Events;
using GameVerse.Web.Extensions;
using GameVerse.Web.ViewModels.Event;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        [HttpGet]
        public IActionResult Add()
        {
            EventInputViewModel model = new EventInputViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EventInputViewModel inputModel)
        {
            string? userId = User.GetId();

            string eventId = await _eventService.AddEventAsync(inputModel, userId!);

            if(eventId == null)
            {
                //If the id ios null it means that the event already exist
                //Dind a way to display message
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            bool isEventExist = await _eventService.EventExistById(id);

            if(!isEventExist)
            {
                //Display some message or go to 404 page
            }

            string? userId = User.GetId();

            EventInputViewModel? model = await _eventService.EditEventGetAsync(id, userId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EventInputViewModel inputModel, string id)
        {
            bool isEventExist = await _eventService.EventExistById(id);

            if (!isEventExist)
            {
                //Display some message or go to 404 page
            }

            string? userId = User.GetId();

            await _eventService.EditEventPostAsync(inputModel, id, userId);

            return RedirectToAction(nameof(Index));
        }
    }
}
