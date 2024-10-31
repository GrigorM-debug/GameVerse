using Microsoft.AspNetCore.Mvc;

namespace GameVerse.Web.Controllers
{
    public class EventController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
