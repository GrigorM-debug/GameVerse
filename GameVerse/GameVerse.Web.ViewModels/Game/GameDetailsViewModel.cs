
using GameVerse.Web.ViewModels.Game.Platforms;
using GameVerse.Web.ViewModels.Game.Restrictions;
using GameVerse.Web.ViewModels.Game.Reviews;

namespace GameVerse.Web.ViewModels.Game
{
    public class GameDetailsViewModel
    {
        public string Id { get; set; } = null!; 

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string PublishingStudio { get; set; } = null!;

        public int YearPublished { get; set; }

        public string CreatedOn { get; set; } = null!;

        public string Price { get; set; } = null!;

        public string Image { get; set; } = null!;

        public int QuantityInStock { get; set; }

        public string Type { get; set; } = null!;

        public string Publisher { get; set; } = null!;

        public IEnumerable<GamePlatformsIndexViewModel> Platforms = new HashSet<GamePlatformsIndexViewModel>();
        
        public IEnumerable<GameRestrictionsIndexViewModel> Restrictions = new HashSet<GameRestrictionsIndexViewModel>();

        public IEnumerable<GameReviewsIndexViewModel> Reviews = new HashSet<GameReviewsIndexViewModel>();
    }
}
