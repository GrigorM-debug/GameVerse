namespace GameVerse.Web.ViewModels.Game.Details.Reviews
{
    public class GameReviewsIndexViewModel
    {
        public string Content { get; set; } = null!;

        public int Rating { get; set; }

        public string CreatedOn { get; set; } = null!;

        public string Reviewer { get; set; } = null!;
    }
}
