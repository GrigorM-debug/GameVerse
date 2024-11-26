﻿using System.Globalization;
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
    [OnlyUsersWithoutRoles]
    public class ReviewController(IGameService gameService, IReviewService reviewService, INotyfService notyf, ILogger<ReviewController> logger) : BaseController
    {
        private readonly IGameService _gameService = gameService;
        private readonly IReviewService _reviewService = reviewService;
        private readonly INotyfService _notyf = notyf;
        private readonly ILogger<ReviewController> _logger = logger;

        [HttpGet]
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
                return RedirectToAction("Details", "GameStore", new { id = gameId, area="" });
            }

            ReviewInputViewModel model = new ReviewInputViewModel();

            model.GameId = gameId;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
                return RedirectToAction("Details", "GameStore", new { id = gameId, area="" });
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

            bool isAddedSuccessfully = await _reviewService.AddReviewAsync(inputModel, userId, gameId, createdOn);

            if (isAddedSuccessfully)
            {
                _notyf.Success("Review successfully added");

                Log.Information("User with ID {UserId} perform {Action} in controller {Controller}", userId, nameof(Add), nameof(ReviewController));
            }

            return RedirectToAction("Details", "GameStore", new { id = gameId, area = "" });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id, string gameId)
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
                return RedirectToAction("Details", "GameStore", new { id = gameId, area="" });
            }

            ReviewInputViewModel model = await _reviewService.EditViewGetAsync(id, gameId, userId);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ReviewInputViewModel inputModel, string id, string gameId)
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
                return RedirectToAction("Details", "GameStore", new { id = gameId, area="" });
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

            bool isEditedSuccessfully = await _reviewService.EditReviewPostAsync(inputModel, createdOn, id, userId, gameId);

            if (isEditedSuccessfully)
            {
                _notyf.Success("Review successfully edited");

                Log.Information("User with ID {UserId} perform {Action} in controller {Controller}", userId, nameof(Edit), nameof(ReviewController));
            }

            return RedirectToAction("Details", "GameStore", new { id = gameId, area = "" });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id, string gameId)
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
                return RedirectToAction("Details", "GameStore", new { id = gameId, area="" });
            }

            ReviewDeleteViewModel model = await _reviewService.DeleteReviewGetAsync(id, userId, gameId);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(string id, string gameId)
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
                return RedirectToAction("Details", "GameStore", new { id = gameId, area="" });
            }

            bool isDeletedSuccessfully = await _reviewService.DeleteReviewPostAsync(id, userId, gameId);

            if (isDeletedSuccessfully)
            {
                _notyf.Success("Review successfully deleted");

                Log.Information("User with ID {UserId} perform {Action} in controller {Controller}", userId, nameof(DeleteConfirm), nameof(ReviewController));
            }

            return RedirectToAction("Details", "GameStore", new { id = gameId, area = "" });
        }
    }
}
