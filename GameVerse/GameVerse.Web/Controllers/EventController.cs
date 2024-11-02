﻿using AspNetCoreHero.ToastNotification.Abstractions;
using GameVerse.Services;
using GameVerse.Services.Interfaces;
using GameVerse.Web.Extensions;
using GameVerse.Web.Filters;
using GameVerse.Web.ViewModels.Event;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Security.Claims;
using static GameVerse.Common.ApplicationConstants.EventConstants;

namespace GameVerse.Web.Controllers
{
    [Authorize]
    public class EventController(ILogger<EventController> logger, IEventService eventService, IModeratorService moderatorService, INotyfService notyf) : BaseController
    {
        private readonly ILogger<EventController> _logger = logger;
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
                return NotFound();
            }

            EventDetailsViewModel model = await _eventService.GetEventDetailsByIdAsync(id);

            return View(model);
        }

        [MustBeModerator]
        [HttpGet]
        public IActionResult Add()
        {
            EventInputViewModel model = new EventInputViewModel();

            return View(model);
        }

        [MustBeModerator]
        [HttpPost]
        public async Task<IActionResult> Add(EventInputViewModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }

            DateTime startDate = DateTime.ParseExact(inputModel.StartDate, EventDateTimeFormat, CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(inputModel.EndDate, EventDateTimeFormat, CultureInfo.InvariantCulture);

            if (startDate > endDate)
            {
                ModelState.AddModelError(nameof(inputModel.EndDate), "End date cannot be earlier than Start date.");
                return View(inputModel);
            }

            if (startDate == endDate)
            {
                ModelState.AddModelError(nameof(inputModel.EndDate), "End date cannot be the same as Start date.");
                return View(inputModel);
            }

            bool isEventExisting = await _eventService.EventExistByTitle(inputModel.Topic);

            if(isEventExisting)
            {
                _notyf.Warning("Event with this Topic already exist !");

                return View(inputModel);
            }

            string? moderatorId = await _moderatorService.GetModeratorIdByUserIdAsync(User.GetId());

            string eventId = await _eventService.AddEventAsync(inputModel, moderatorId!, startDate, endDate);

            _notyf.Success("Event was added successfully!");

            return RedirectToAction(nameof(Details), new {id = eventId});
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            bool isEventExist = await _eventService.EventExistById(id);

            if(!isEventExist)
            {
                return NotFound();
            }

            string? userId = User.GetId();
            string? moderatorId = await _moderatorService.GetModeratorIdByUserIdAsync(userId);

            if(String.IsNullOrEmpty(moderatorId))
            {
                //You can also redirect to Login Page. 
                return Unauthorized();
            }

            if (await _eventService.HasPublisherWithIdAsync(moderatorId, id) == false && User.IsAdmin() == false)
            {
                //You can also redirect to Login Page.
                return Unauthorized();
            }

            EventInputViewModel? model = await _eventService.EditEventGetAsync(id, moderatorId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EventInputViewModel inputModel, string id)
        {
            bool isEventExist = await _eventService.EventExistById(id);

            if (!isEventExist)
            {
                return NotFound();
            }

            string? userId = User.GetId();
            string? moderatorId = await _moderatorService.GetModeratorIdByUserIdAsync(userId);

            if(String.IsNullOrEmpty(moderatorId))
            {
                //You can also redirect to Login Page
                return Unauthorized();
            }

            if (await _eventService.HasPublisherWithIdAsync(moderatorId, id) == false && User.IsAdmin() == false)
            {
                //You can also redirect to Login Page
                return Unauthorized();
            }
            
            DateTime startDate = DateTime.ParseExact(inputModel.StartDate, EventDateTimeFormat, CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(inputModel.EndDate, EventDateTimeFormat, CultureInfo.InvariantCulture);

            if (startDate > endDate)
            {
                ModelState.AddModelError(nameof(inputModel.EndDate), "End date cannot be earlier than Start date.");
                return View(inputModel);
            }

            if (startDate == endDate)
            {
                ModelState.AddModelError(nameof(inputModel.EndDate), "End date cannot be the same as Start date.");
                return View(inputModel);
            }

            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }

            bool isEventExisting = await _eventService.EventExistByTitle(inputModel.Topic);

            if (isEventExisting)
            {
                _notyf.Warning("Event with this Topic already exist !");

                return View(inputModel);
            }

            string eventId = await _eventService.EditEventPostAsync(inputModel, id, moderatorId, startDate, endDate);

            _notyf.Success("Event was edited successfully!");

            return RedirectToAction(nameof(Details), new { id = eventId });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            bool isEventExist = await _eventService.EventExistById(id);

            if (!isEventExist)
            {
                return NotFound();
            }

            string? userId = User.GetId();
            string? moderatorId = await _moderatorService.GetModeratorIdByUserIdAsync(userId);

            if (String.IsNullOrEmpty(moderatorId))
            {
                //You can also redirect to Login Page
                return Unauthorized();
            }

            if (await _eventService.HasPublisherWithIdAsync(moderatorId, id) == false && User.IsAdmin() == false)
            {
                //You can also redirect to Login Page
                return Unauthorized();
            }

            EventDeleteViewModel? model = await _eventService.DeleteEventGetAsync(id, moderatorId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirm(string id)
        {
            bool isEventExist = await _eventService.EventExistById(id);

            if (!isEventExist)
            {
                return NotFound();
            }

            string? userId = User.GetId();
            string? moderatorId = await _moderatorService.GetModeratorIdByUserIdAsync(userId);

            if (String.IsNullOrEmpty(moderatorId))
            {
                //You can also redirect to Login Page
                return Unauthorized();
            }

            if (await _eventService.HasPublisherWithIdAsync(moderatorId, id) == false && User.IsAdmin() == false)
            {
                //You can also redirect to Login Page
                return Unauthorized();
            }

            await _eventService.DeleteEventPostAsync(id, moderatorId);

            _notyf.Success("Event was deleted successfully !");

            return RedirectToAction(nameof(Index));
        }
    }
}
