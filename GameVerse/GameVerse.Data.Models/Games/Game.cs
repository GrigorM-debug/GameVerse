using GameVerse.Data.Models.GameUserActions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static GameVerse.Common.ApplicationConstants;

namespace GameVerse.Data.Models.Games
{
    public class Game
    {
        [Key]
        [Required]
        [Comment("The game unique indentifier.")]
        public Guid Id { get; set; }

        [Required]
        [StringLength(GameConstants.TitleMaxLength, MinimumLength = GameConstants.TitleMinLength, ErrorMessage = LengthErrorMessage)]
        [Comment("The name of the Game.")]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(GameConstants.DescriptionMaxLength, MinimumLength = GameConstants.DescriptionMinLength, ErrorMessage = LengthErrorMessage)]
        [Comment("The description of the Game")]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(GameConstants.PublishingStudioMaxLength, MinimumLength = GameConstants.PublishingStudioMinLength, ErrorMessage = LengthErrorMessage)]
        [Comment("The current Game's Publishing Studio")]
        public string PublishingStudio { get; set; } = null!;

        [Range(GameConstants.YearPublishedMinValue, GameConstants.YearPublishedMaxValue, ErrorMessage = RangeErrorMessage)]
        [Comment("The Year on which the Game was published")]
        public int YearPublished { get; set; }

        [Comment("The Date and Time when the Game is added")]
        public DateTime CreatedOn { get; set; }

        [Range(GameConstants.PriceMinValue, GameConstants.PriceMaxValue, ErrorMessage = RangeErrorMessage)]
        [Comment("The price of the Game")]
        public decimal Price { get; set; }

        [Comment("The image url of the game")]
        public string ImageUrl { get; set; } = null!;

        [Comment("The genre of the Game")]
        public Guid GenreId { get; set; }

        [Required]
        [ForeignKey(nameof(GenreId))]
        public Genre Genre { get; set; } = null!;

        public ICollection<GamePlatform> GamesPlatforms = new HashSet<GamePlatform>();

        public ICollection<GameReview> Reviews = new HashSet<GameReview>();

        public ICollection<WishlistItem> WishlistItems = new HashSet<WishlistItem>();


        //Add fields for Author which is Application User and Reviews 
    }
}
