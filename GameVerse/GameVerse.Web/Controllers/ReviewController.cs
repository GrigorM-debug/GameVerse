using System.Globalization;
using System.Runtime.InteropServices.JavaScript;
using AspNetCoreHero.ToastNotification.Abstractions;
using GameVerse.Data.Models.Games;
using GameVerse.Services.Interfaces;
using GameVerse.Web.Extensions;
using GameVerse.Web.Filters;
using GameVerse.Web.ViewModels.Game.Review;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Serilog;
using static GameVerse.Common.ApplicationConstants;

namespace GameVerse.Web.Controllers
{
    [Authorize]
    public class ReviewController(IGameService gameService, IReviewService reviewService, INotyfService notyf, ILogger<ReviewController> logger) : BaseController
    {
        private readonly IGameService _gameService = gameService;
        private readonly IReviewService _reviewService = reviewService;
        private readonly INotyfService _notyf = notyf;
        private readonly ILogger<ReviewController> _logger = logger;

        [HttpGet]
        [NotModerator]
        public async Task<IActionResult> Add(string gameId)
        {
            string? userId = User.GetId();

            if (userId == null)
            {
                _notyf.Error("Please log in");
                return Unauthorized();
            }

            bool isGameExisting = await _gameService.GameExistByIdAsync(gameId);

            if (!isGameExisting)
            {
                _notyf.Error("Game doesn't exist");
                return NotFound();
            }

            bool isReviewForGameAlreadyExist =
                await _reviewService.ReviewAlreadyExistByGameIdAndUserIdAsync(userId, gameId);

            if (isReviewForGameAlreadyExist)
            {
                _notyf.Error("You have already added review for this game");
                return RedirectToAction("Details", "GameStore", new { id = gameId });
            }

            ReviewInputViewModel model = new ReviewInputViewModel();

            model.GameId = gameId;

            return View(model);
        }

        [HttpPost]
        [NotModerator]
        public async Task<IActionResult> Add(ReviewInputViewModel inputModel, string gameId)
        {
            string? userId = User.GetId();

            if (userId == null)
            {
                _notyf.Error("Please log in");
                return Unauthorized();
            }

            bool isGameExisting = await _gameService.GameExistByIdAsync(gameId);

            if (!isGameExisting)
            {
                _notyf.Error("Game doesn't exist");
                return NotFound();
            }

            bool isReviewForGameAlreadyExist =
                await _reviewService.ReviewAlreadyExistByGameIdAndUserIdAsync(userId, gameId);

            if (isReviewForGameAlreadyExist)
            {
                _notyf.Error("You have already added review for this game");
                return RedirectToAction("Details", "GameStore", new { id = gameId });
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

            await _reviewService.AddReviewAsync(inputModel, userId, gameId, createdOn);

            _notyf.Success("Review successfully added");

            Log.Information("User with ID {UserId} perform {Action} in controller {Controller}", userId, nameof(Add), nameof(ReviewController));

            return RedirectToAction("Details", "GameStore", new { id = gameId });
        }

        [HttpGet]
        [NotModerator]
        public async Task<IActionResult> Edit(string reviewId, string gameId)
        {
            string? userId = User.GetId();

            if (userId == null)
            {
                _notyf.Error("Please log in");
                return Unauthorized();
            }

            bool isGameExisting = await _gameService.GameExistByIdAsync(gameId);

            if (!isGameExisting)
            {
                _notyf.Error("Game doesn't exist");
                return NotFound();
            }

            bool isReviewForGameAlreadyExist =
                await _reviewService.ReviewAlreadyExistByGameIdAndUserIdAsync(userId, gameId);

            if (!isReviewForGameAlreadyExist)
            {
                _notyf.Error("Review for this game doesn't exist");
                return RedirectToAction("Details", "GameStore", new { id = gameId });
            }

            ReviewInputViewModel model = await _reviewService.EditViewGetAsync(reviewId, gameId, userId);

            return View(model);
        }
    }
}
