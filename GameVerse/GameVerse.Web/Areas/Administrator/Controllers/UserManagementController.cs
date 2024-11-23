using AspNetCoreHero.ToastNotification.Abstractions;
using GameVerse.Data.Models.ApplicationUsers;
using GameVerse.Services.Interfaces;
using GameVerse.Web.Areas.Administrator.Models;
using GameVerse.Web.Areas.Administrator.Services.Interfaces;
using GameVerse.Web.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace GameVerse.Web.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Authorize(Roles = "Admin")]
    public class UserManagementController : Controller
    {
        private readonly IUserManagementService _userManagementService;
        private readonly IModeratorService _moderatorService;
        private readonly INotyfService _notyfService;
        private ILogger<UserManagementController> _logger;

        public UserManagementController(IUserManagementService userManagementService, INotyfService notyfService, ILogger<UserManagementController> logger, IModeratorService moderatorService)
        {   
            _userManagementService = userManagementService;
            _notyfService = notyfService;
            _logger = logger;
            _moderatorService = moderatorService;
        }

        [HttpGet]
        public async Task<IActionResult> ManageUsers()
        {
            IEnumerable<UserViewModel> userViewModels = await _userManagementService.GetAllUsersWithDetailsAsync();

            return View(userViewModels);
        }

        [HttpPost]
        public async Task<IActionResult> PromoteUserToModerator(string userId)
        {
            bool userExist = await _userManagementService.UserExistByIdAsync(userId);

            if (!userExist)
            {
                return NotFound();
            }

            bool isAlreadyModerator = await _moderatorService.ModeratorExistByUserIdAsync(userId);

            if (isAlreadyModerator)
            {
                _notyfService.Error("This user is already Moderator");
                return RedirectToAction(nameof(ManageUsers));
            }

            await _userManagementService.PromoteUserToModeratorAsync(userId);

            _notyfService.Success("User successfully promoted to Moderator");

            Log.Information("Admin with ID: {AdminId} made {Action} in {Controller}", User.GetId(), nameof(PromoteUserToModerator), nameof(UserManagementController));

            return RedirectToAction(nameof(ManageUsers));
        }

        [HttpPost]
        public async Task<IActionResult> DemoteModeratorToUser(string userId)
        {
            bool userExist = await _userManagementService.UserExistByIdAsync(userId);

            if (!userExist)
            {
                return NotFound();
            }

            bool moderatorExist = await _moderatorService.ModeratorExistByUserIdAsync(userId);

            if (!moderatorExist)
            {
                return NotFound();
            }

            await _userManagementService.DemoteModeratorToUserAsync(userId);

            _notyfService.Success("Moderator successfully demoted to User");

            Log.Information("Admin with ID: {AdminId} made {Action} in {Controller}", User.GetId(), nameof(DemoteModeratorToUser), nameof(UserManagementController));

            return RedirectToAction(nameof(ManageUsers));
        }

        [HttpPost]
        public async Task<IActionResult> PromoteModeratorToAdministrator(string userId)
        {
            bool userExist = await _userManagementService.UserExistByIdAsync(userId);

            if (!userExist)
            {
                return NotFound();
            }

            bool moderatorExist = await _moderatorService.ModeratorExistByUserIdAsync(userId);

            if (!moderatorExist)
            {
                return NotFound();
            }

            bool isModeratorAlreadyAdministrator = await _userManagementService.AdministratorExistByIdAsync(userId);

            if (isModeratorAlreadyAdministrator)
            {
                _notyfService.Error("This user is already Administrator");
                return RedirectToAction(nameof(ManageUsers));
            }

            await _userManagementService.PromoteModeratorToAdministratorAsync(userId);

            _notyfService.Success("Moderator successfully promoted to Administrator");

            Log.Information("Admin with ID: {AdminId} made {Action} in {Controller}", User.GetId(), nameof(PromoteModeratorToAdministrator), nameof(UserManagementController));

            return RedirectToAction(nameof(ManageUsers));
        }
    }
}
