
namespace GameVerse.Web.Areas.Moderator.Models
{
    public class ModeratorIndexViewModel
    {
        public int TotalGamesCreated { get; set; }

        public int TotalEventsCreated { get; set; }

        public IEnumerable<ModeratorGameIndexViewModel> Last5CreatedGames { get; set; } =
            new HashSet<ModeratorGameIndexViewModel>();

        public IEnumerable<ModeratorEventIndexViewModel> Last5CreatedEvents { get; set; } = new HashSet<ModeratorEventIndexViewModel>();
    }
}
