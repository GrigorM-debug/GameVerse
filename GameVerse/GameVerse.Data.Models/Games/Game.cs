using GameVerse.Common.Enums;
using GameVerse.Data.Models.ApplicationUsers;
using GameVerse.Data.Models.Carts;
using GameVerse.Data.Models.Games.Genres;
using GameVerse.Data.Models.Games.Platform;
using GameVerse.Data.Models.Games.Restrictions;
using GameVerse.Data.Models.Games.Review;
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
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(GameConstants.TitleMaxLength, MinimumLength = GameConstants.TitleMinLength, ErrorMessage = LengthErrorMessage)]
        [Comment("The title of the Game.")]
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

        [Comment("The Date when the Game is added")]
        public DateTime CreatedOn { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Range(GameConstants.PriceMinValue, GameConstants.PriceMaxValue, ErrorMessage = RangeErrorMessage)]
        [Comment("The price of the Game")]
        public decimal Price { get; set; }

        [Comment("The image url of the game")]
        public string Image { get; set; } = null!;

        [Comment("Тhe available quantity of the game in the store")]
        public int QuantityInStock { get; set; }

        [Required]
        [EnumDataType(typeof(GameType), ErrorMessage = GameConstants.InvalidGameTypeErrorMessage)]
        [Comment("The type of the game.")]
        public GameType Type { get; set; }

        public Guid PublisherId { get; set; }

        [Required]
        [ForeignKey(nameof(PublisherId))]
        public ApplicationUser Publisher { get; set; } = null!;

        public ICollection<GamePlatform> GamesPlatforms = new HashSet<GamePlatform>();

        public ICollection<GameGenre> GamesGenres = new HashSet<GameGenre>();

        public ICollection<GameRestriction> GamesRestrictions = new HashSet<GameRestriction>();

        public ICollection<GameReview> Reviews = new HashSet<GameReview>();

        public ICollection<GameUserWishlist> WishlistItems = new HashSet<GameUserWishlist>(); 

        public ICollection<GameCart> GamesCarts = new HashSet<GameCart>();
    }
}
