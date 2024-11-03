

using GameVerse.Web.ViewModels.Event;

namespace GameVerse.Web.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<EventIndexViewModel> Last3Events = new HashSet<EventIndexViewModel>();
    }
}
