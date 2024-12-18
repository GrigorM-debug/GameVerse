﻿namespace GameVerse.Web.ViewModels.Game.Details
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

        public double? AverageRating { get; set; }

        public IEnumerable<GenreIndexViewModel> Genres { get; set; } = new HashSet<GenreIndexViewModel>();

        public IEnumerable<GamePlatformsIndexViewModel> Platforms { get; set; } = new HashSet<GamePlatformsIndexViewModel>();

        public IEnumerable<GameRestrictionsIndexViewModel> Restrictions { get; set; } = new HashSet<GameRestrictionsIndexViewModel>();

        public IEnumerable<GameReviewsIndexViewModel> Reviews { get; set; } = new HashSet<GameReviewsIndexViewModel>();
    }
}
