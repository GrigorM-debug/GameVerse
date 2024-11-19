

namespace GameVerse.Web.ViewModels.Game.UserPagesViewModels
{
    public class UserBoughtGamesViewModel
    {
        public string GameId { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string Image { get; set; } = null!;

        public string BoughtOn { get; set; } = null!;

        public string Price { get; set; } = null!;

        public int Quantity { get; set; }

        public string Type { get; set; } = null!;
    }
}
