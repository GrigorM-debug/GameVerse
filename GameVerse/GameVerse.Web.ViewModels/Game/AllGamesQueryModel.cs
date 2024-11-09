

using GameVerse.Common.Enums;

namespace GameVerse.Web.ViewModels.Game
{
    public class AllGamesQueryModel
    {
        public int CurrentPage { get; set; } = 1;

        public int GamesPerPage { get; set; } = 6;

        public int TotalGamesCount { get; set; }

        public string? SearchString { get; set; } = string.Empty;

        public EntitySortOrder GameSelectedSortOrder { get; set; } = EntitySortOrder.Newest;

        public IEnumerable<GameIndexViewModel> Games { get; set; } = new HashSet<GameIndexViewModel>();
    }
}
