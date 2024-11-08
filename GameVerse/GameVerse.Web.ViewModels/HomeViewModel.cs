

using GameVerse.Web.ViewModels.Event;
using GameVerse.Web.ViewModels.Game;

namespace GameVerse.Web.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<EventIndexViewModel> Last3Events = new HashSet<EventIndexViewModel>();

        public IEnumerable<GameIndexViewModel> Last3Games = new HashSet<GameIndexViewModel>();
    }
}
