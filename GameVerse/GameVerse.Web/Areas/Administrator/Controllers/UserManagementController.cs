﻿using AspNetCoreHero.ToastNotification.Abstractions;
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
    /// <summary>
    /// Controller responsible for managing user roles and permissions in the administrator area.
    /// </summary>
    [Area("Administrator")]
    [Authorize(Roles = "Admin")]
    public class UserManagementController(
        IUserManagementService _userManagementService,
        INotyfService _notyfService,
        ILogger<UserManagementController> _logger,
        IModeratorService _moderatorService)
        : Controller
    {
        /// <summary>
        /// Retrieves and displays a list of all users with their details.
        /// </summary>
        /// <returns>A view displaying the list of users.</returns>
        [HttpGet]
        public async Task<IActionResult> ManageUsers()
        {
            IEnumerable<UserViewModel> userViewModels = await _userManagementService.GetAllUsersWithDetailsAsync();

            return View(userViewModels);
        }

        /// <summary>
        /// Promotes a user to a moderator role.
        /// </summary>
        /// <param name="userId">The ID of the user to promote.</param>
        /// <returns>A redirection to the Manage Users view.</returns>
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

        /// <summary>
        /// Demotes a moderator to a regular user role.
        /// </summary>
        /// <param name="userId">The ID of the moderator to demote.</param>
        /// <returns>A redirection to the Manage Users view.</returns>
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

        /// <summary>
        /// Promotes a moderator to an administrator role.
        /// </summary>
        /// <param name="userId">The ID of the moderator to promote.</param>
        /// <returns>A redirection to the Manage Users view.</returns>
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
