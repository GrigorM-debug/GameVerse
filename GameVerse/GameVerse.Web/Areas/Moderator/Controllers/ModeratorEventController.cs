using AspNetCoreHero.ToastNotification.Abstractions;
using GameVerse.Services.Interfaces;
using GameVerse.Web.Extensions;
using GameVerse.Web.ViewModels.Event;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Serilog;
using System.Globalization;
using static GameVerse.Common.ApplicationConstants;
using static GameVerse.Common.ApplicationConstants.EventConstants;

namespace GameVerse.Web.Areas.Moderator.Controllers
{
    [Area("Moderator")]
    [Authorize(Roles = "Moderator")]
    public class ModeratorEventController(
        IEventService eventService, 
        ILogger<ModeratorEventController> logger, 
        IModeratorService moderatorService, 
        INotyfService notyf
        ) : Controller
    {
        private readonly IEventService _eventService = eventService;
        private readonly ILogger<ModeratorEventController> _logger = logger;
        private readonly IModeratorService _moderatorService = moderatorService;
        private readonly INotyfService _notyf = notyf;

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            EventInputViewModel model = new EventInputViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EventInputViewModel inputModel)
        {
            string? moderatorId = await _moderatorService.GetModeratorIdByUserIdAsync(User.GetId());

            if (moderatorId == null)
            {
                _notyf.Warning("You don't have the permission to do this");
                return Unauthorized();
            }

            bool isEventExisting = await _eventService.EventExistByTitle(inputModel.Topic);

            if (isEventExisting)
            {
                _notyf.Warning("Event with this Topic already exist !");

                return View(inputModel);
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
                ModelState.AddModelError(nameof(inputModel.EndDate), "End date can not be earlier than Start date.");
                _notyf.Error("End date can not be earlier than Start date.");
                return View(inputModel);
            }

            if (startDate == endDate)
            {
                ModelState.AddModelError(nameof(inputModel.EndDate), "End date can not be the same as Start date.");
                _notyf.Warning("End date can not be the same as Start date.");
                return View(inputModel);
            }

            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }


            string eventId = await _eventService.AddEventAsync(inputModel, moderatorId!, startDate, endDate);

            await _moderatorService.InCreaseCreatedTotalEventsCount(moderatorId);

            _notyf.Success("Event was added successfully!");

            Log.Information("Moderator with ID {ModeratorId} perform an {Action} in controller {Controller}", moderatorId, nameof(Add), nameof(ModeratorEventController));

            return RedirectToAction("Details", "Event", new { id = eventId, area = "" });
        }
    }
}
