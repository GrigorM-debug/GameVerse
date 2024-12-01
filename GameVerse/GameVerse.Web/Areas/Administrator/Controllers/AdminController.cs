using AspNetCoreHero.ToastNotification.Abstractions;
using GameVerse.Services.Interfaces;
using GameVerse.Web.Areas.Administrator.Models;
using GameVerse.Web.Areas.Administrator.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameVerse.Web.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Authorize(Roles = "Admin")]
    public class AdminController(
        ILogService _logService,
        INotyfService _notyfService,
        IUserManagementService _userManagementService,
        IGameService _gameService,
        IEventService _eventService,
        IEventsRegistrationsService _eventsRegistrationsService,
        IUsersBoughtGamesService _usersBoughtGamesService)
        : Controller
    {
        [HttpGet]
        public async Task<IActionResult> DashBoard()
        {
            AdminIndexViewModel model = new AdminIndexViewModel
            {
                TotalUsers = await _userManagementService.GetTotalUsersCountAsync(),
                TotalModerators = await _userManagementService.GetTotalModeratorsCountAsync(),
                TotalAdministrators = await _userManagementService.GetTotalAdministratorsCountAsync(),
                TotalEvents = await _eventService.GetTotalEventsCountAsync(),
                TotalGames = await _gameService.GetTotalGamesCountAsync(),
                TotalEventRegistrations = await _eventsRegistrationsService.GetTotalEventsRegistrationsCountAsync(),
                TotalBoughtGames = await _usersBoughtGamesService.GetUsersBoughtGamesCountAsync(),
                RecentLogs = _logService.GetLatestLogFiles(5)
                    .Select(filePath => Path.GetFileName(filePath)) 
                    .ToList()
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult DownloadLog(string fileName)
        {
            var logFile = _logService.GetLogFile(fileName);

            if (logFile == null)
            {
                _notyfService.Error("Log file not found.");
                return NotFound("Log file not found.");
            }

            return File(logFile.Value.FileContent, logFile.Value.ContentType, logFile.Value.FileName);
        }
    }
}
