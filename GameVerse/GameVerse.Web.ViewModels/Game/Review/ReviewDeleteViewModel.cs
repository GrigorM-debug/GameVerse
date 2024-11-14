

namespace GameVerse.Web.ViewModels.Game.Review
{
    public class ReviewDeleteViewModel
    {
        public string Id { get; set; } = null!;

        public string Content { get; set; } = null!;

        public int Rating { get; set; }

        public string ReviewerId { get; set; } = null!;

        public string ReviewerName { get; set;} = null!;

        public string CreatedOn { get; set; } = null!;

        public string GameName { get; set; } = null!;

        public string GameId { get; set; } = null!;
    }
}
