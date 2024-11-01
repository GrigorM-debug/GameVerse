using AspNetCoreHero.ToastNotification.Abstractions;
using GameVerse.Services;
using GameVerse.Services.Interfaces;
using GameVerse.Web.Extensions;
using GameVerse.Web.ViewModels.Event;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace GameVerse.Web.Controllers
{
    [Authorize]
    public class EventController(IEventService eventService, IModeratorService moderatorService, INotyfService notyf) : BaseController
    {
        private readonly IEventService _eventService = eventService;
        private readonly IModeratorService _moderatorService = moderatorService;
        private readonly INotyfService _notyf = notyf;

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<EventIndexViewModel> events = await _eventService.GetAllEventsAsync();

            return View(events);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            bool isEventExist = await _eventService.EventExistById(id);

            if (!isEventExist)
            {
                //Display some message or go to 404 page
            }

            EventDetailsViewModel model = await _eventService.GetEventDetailsByIdAsync(id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            bool isModerator = await _moderatorService.ModeratorExistByUserIdAsync(User.GetId()!);

            if (!isModerator)
            {
                _notyf.Error("You don't have the permission to do this!");

                //return Unauthorized();
            }

            EventInputViewModel model = new EventInputViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EventInputViewModel inputModel)
        {
            bool isModerator = await _moderatorService.ModeratorExistByUserIdAsync(User.GetId()!);

            if (!isModerator)
            {
                _notyf.Error("You don't have the permission to do this!");

                //return Unauthorized();
            }

            bool isEventExisting = await _eventService.EventExistByTitle(inputModel.Topic);


            if(isEventExisting)
            {
                _notyf.Warning("Event with this Topic already exist !");

                return View(inputModel);
            }

            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }

            string? moderatorId = await _moderatorService.GetModeratorIdByUserIdAsync(User.GetId());

            string eventId = await _eventService.AddEventAsync(inputModel, moderatorId!);

            _notyf.Success("Event was added successfully!");

            return RedirectToAction(nameof(Details), new {id = eventId});
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

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            bool isEventExist = await _eventService.EventExistById(id);

            if (!isEventExist)
            {
                //Display some message or go to 404 page
            }

            string? userId = User.GetId();

            EventDeleteViewModel model = await _eventService.DeleteEventGetAsync(id, userId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirm(string id)
        {
            bool isEventExist = await _eventService.EventExistById(id);

            if (!isEventExist)
            {
                //Display some message or go to 404 page
            }

            string? userId = User.GetId();

            await _eventService.DeleteEventPostAsync(id, userId);

            return RedirectToAction(nameof(Index));
        }
    }
}
