using AspNetCoreHero.ToastNotification.Abstractions;
using GameVerse.Data.Models.Games;
using GameVerse.Services.Interfaces;
using GameVerse.Web.Extensions;
using GameVerse.Web.ViewModels.Game.Review;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

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
        public async Task<IActionResult> Add(string gameId)
        {
            string? userId = User.GetId();

            if (userId == null)
            {
                _notyf.Error("Please log in");
                return Unauthorized();
            }

            bool isGameExisting = await _gameService.GameExistByIdAsync(gameId);

            if (isGameExisting)
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

            return View(model);
        }
    }
}
