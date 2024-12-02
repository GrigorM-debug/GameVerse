using System.Globalization;
using System.Linq;
using AspNetCoreHero.ToastNotification.Abstractions;
using GameVerse.Services.Interfaces;
using GameVerse.Web.Extensions;
using GameVerse.Web.Filters;
using GameVerse.Web.ViewModels.Game;
using GameVerse.Web.ViewModels.Game.Details;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;
using static GameVerse.Common.ApplicationConstants;

namespace GameVerse.Web.Controllers
{
    /// <summary>
    /// Handles operations related to the game store, including listing, editing, viewing details, and deleting games.
    /// </summary>
    [Authorize(Roles = "Admin, Moderator")]
    public class GameStoreController(
        ILogger<GameStoreController> _logger, 
        INotyfService _notyf, 
        IModeratorService _moderatorService, 
        IGameService _gameService) : BaseController
    {
        /// <summary>
        /// Displays a list of all games with optional filtering, searching, and pagination.
        /// </summary>
        /// <param name="model">The query model for filtering, searching, and pagination.</param>
        /// <returns>The view displaying a list of games.</returns>
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] AllGamesQueryModel model)
        {
            if (model.CurrentPage < 1)
            {
                model.CurrentPage = 1;
            }

            string? userId = string.Empty;
            if (User?.Identity?.IsAuthenticated == true && User.IsInRole("Moderator"))
            {
                userId = User.GetId();
            }

            int totalGameCount = await _gameService.GetTotalGamesCountAsync();

            IEnumerable<GameIndexViewModel> games = await _gameService.GetAllGamesAsync(
                model.CurrentPage,
                model.GamesPerPage,
                model.GameSelectedSortOrder,
                model.SearchString,
                model.GameSelectedGameTypeSortOrder,
                userId
            );

            model.TotalGamesCount = totalGameCount;
            model.Games = games;

            return View(model);
        }

        /// <summary>
        /// Displays detailed information about a specific game.
        /// </summary>
        /// <param name="id">The unique identifier of the game.</param>
        /// <returns>The details view of the game or a NotFound result if the game does not exist.</returns>
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            bool isGameExisting = await _gameService.GameExistByIdAsync(id);

            if (isGameExisting == false)
            {
                return NotFound();
            }

            GameDetailsViewModel model = await _gameService.GetGameDetailsByIdAsync(id);

            return View(model);
        }

        /// <summary>
        /// Displays the form to edit an existing game.
        /// </summary>
        /// <param name="id">The unique identifier of the game to edit.</param>
        /// <returns>The edit view of the game or Unauthorized/NotFound result if conditions are not met.</returns>
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            bool isGameExisting = await _gameService.GameExistByIdAsync(id);

            if (isGameExisting == false)
            {
                return NotFound();
            }

            bool isAdmin = User.IsAdmin();

            string? userId = User.GetId();
            string? moderatorId = await _moderatorService.GetModeratorIdByUserIdAsync(userId);

            if (moderatorId == null && isAdmin == false)
            {
                _notyf.Warning("You don't have the permission to do this");
                return Unauthorized();
            }

            bool isModeratorCreatorOfTheGame = await _gameService.HasPublisherWithIdAsync(moderatorId, id);

            if (isModeratorCreatorOfTheGame == false && isAdmin == false)
            {
                _notyf.Warning("You are not the creator of the game");
                return Unauthorized();
            }

            GameInputViewModel model = await _gameService.EditGameGetAsync(id, moderatorId, isAdmin);

            return View(model);
        }

        /// <summary>
        /// Handles the submission of the edited game data.
        /// </summary>
        /// <param name="inputModel">The edited game data.</param>
        /// <param name="id">The unique identifier of the game being edited.</param>
        /// <returns>Redirects to the game details view on success, or redisplays the form with validation errors.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(GameInputViewModel inputModel, string id)
        {
            bool isGameExisting = await _gameService.GameExistByIdAsync(id);

            if (isGameExisting == false)
            {
                return NotFound();
            }

            bool isAdmin = User.IsAdmin();

            string? userId = User.GetId();
            string? moderatorId = await _moderatorService.GetModeratorIdByUserIdAsync(userId);

            if (moderatorId == null && isAdmin == false)
            {
                _notyf.Warning("You don't have the permission to do this");
                return Unauthorized();
            }

            bool isModeratorCreatorOfTheGame = await _gameService.HasPublisherWithIdAsync(moderatorId, id);

            if (isModeratorCreatorOfTheGame == false && isAdmin == false)
            {
                _notyf.Warning("You are not the creator of the game");
                return Unauthorized();
            }

            var genres = await _gameService.GetGenresAsync();
            var platforms = await _gameService.GetPlatformsAsync();
            var restrictions = await _gameService.GetRestrictionsAsync();
            var types = _gameService.GetGameTypes();


            var genresIds = genres.Select(g => g.Id).ToHashSet();

            if (!inputModel.SelectedGenres.Any())
            {
                inputModel.GenreSelectList = genres;
                inputModel.PlatformSelectList = platforms;
                inputModel.RestrictionSelectList = restrictions;
                inputModel.GameTypes = types;
                ModelState.AddModelError(nameof(inputModel.SelectedGenres), "Please select genre/s for the game");
                _notyf.Error("Please select genre/s for the game");
                return View(inputModel);
            }

            foreach (var selectedGenre in inputModel.SelectedGenres)
            {
                if (!genresIds.Contains(selectedGenre))
                {
                    inputModel.GenreSelectList = genres;
                    inputModel.PlatformSelectList = platforms;
                    inputModel.RestrictionSelectList = restrictions;
                    inputModel.GameTypes = types;
                    ModelState.AddModelError(nameof(inputModel.SelectedGenres), "Selected genre/s doesn't exist");
                    _notyf.Error("Selected genre/s doesn't exist");
                    return View(inputModel);
                }
            }

            var platformsIds = platforms.Select(p => p.Id).ToHashSet();

            if (!inputModel.SelectedPlatforms.Any())
            {
                inputModel.GenreSelectList = genres;
                inputModel.PlatformSelectList = platforms;
                inputModel.RestrictionSelectList = restrictions;
                inputModel.GameTypes = types;
                ModelState.AddModelError(nameof(inputModel.SelectedPlatforms), "Please select platform/s for the game");
                _notyf.Error("Please select platform/s for the game");
                return View(inputModel);
            }

            foreach (var selectedPlatform in inputModel.SelectedPlatforms)
            {
                if (!platformsIds.Contains(selectedPlatform))
                {
                    inputModel.GenreSelectList = genres;
                    inputModel.PlatformSelectList = platforms;
                    inputModel.RestrictionSelectList = restrictions;
                    inputModel.GameTypes = types;
                    ModelState.AddModelError(nameof(inputModel.SelectedPlatforms), "Selected platform/s doesn't exist");
                    _notyf.Error("Selected platform/s doesn't exist");
                    return View(inputModel);
                }
            }

            var restrictionsIds = restrictions.Select(r => r.Id).ToHashSet();

            if (!inputModel.SelectedRestrictions.Any())
            {
                inputModel.GenreSelectList = genres;
                inputModel.PlatformSelectList = platforms;
                inputModel.RestrictionSelectList = restrictions;
                inputModel.GameTypes = types;
                ModelState.AddModelError(nameof(inputModel.SelectedRestrictions), "Please select restriction/s for the game");
                _notyf.Error("Please select restriction/s for the game");
                return View(inputModel);
            }

            foreach (var selectedRestriction in inputModel.SelectedRestrictions)
            {
                if (!restrictionsIds.Contains(selectedRestriction))
                {
                    inputModel.GenreSelectList = genres;
                    inputModel.PlatformSelectList = platforms;
                    inputModel.RestrictionSelectList = restrictions;
                    inputModel.GameTypes = types;
                    ModelState.AddModelError(nameof(inputModel.SelectedRestrictions), "Selected restriction/s doesn't exit");
                    _notyf.Error("Selected restriction/s doesn't exit");
                    return View(inputModel);
                }
            }

            var typesValues = types.Select(t => t.Value).ToHashSet();

            if (!typesValues.Contains((int)inputModel.Type))
            {
                inputModel.GenreSelectList = genres;
                inputModel.PlatformSelectList = platforms;
                inputModel.RestrictionSelectList = restrictions;
                inputModel.GameTypes = types;
                ModelState.AddModelError(nameof(inputModel.Type), "Selected game type is invalid");
                _notyf.Error("Selected game type is invalid");
                return View(inputModel);
            }


            if (!DateTime.TryParseExact(inputModel.CreatedOn, DateTimeFormat, CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime createdOn))
            {
                ModelState.AddModelError(nameof(inputModel.CreatedOn), InvalidDateTimeErrorMessage);
                _notyf.Error(InvalidDateTimeErrorMessage);
                return View(inputModel);
            }

            if (ModelState.IsValid == false)
            {
                return View(inputModel);
            }


            string? gameId = await _gameService.EditGamePostAsync(inputModel, createdOn,id, moderatorId, isAdmin);

            _notyf.Success("Game was edited successfully!");

            if (isAdmin)
            {
                Log.Information("Admin with ID {AdminId} perform an {Action} action in controller {Controller}", User.GetId(), nameof(Edit), nameof(GameStoreController));
            }
            else
            {
                Log.Information("Moderator with ID {ModeratorId} perform an {Action} action in controller {Controller}", moderatorId, nameof(Edit), nameof(GameStoreController));
            }

            return RedirectToAction(nameof(Details), new { id = gameId, area = "" });
        }

        /// <summary>
        /// Displays the delete confirmation view for a game.
        /// </summary>
        /// <param name="id">The unique identifier of the game to delete.</param>
        /// <returns>The delete confirmation view or Unauthorized/NotFound result.</returns>
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            string? userId = User.GetId();

            string? moderatorId = await _moderatorService.GetModeratorIdByUserIdAsync(userId);

            bool isAdmin = User.IsAdmin();

            if (moderatorId == null && isAdmin == false)
            {
                _notyf.Warning("You don't have the permission to do this");
                return Unauthorized();
            }


            bool isGameExiting = await _gameService.GameExistByIdAsync(id);

            if (isGameExiting == false)
            {
                return NotFound();
            }

            bool isCreatorOfTheGame = await _gameService.HasPublisherWithIdAsync(moderatorId, id);

            if (isCreatorOfTheGame == false && isAdmin == false)
            {
                _notyf.Warning("You are not the creator of the Game");
                return Unauthorized();
            }

            GameDeleteViewModel model = await _gameService.DeleteGameGetAsync(id, moderatorId, isAdmin);

            return View(model);
        }

        /// <summary>
        /// Handles the deletion of a game after confirmation.
        /// </summary>
        /// <param name="id">The unique identifier of the game to delete.</param>
        /// <returns>Redirects to the game index view on success.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(string id)
        {
            string? userId = User.GetId();

            string? moderatorId = await _moderatorService.GetModeratorIdByUserIdAsync(userId);

            bool isAdmin = User.IsAdmin();

            if (moderatorId == null && isAdmin == false)
            {
                _notyf.Warning("You don't have the permission to do this");
                return Unauthorized();
            }

            bool isGameExiting = await _gameService.GameExistByIdAsync(id);

            if (isGameExiting == false)
            {
                return NotFound();
            }

            bool isCreatorOfTheGame = await _gameService.HasPublisherWithIdAsync(moderatorId, id);

            if (isCreatorOfTheGame == false && isAdmin == false)
            {
                _notyf.Warning("You are not the creator of the Game");
                return Unauthorized();
            }

            await _gameService.DeleteGamePostAsync(id, moderatorId, isAdmin);

            await _moderatorService.DecreaseCreatedTotalGamesCount(moderatorId, isAdmin);

            _notyf.Success("Game was deleted successfully!");

            if (isAdmin)
            {
                Log.Information("Admin with ID {AdminId} perform an {Action} action in controller {Controller}", User.GetId(), nameof(DeleteConfirm), nameof(GameStoreController));
            }
            else
            {
                Log.Information("Moderator with ID {ModeratorId} perform an {Action} action in controller {Controller}", moderatorId, nameof(DeleteConfirm), nameof(GameStoreController));
            }

            return RedirectToAction("Index", "GameStore", new{ area = "" });
        }
    }
}
