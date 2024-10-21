using Microsoft.AspNetCore.Mvc;

namespace GameVerse.Web.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
