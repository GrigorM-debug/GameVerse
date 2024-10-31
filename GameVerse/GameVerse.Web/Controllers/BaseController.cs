using Microsoft.AspNetCore.Mvc;

namespace GameVerse.Web.Controllers
{
    public class BaseController : Controller
    {
        public bool IsGuidValid(string? id, ref Guid guidId)
        {
            if (String.IsNullOrEmpty(id)) return false;

            if (!Guid.TryParse(id, out guidId)) return false;

            return true;
        }
    }
}
