using GameVerse.Web.Areas.Moderator.Models;
using GameVerse.Web.Areas.Moderator.Services.Interfaces;
using GameVerse.Web.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameVerse.Web.Areas.Moderator.Controllers
{
    [Area("Moderator")]
    [Authorize(Roles = "Moderator")]
    public class ModeratorController(IModeratorService _moderatorService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Dashboard()
        {
            ModeratorIndexViewModel model = new ModeratorIndexViewModel()
            {
                TotalEventsCreated = await _moderatorService.TotalEventsCreatedAsync(User.GetId()),
                TotalGamesCreated = await _moderatorService.TotalGamesCreatedAsync(User.GetId()),
                Last5CreatedEvents = await _moderatorService.GetLast5CreatedEventsAsync(User.GetId()),
                Last5CreatedGames = await _moderatorService.GetLast5CreatedGamesAsync(User.GetId())
            };

            return View(model);
        }
    }
}
