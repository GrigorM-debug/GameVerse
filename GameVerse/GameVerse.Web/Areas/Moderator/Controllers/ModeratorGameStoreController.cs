using AspNetCoreHero.ToastNotification.Abstractions;
using GameVerse.Services;
using GameVerse.Services.Interfaces;
using GameVerse.Web.Controllers;
using GameVerse.Web.Extensions;
using GameVerse.Web.ViewModels.Game;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Serilog;
using System.Globalization;
using GameVerse.Data.Models.Games;
using GameVerse.Web.Areas.Moderator.Models;
using static GameVerse.Common.ApplicationConstants;

namespace GameVerse.Web.Areas.Moderator.Controllers
{
    [Area("Moderator")]
    [Authorize(Roles = "Moderator")]
    public class ModeratorGameStoreController(
        ILogger<ModeratorGameStoreController> _logger,
        INotyfService _notyf,
        IModeratorService _moderatorService,
        IGameService _gameService,
        IImageValidationService _imageValidationService
        ) : Controller
    {

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            GameInputViewModel model = await _gameService.AddGameGetAsync();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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

            foreach (var selectedRestriction in inputModel.SelectedRestrictions)
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

            try
            {
                bool isImageValid = await _imageValidationService.ValidateImageWithApi(inputModel.Image);

                if (!isImageValid)
                {
                    inputModel.GenreSelectList = genres;
                    inputModel.PlatformSelectList = platforms;
                    inputModel.RestrictionSelectList = restrictions;
                    inputModel.GameTypes = types;
                    _notyf.Error("The image contains irrelevant content.");
                    ModelState.AddModelError(nameof(inputModel.Image), "The image contains irrelevant content.");
                    return View(inputModel);
                }
            }
            catch (InvalidOperationException ex)
            {
                _notyf.Error("An error occured while validating image");
                Log.Error("An error occured while validating image with message {Error} in {Action} in {Controller}", ex.Message, nameof(Add), nameof(ModeratorGameStoreController));
                inputModel.GenreSelectList = genres;
                inputModel.PlatformSelectList = platforms;
                inputModel.RestrictionSelectList = restrictions;
                inputModel.GameTypes = types;
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

            Log.Information("Moderator with ID {ModeratorId} perform an {Action} action in controller {Controller}", moderatorId, nameof(Add), nameof(GameStoreController));

            return RedirectToAction("Details", "GameStore", new { id = gameId, area = "" });
        }

        [HttpGet]
        public async Task<IActionResult> AddGameQuantityInStock(string gameId)
        {
            string? userId = User.GetId();
            string? moderatorId = await _moderatorService.GetModeratorIdByUserIdAsync(userId);

            if (moderatorId == null)
            {
                return Unauthorized();
            }

            Game? game = await _gameService.GetGameByIdAsTrackingAsync(gameId);

            if (game == null)
            {
                return NotFound();
            }

            bool isCreatorOfTheGame = await _gameService.HasPublisherWithIdAsync(moderatorId, gameId);

            if (!isCreatorOfTheGame)
            {
                _notyf.Error("You are not the creator of the game.");
                return RedirectToAction("Details", "GameStore", new { id = gameId, area = "" });
            }

            if (game.QuantityInStock > 0)
            {
                _notyf.Error("You cannot add stock to a game that is not out of stock.");
                return RedirectToAction("Details", "GameStore", new { id = gameId, area = "" });
            }

            AddQuantityInStockInputViewModel model = new AddQuantityInStockInputViewModel()
            {
                GameId = game.Id.ToString(),
                CreatedOn = game.CreatedOn.ToString(DateTimeFormat, CultureInfo.InvariantCulture),
                Title = game.Title
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddGameQuantityInStock(AddQuantityInStockInputViewModel inputModel)
        {
            string? userId = User.GetId();
            string? moderatorId = await _moderatorService.GetModeratorIdByUserIdAsync(userId);

            if (moderatorId == null)
            {
                return Unauthorized();
            }

            Game? game = await _gameService.GetGameByIdAsTrackingAsync(inputModel.GameId);

            if (game == null)
            {
                return NotFound();
            }

            string gameId = game.Id.ToString();
            bool isCreatorOfTheGame = await _gameService.HasPublisherWithIdAsync(moderatorId, gameId);

            if (!isCreatorOfTheGame)
            {
                _notyf.Error("You are not the creator of the game.");
                return RedirectToAction("Details", "GameStore", new { id = gameId, area = "" });
            }

            if (game.QuantityInStock > 0)
            {
                _notyf.Error("You cannot add stock to a game that is not out of stock.");
                return View(inputModel);
            }

            if (ModelState.IsValid == false)
            {
                return View(inputModel);
            }


            await _gameService.UpdateGameQuantityInStockAsync(gameId, inputModel.QuantityInStock);

            _notyf.Success("Quantity successfully added to the stock.");

            Log.Information("Moderator with ID {ModeratorID} perform {Action} in {Controller}", moderatorId, nameof(AddGameQuantityInStock), nameof(ModeratorGameStoreController));

            return RedirectToAction("Details", "GameStore", new { id = gameId, area="" });
        }
    }
}
