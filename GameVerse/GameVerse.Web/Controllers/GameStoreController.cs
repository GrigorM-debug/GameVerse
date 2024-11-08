using System.Globalization;
using System.Linq;
using AspNetCoreHero.ToastNotification.Abstractions;
using GameVerse.Services.Interfaces;
using GameVerse.Web.Extensions;
using GameVerse.Web.Filters;
using GameVerse.Web.ViewModels.Game;
using GameVerse.Web.ViewModels.Game.Add;
using GameVerse.Web.ViewModels.Game.Details;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
using static GameVerse.Common.ApplicationConstants;

namespace GameVerse.Web.Controllers
{
    [Authorize]
    public class GameStoreController : Controller
    {
        private readonly ILogger<GameStoreController> _logger;
        private readonly INotyfService _notyf;
        private readonly IModeratorService _moderatorService;
        private readonly IGameService _gameService;

        public GameStoreController(ILogger<GameStoreController> logger, INotyfService notyf, IModeratorService moderatorService, IGameService gameService)
        {
            _logger = logger;
            _notyf = notyf;
            _moderatorService = moderatorService;
            _gameService = gameService;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

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

        [MustBeModerator]
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            GameInputViewModel model = await _gameService.AddGameGetAsync();

            return View(model);
        }

        [MustBeModerator]
        [HttpPost]
        public async Task<IActionResult> Add(GameInputViewModel inputModel)
        {
            var genres = await _gameService.GetGenresAsync();
            var genresIds = genres.Select(g => g.Id).ToHashSet();

            foreach (var selectedGenre in inputModel.SelectedGenres)
            {
                if (!genresIds.Contains(selectedGenre))
                {
                    _notyf.Error("Selected genre/s doesn't exist");
                    return View(inputModel);
                }
            }
            
            var platforms = await _gameService.GetPlatformsAsync();
            var platformsIds = platforms.Select(p => p.Id).ToHashSet();

            foreach (var selectedPlatform in inputModel.SelectedPlatforms)
            {
                if (!platformsIds.Contains(selectedPlatform))
                {
                    _notyf.Error("Selected platform/s doesn't exist");
                    return View(inputModel);
                }
            }

            var restrictions = await _gameService.GetRestrictionsAsync();
            var restrictionsIds = restrictions.Select(r => r.Id).ToHashSet();

            foreach(var selectedRestriction in inputModel.SelectedRestrictions)
            {
                if (!restrictionsIds.Contains(selectedRestriction))
                {
                    _notyf.Error("Selected restriction/s doesn't exit");
                    return View(inputModel);
                }
            }

            var types = _gameService.GetGameTypes();
            var typesValues = types.Select(t => t.Value).ToHashSet();

            if (!typesValues.Contains((int)inputModel.Type))
            {
                _notyf.Error("Selected game is invalid");
                return View(inputModel);
            }

            //Try to add logic for checking if selected type, genres, platforms and restrictions exist
            bool isGameWithTitleAlreadyExist = await _gameService.GameExistByTitleAsync(inputModel.Title);

            if (isGameWithTitleAlreadyExist)
            {
                _notyf.Warning("Game with this Title already exist!");
                return View(inputModel);
            }

            if (!DateTime.TryParseExact(inputModel.CreatedOn, DateTimeFormat, CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime createdOn))
            {
                ModelState.AddModelError(nameof(inputModel.CreatedOn), InvalidDateTimeErrorMessage);
                return View(inputModel);
            }

            if (ModelState.IsValid == false)
            {
                return View(inputModel);
            }

            string? userId = User.GetId();
            string? moderatorId = await _moderatorService.GetModeratorIdByUserIdAsync(userId);

            string? gameId = await _gameService.AddGamePostAsync(inputModel, createdOn, moderatorId);

            _notyf.Success("Game was added successfully!");

            Log.Information("Moderator with ID {ModeratorId} perform an {Action} in controller {Controller}", moderatorId, nameof(Add), nameof(GameStoreController));

            return RedirectToAction(nameof(Details), new { id = gameId });
        }

        [MustBeModerator]
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            bool isGameExisting = await _gameService.GameExistByIdAsync(id);

            if (isGameExisting == false)
            {
                return NotFound();
            }

            string? userId = User.GetId();
            string? moderatorId = await _moderatorService.GetModeratorIdByUserIdAsync(userId);

            if (moderatorId == null)
            {
                return Unauthorized();
            }

            bool isModeratorCreatorOfTheGame = await _gameService.HasPublisherWithIdAsync(moderatorId, id);

            if (isModeratorCreatorOfTheGame == false)
            {
                return Unauthorized();
            }

            GameInputViewModel model = await _gameService.EditGameGetAsync(id, moderatorId);

            return View(model);
        }

        [MustBeModerator]
        [HttpPost]
        public async Task<IActionResult> Edit(GameInputViewModel inputModel, string id)
        {
            //Try to add logic for checking if selected type, genres, platforms and restrictions exist
            bool isGameExisting = await _gameService.GameExistByIdAsync(id);

            if (isGameExisting == false)
            {
                return NotFound();
            }

            if (!DateTime.TryParseExact(inputModel.CreatedOn, DateTimeFormat, CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime createdOn))
            {
                ModelState.AddModelError(nameof(inputModel.CreatedOn), InvalidDateTimeErrorMessage);
                return View(inputModel);
            }

            if (ModelState.IsValid == false)
            {
                return View(inputModel);
            }

            string? userId = User.GetId();
            string? moderatorId = await _moderatorService.GetModeratorIdByUserIdAsync(userId);

            if (moderatorId == null)
            {
                return Unauthorized();
            }

            bool isModeratorCreatorOfTheGame = await _gameService.HasPublisherWithIdAsync(moderatorId, id);

            if (isModeratorCreatorOfTheGame == false)
            {
                return Unauthorized();
            }

            string? gameId = await _gameService.EditGamePostAsync(inputModel, createdOn,id, moderatorId);

            _notyf.Success("Game was edited successfully!");

            Log.Information("Moderator with ID {ModeratorId} perform an {Action} in controller {Controller}", moderatorId, nameof(Edit), nameof(GameStoreController));

            return RedirectToAction(nameof(Details), new { id = gameId });
        }

        [MustBeModerator]
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            bool isGameExiting = await _gameService.GameExistByIdAsync(id);

            if (isGameExiting == false)
            {
                return NotFound();
            }

            string? userId = User.GetId();

            string? moderatorId = await _moderatorService.GetModeratorIdByUserIdAsync(userId);

            if (moderatorId == null)
            {
                return Unauthorized();
            }

            bool isCreatorOfTheGame = await _gameService.HasPublisherWithIdAsync(moderatorId, id);

            if (isCreatorOfTheGame == false)
            {
                return Unauthorized();
            }

            GameDeleteViewModel model = await _gameService.DeleteGameGetAsync(id, moderatorId);

            return View(model);
        }

        [MustBeModerator]
        [HttpPost]
        public async Task<IActionResult> DeleteConfirm(string id)
        {
            bool isGameExiting = await _gameService.GameExistByIdAsync(id);

            if (isGameExiting == false)
            {
                return NotFound();
            }

            string? userId = User.GetId();

            string? moderatorId = await _moderatorService.GetModeratorIdByUserIdAsync(userId);

            if (moderatorId == null)
            {
                return Unauthorized();
            }

            bool isCreatorOfTheGame = await _gameService.HasPublisherWithIdAsync(moderatorId, id);

            if (isCreatorOfTheGame == false)
            {
                return Unauthorized();
            }

            string? gameId = await _gameService.DeleteGamePostAsync(id, moderatorId);

            _notyf.Success("Game was deleted successfully!");

            Log.Information("Moderator with ID {ModeratorId} perform an {Action} in controller {Controller}", moderatorId, nameof(DeleteConfirm), nameof(GameStoreController));

            return RedirectToAction(nameof(Details), new { id = gameId });
        }
    }
}
