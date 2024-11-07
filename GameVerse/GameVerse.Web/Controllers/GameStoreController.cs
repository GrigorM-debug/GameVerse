using AspNetCoreHero.ToastNotification.Abstractions;
using GameVerse.Services.Interfaces;
using GameVerse.Web.Filters;
using GameVerse.Web.ViewModels.Game;
using GameVerse.Web.ViewModels.Game.Details;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public Task<IActionResult> Add()
        {
            return View();
        }

        [MustBeModerator]
        [HttpPost]
        public Task<IActionResult> Add(GameInputViewModel inputModel)
        {
            
        }

        [MustBeModerator]
        [HttpGet]
        public Task<IActionResult> Edit(string id)
        {

        }

        [MustBeModerator]
        [HttpPost]
        public Task<IActionResult> Edit(GameInputViewModel inputModel, string id)
        {

        }

        [MustBeModerator]
        [HttpGet]
        public Task<IActionResult> Delete(string id)
        {

        }

        [MustBeModerator]
        [HttpPost]
        public Task<IActionResult> DeleteConfirm(string id)
        {

        }
    }
}
