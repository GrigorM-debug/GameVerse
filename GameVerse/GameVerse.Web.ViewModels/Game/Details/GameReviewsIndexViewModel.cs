namespace GameVerse.Web.ViewModels.Game.Details
{
    public class GameReviewsIndexViewModel
    {
        public string Id { get; set; } = null!;
        public string Content { get; set; } = null!;

        public int Rating { get; set; }

        public string CreatedOn { get; set; } = null!;

        public string Reviewer { get; set; } = null!;
    }
}
