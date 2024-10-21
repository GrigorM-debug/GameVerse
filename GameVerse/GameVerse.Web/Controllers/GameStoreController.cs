using Microsoft.AspNetCore.Mvc;

namespace GameVerse.Web.Controllers
{
    public class GameStoreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
