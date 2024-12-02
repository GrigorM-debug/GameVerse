using AspNetCoreHero.ToastNotification.Abstractions;
using GameVerse.Services;
using GameVerse.Services.Interfaces;
using GameVerse.Web.Extensions;
using GameVerse.Web.Filters;
using GameVerse.Web.ViewModels.Event;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Security.Claims;
using Serilog;
using static GameVerse.Common.ApplicationConstants;
using static GameVerse.Common.ApplicationConstants.EventConstants;

namespace GameVerse.Web.Controllers
{
    /// <summary>
    /// Handles operations related to events such as listing, editing, deleting, and details.
    /// </summary>
    [Authorize(Roles = "Admin, Moderator")]
    public class EventController(
        ILogger<EventController> _logger, 
        IEventService _eventService, 
        IModeratorService _moderatorService, 
        INotyfService _notyf) : BaseController
    {
        /// <summary>
        /// Displays a list of all events with optional filtering and pagination.
        /// </summary>
        /// <param name="model">Query model for filtering and pagination.</param>
        /// <returns>The event index view with the list of events.</returns>
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] AllEventsQueryModel model)
        {
            if (model.CurrentPage < 1)
            {
                model.CurrentPage = 1;
            }

            int totalEventsCount = await _eventService.GetTotalEventsCountAsync();

            IEnumerable<EventIndexViewModel> events = await _eventService.GetAllEventsAsync(
                model.CurrentPage,
                model.EventsPerPage,
                model.EventSelectedSortOrder
                );

            model.TotalEventsCount = totalEventsCount;
            model.Events = events;

            return View(model);
        }

        /// <summary>
        /// Displays detailed information about a specific event.
        /// </summary>
        /// <param name="id">The unique identifier of the event.</param>
        /// <returns>The event details view or NotFound if the event does not exist.</returns>
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

        /// <summary>
        /// Displays the event edit form for the specified event.
        /// </summary>
        /// <param name="id">The unique identifier of the event.</param>
        /// <returns>The edit event view or Unauthorized/NotFound based on permissions.</returns>
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

            bool isAdmin = User.IsAdmin();

            if(String.IsNullOrEmpty(moderatorId) && isAdmin == false)
            {
                //You can also redirect to Login Page. 
                _notyf.Warning("You don't have the permission to do this");
                return Unauthorized();
            }

            if (await _eventService.HasPublisherWithIdAsync(moderatorId, id) == false && isAdmin == false)
            {
                //You can also redirect to Login Page.
                _notyf.Warning("You are not the creator of the Event");
                return Unauthorized();
            }

            EventInputViewModel? model = await _eventService.EditEventGetAsync(id, moderatorId, isAdmin);

            return View(model);
        }

        /// <summary>
        /// Handles the event editing logic after form submission.
        /// </summary>
        /// <param name="inputModel">The edited event data from the form.</param>
        /// <param name="id">The unique identifier of the event.</param>
        /// <returns>Redirects to the event details view upon success or redisplays the form upon failure.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EventInputViewModel inputModel, string id)
        {
            bool isEventExist = await _eventService.EventExistById(id);

            if (!isEventExist)
            {
                return NotFound();
            }

            string? userId = User.GetId();
            string? moderatorId = await _moderatorService.GetModeratorIdByUserIdAsync(userId);

            bool isAdmin = User.IsAdmin();

            if(String.IsNullOrEmpty(moderatorId) && isAdmin == false)
            {
                //You can also redirect to Login Page
                _notyf.Warning("You don't have the permission to do this");
                return Unauthorized();
            }

            if (await _eventService.HasPublisherWithIdAsync(moderatorId, id) == false && isAdmin == false)
            {
                //You can also redirect to Login Page
                _notyf.Warning("You are not the creator of the Event");
                return Unauthorized();
            }

            if (DateTime.TryParseExact(inputModel.StartDate, EventDateTimeFormat, CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime startDate) == false)
            {
                ModelState.AddModelError(nameof(inputModel.StartDate), EventDateTimeErrorMessage);
                _notyf.Error(EventDateTimeErrorMessage);
                return View(inputModel);
            }

            if (DateTime.TryParseExact(inputModel.EndDate, EventDateTimeFormat, CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime endDate) == false)
            {
                ModelState.AddModelError(nameof(inputModel.EndDate), EventDateTimeErrorMessage);
                _notyf.Error(EventDateTimeErrorMessage);
                return View(inputModel);
            }

            if (startDate > endDate)
            {
                ModelState.AddModelError(nameof(inputModel.EndDate), "End date cannot be earlier than Start date.");
                _notyf.Error("End date cannot be earlier than Start date.");
                return View(inputModel);
            }

            if (startDate == endDate)
            {
                ModelState.AddModelError(nameof(inputModel.EndDate), "End date cannot be the same as Start date.");
                _notyf.Error("End date cannot be the same as Start date.");
                return View(inputModel);
            }

            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }

            string eventId = await _eventService.EditEventPostAsync(inputModel, id, moderatorId, startDate, endDate, isAdmin);

            _notyf.Success("Event was edited successfully!");

            if (isAdmin)
            {
                Log.Information("Admin with ID {AdminId} perform an {Action} in controller {Controller}", User.GetId(), nameof(Edit), nameof(EventController));
            }
            else
            {
                Log.Information("Moderator with ID {ModeratorId} perform an {Action} in controller {Controller}", moderatorId, nameof(Edit), nameof(EventController));
            }


            return RedirectToAction(nameof(Details), new { id = eventId, area = "" });
        }

        /// <summary>
        /// Displays the delete confirmation view for an event.
        /// </summary>
        /// <param name="id">The unique identifier of the event.</param>
        /// <returns>The delete confirmation view or Unauthorized/NotFound based on permissions.</returns>
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

            bool isAdmin = User.IsAdmin();

            if (String.IsNullOrEmpty(moderatorId) && isAdmin == false)
            {
                //You can also redirect to Login Page
                _notyf.Warning("You don't have the permission to do this");
                return Unauthorized();
            }

            if (await _eventService.HasPublisherWithIdAsync(moderatorId, id) == false && isAdmin == false)
            {
                //You can also redirect to Login Page
                _notyf.Warning("You are not the creator of the Event");
                return Unauthorized();
            }

            EventDeleteViewModel? model = await _eventService.DeleteEventGetAsync(id, moderatorId, isAdmin);

            return View(model);
        }

        /// <summary>
        /// Handles the deletion of an event after confirmation.
        /// </summary>
        /// <param name="id">The unique identifier of the event.</param>
        /// <returns>Redirects to the event index view upon successful deletion.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(string id)
        {
            bool isEventExist = await _eventService.EventExistById(id);

            if (!isEventExist)
            {
                return NotFound();
            }

            string? userId = User.GetId();
            string? moderatorId = await _moderatorService.GetModeratorIdByUserIdAsync(userId);
            bool isAdmin = User.IsAdmin();

            if (String.IsNullOrEmpty(moderatorId) && isAdmin == false) 
            {
                //You can also redirect to Login Page
                _notyf.Warning("You don't have the permission to do this");
                return Unauthorized();
            }

            if (await _eventService.HasPublisherWithIdAsync(moderatorId, id) == false && isAdmin == false)
            {
                //You can also redirect to Login Page
                _notyf.Warning("You are not the creator of the Event");
                return Unauthorized();
            }

            await _eventService.DeleteEventPostAsync(id, moderatorId, isAdmin);

            await _moderatorService.DecreaseCreatedTotalEventsCount(moderatorId, isAdmin);

            _notyf.Success("Event was deleted successfully !");

            if (isAdmin)
            {
                Log.Information("Admin with ID {AdminId} perform an {Action} in controller {Controller}", User.GetId(), nameof(Delete), nameof(EventController));
            }
            else
            {
                Log.Information("Moderator with ID {ModeratorId} perform an {Action} in controller {Controller}", moderatorId, nameof(Delete), nameof(EventController));
            }

            return RedirectToAction("Index", "Event",new { area = ""});
        }
    }
}
