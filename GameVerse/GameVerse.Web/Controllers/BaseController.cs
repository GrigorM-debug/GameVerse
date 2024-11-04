using System.Globalization;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace GameVerse.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected bool IsGuidValid(string? id, ref Guid guidId)
        {
            if (String.IsNullOrEmpty(id)) return false;

            if (!Guid.TryParse(id, out guidId)) return false;

            return true;
        }

    }
}

