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
            string? userId = User.GetId();
            string? moderatorId = await _moderatorService.GetModeratorIdByUserIdAsync(userId);

            if (moderatorId == null)
            {
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

            foreach(var selectedRestriction in inputModel.SelectedRestrictions)
            {
                if (!restrictionsIds.Contains(selectedRestriction))
                {
                    inputModel.GenreSelectList = genres;
                    inputModel.PlatformSelectList = platforms;
                    inputModel.RestrictionSelectList = restrictions;
                    inputModel.GameTypes = types;
                    ModelState.AddModelError(nameof(inputModel.SelectedRestrictions), "Selected restriction/s doesn't exist");
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
                ModelState.AddModelError(nameof(inputModel.GameTypes), "Selected game type is invalid");
                _notyf.Error("Selected game type is invalid");
                return View(inputModel);
            }

            bool isGameWithTitleAndTypeAlreadyExist = await _gameService.GameExistByTitleAndTypeAsync(inputModel.Title,
                inputModel.Type);

            if (isGameWithTitleAndTypeAlreadyExist)
            {
                inputModel.GenreSelectList = genres;
                inputModel.PlatformSelectList = platforms;
                inputModel.RestrictionSelectList = restrictions;
                inputModel.GameTypes = types;
                _notyf.Warning($"{inputModel.Type.ToString()} for {inputModel.Title} already exist!");
                return View(inputModel);
            }

            if (!DateTime.TryParseExact(inputModel.CreatedOn, DateTimeFormat, CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime createdOn))
            {
                inputModel.GenreSelectList = genres;
                inputModel.PlatformSelectList = platforms;
                inputModel.RestrictionSelectList = restrictions;
                inputModel.GameTypes = types;
                ModelState.AddModelError(nameof(inputModel.CreatedOn), InvalidDateTimeErrorMessage);
                return View(inputModel);
            }

            if (ModelState.IsValid == false)
            {
                inputModel.GenreSelectList = genres;
                inputModel.PlatformSelectList = platforms;
                inputModel.RestrictionSelectList = restrictions;
                inputModel.GameTypes = types;
                return View(inputModel);
            }

            string? gameId = await _gameService.AddGamePostAsync(inputModel, createdOn, moderatorId);

            await _moderatorService.IncreaseCreatedTotalGamesCount(moderatorId);

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
                _notyf.Warning("You don't have the permission to do this");
                return Unauthorized();
            }

            bool isModeratorCreatorOfTheGame = await _gameService.HasPublisherWithIdAsync(moderatorId, id);

            if (isModeratorCreatorOfTheGame == false)
            {
                _notyf.Warning("You are not the creator of the game");
                return Unauthorized();
            }

            GameInputViewModel model = await _gameService.EditGameGetAsync(id, moderatorId);

            return View(model);
        }

        [MustBeModerator]
        [HttpPost]
        public async Task<IActionResult> Edit(GameInputViewModel inputModel, string id)
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
                _notyf.Warning("You don't have the permission to do this");
                return Unauthorized();
            }

            bool isModeratorCreatorOfTheGame = await _gameService.HasPublisherWithIdAsync(moderatorId, id);

            if (isModeratorCreatorOfTheGame == false)
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
