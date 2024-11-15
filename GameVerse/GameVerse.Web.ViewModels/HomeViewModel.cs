

using GameVerse.Web.ViewModels.Event;
using GameVerse.Web.ViewModels.Game;

namespace GameVerse.Web.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<EventIndexViewModel> Last3Events { get; set; } = new HashSet<EventIndexViewModel>();

        public IEnumerable<GameIndexViewModel> Last3Games { get; set; } = new HashSet<GameIndexViewModel>();
    }
}
