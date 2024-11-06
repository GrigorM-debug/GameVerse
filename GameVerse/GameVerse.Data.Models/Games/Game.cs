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
    /// <summary>
    /// Represents a game within the GameVerse system, containing details such as title, description, 
    /// publishing studio, release year, price, and associations with platforms, genres, and restrictions.
    /// </summary>
    [Comment("Game to Buy")]
    public class Game
    {
        /// <summary>
        /// Gets or sets the unique identifier for the game.
        /// </summary>
        [Key]
        [Required]
        [Comment("The game unique identifier.")]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Gets or sets the title of the game.
        /// </summary>
        /// <remarks>
        /// This is a required field, with length constraints defined by <see cref="GameConstants.TitleMaxLength"/> and <see cref="GameConstants.TitleMinLength"/>.
        /// </remarks>
        [Required]
        [StringLength(GameConstants.TitleMaxLength, MinimumLength = GameConstants.TitleMinLength, ErrorMessage = LengthErrorMessage)]
        [Comment("The title of the Game.")]
        public string Title { get; set; } = null!;

        /// <summary>
        /// Gets or sets the description of the game.
        /// </summary>
        ///<remarks>
        /// This is a required field, with length constraints defined by <see cref="GameConstants.DescriptionMaxLength"/> and <see cref="GameConstants.DescriptionMinLength"/>.
        /// </remarks>
        [Required]
        [StringLength(GameConstants.DescriptionMaxLength, MinimumLength = GameConstants.DescriptionMinLength, ErrorMessage = LengthErrorMessage)]
        [Comment("The description of the Game")]
        public string Description { get; set; } = null!;

        /// <summary>
        /// Gets or sets the publishing studio for the game.
        /// </summary>
        /// <remarks>
        /// This is a required field, with length constraints defined by <see cref="GameConstants.PublishingStudioMaxLength"/> and <see cref="GameConstants.PublishingStudioMinLength"/>.
        /// </remarks>
        [Required]
        [StringLength(GameConstants.PublishingStudioMaxLength, MinimumLength = GameConstants.PublishingStudioMinLength, ErrorMessage = LengthErrorMessage)]
        [Comment("The current Game's Publishing Studio")]
        public string PublishingStudio { get; set; } = null!;

        /// <summary>
        /// Gets or sets the year the game was published.
        /// </summary>
        /// <remarks>
        /// This is a required field, with length constraints defined by <see cref="GameConstants.YearPublishedMinValue"/> and <see cref="GameConstants.YearPublishedMaxValue"/>.
        /// </remarks>
        [Range(GameConstants.YearPublishedMinValue, GameConstants.YearPublishedMaxValue, ErrorMessage = RangeErrorMessage)]
        [Comment("The Year on which the Game was published")]
        public int YearPublished { get; set; }

        /// <summary>
        /// Gets or sets the date when the game was added to the system.
        /// </summary>
        ///<remarks>
        /// This is a required field, with format constraint defined by <see cref="DateTimeFormat"/> 
        /// </remarks>
        [Required]
        [Comment("The Date when the Game is added")]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the price of the game.
        /// </summary>
        /// <remarks>
        /// This is a required field, with range constraints defined by <see cref="GameConstants.PriceMinValue"/> and <see cref="GameConstants.PriceMaxValue"/>.
        /// </remarks>
        [Column(TypeName = "decimal(18, 2)")]
        [Range(GameConstants.PriceMinValue, GameConstants.PriceMaxValue, ErrorMessage = RangeErrorMessage, ConvertValueInInvariantCulture = true)]
        [Comment("The price of the Game")]
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the image URL for the game's cover or promotional image.
        /// </summary>
        [Required]
        [Comment("The image url of the game")]
        public string Image { get; set; } = null!;

        /// <summary>
        /// Gets or sets the available quantity of the game in stock.
        /// </summary>
        [Comment("Тhe available quantity of the game in the store")]
        public int QuantityInStock { get; set; }

        /// <summary>
        /// Gets or sets the type of the game, which must be a valid <see cref="GameType"/> enum value.
        /// </summary>
        [Required]
        [EnumDataType(typeof(GameType), ErrorMessage = GameConstants.InvalidGameTypeErrorMessage)]
        [Comment("The type of the game.")]
        public GameType Type { get; set; }

        [Required]
        [Comment("Soft delete flag")]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the publisher of the game.
        /// </summary>
        [Required]
        [Comment("The game publisher unique identifier")]
        public Guid PublisherId { get; set; }

        /// <summary>
        /// Gets or sets the publisher of the game.
        /// </summary>
        [Required]
        [ForeignKey(nameof(PublisherId))]
        public Moderator Publisher { get; set; } = null!;

        /// <summary>
        /// Gets or sets the unique identifier for the buyer of the game.
        /// </summary>
        [Comment("The game buyer unique identifier")]
        public Guid? BuyerId { get; set; }

        /// <summary>
        /// Gets or sets the buyer of the game.
        /// </summary>
        [ForeignKey(nameof(BuyerId))]
        public ApplicationUser? Buyer { get; set; }

        /// <summary>
        /// Gets or sets the collection of platforms the game is available on.
        /// </summary>
        public ICollection<GamePlatform> GamesPlatforms = new HashSet<GamePlatform>();

        /// <summary>
        /// Gets or sets the collection of genres associated with the game.
        /// </summary>
        public ICollection<GameGenre> GamesGenres = new HashSet<GameGenre>();

        /// <summary>
        /// Gets or sets the collection of restrictions applied to the game.
        /// </summary>
        public ICollection<GameRestriction> GamesRestrictions = new HashSet<GameRestriction>();

        /// <summary>
        /// Gets or sets the collection of reviews for the game.
        /// </summary>
        public ICollection<GameReview> Reviews = new HashSet<GameReview>();

        /// <summary>
        /// Gets or sets the collection of wishlist items where the game is added by users.
        /// </summary>
        public ICollection<GameUserWishlist> WishlistItems = new HashSet<GameUserWishlist>();

        /// <summary>
        /// Gets or sets the collection of cart items where the game is added by users.
        /// </summary>
        public ICollection<GameCart> GamesCarts = new HashSet<GameCart>();
    }
}
