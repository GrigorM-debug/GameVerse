using GameVerse.Web.Filters;
using GameVerse.Web.ViewModels.Game;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameVerse.Web.Controllers
{
    [Authorize]
    public class GameStoreController : Controller
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Details(string id)
        {
            return View();
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
