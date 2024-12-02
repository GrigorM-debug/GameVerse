using System.Globalization;
using GameVerse.Web.Areas.Administrator.Models;
using GameVerse.Web.Areas.Administrator.Services;
using GameVerse.Web.Areas.Administrator.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GameVerse.Web.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Authorize(Roles = "Admin")]
    public class ValidateUserTicketController(IEventsRegistrationsService _eventsRegistrationsService) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ValidateTicket([FromBody] ValidateTicketRequestInputViewModel request)
        {
            if (string.IsNullOrEmpty(request.QrData))
            {
                return Json(new { valid = false });
            }

            try
            {
                var dataParts = request.QrData.Split(';');

                var eventIdPart = dataParts.FirstOrDefault(p => p.StartsWith("EventId:"));
                var userIdPart = dataParts.FirstOrDefault(p => p.StartsWith("UserId:"));
                var datePart = dataParts.FirstOrDefault(p => p.StartsWith("Date:"));

                if (string.IsNullOrEmpty(eventIdPart) || string.IsNullOrEmpty(userIdPart) || string.IsNullOrEmpty(datePart))
                {
                    return Json(new { valid = false });
                }

                datePart = datePart.Substring(5).Trim();

                DateTime parsedDate;

                if (!DateTime.TryParse(datePart.Trim(), out parsedDate))
                {
                    return Json(new { valid = false });
                }

                var decodedData = new DecodedDataViewModel
                {
                    EventId = eventIdPart.Split(':')[1],
                    UserId = userIdPart.Split(':')[1],
                    Date = parsedDate
                };

                bool isUserRegisteredForTheEvent = await _eventsRegistrationsService.IsUserEventRegistrationValidAsync(decodedData);

                if (!isUserRegisteredForTheEvent)
                {
                    return Json(new { valid = false });
                }

                return Json(new { valid = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return Json(new { valid = false });
            }
        }
    }
}
