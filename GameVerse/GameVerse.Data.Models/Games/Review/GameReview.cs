using GameVerse.Data.Models.ApplicationUsers;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static GameVerse.Common.ApplicationConstants;

namespace GameVerse.Data.Models.Games.Review
{
    /// <summary>
    /// Represents a review for a game within the GameVerse system.
    /// </summary>
    [Comment("Game Review")]
    public class GameReview
    {
        /// <summary>
        /// Gets or sets the unique identifier for the review.
        /// </summary>
        /// <remarks>
        /// This is a required field and is initialized with a new <see cref="Guid"/> when a new review is created.
        /// </remarks>
        [Key]
        [Required]
        [Comment("The review unique identifier")]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Gets or sets the content of the review.
        /// </summary>
        /// <remarks>
        /// This is a required field with string length constraints defined by <see cref="ReviewConstants.ContentMaxLength"/> and <see cref="ReviewConstants.ContentMinLength"/>.
        /// </remarks>
        [Required]
        [StringLength(ReviewConstants.ContentMaxLength, MinimumLength = ReviewConstants.ContentMinLength, ErrorMessage = LengthErrorMessage)]
        [Comment("The content of the review")]
        public string Content { get; set; } = null!;

        /// <summary>
        /// Gets or sets the rating given in the review.
        /// </summary>
        /// <remarks>
        /// This is a required field with range constraints defined by <see cref="ReviewConstants.RatingMinValue"/> and <see cref="ReviewConstants.RatingMaxValue"/>.
        /// </remarks>
        [Required]  
        [Range(ReviewConstants.RatingMinValue, ReviewConstants.RatingMaxValue, ErrorMessage = RangeErrorMessage)]
        [Comment("The review rating")]
        public int Rating { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the review was created.
        /// </summary>
        /// <remarks>
        /// This is a required field that records the creation timestamp of the review.
        /// </remarks>
        [Required]
        [Comment("The date and time when the review is created")]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the game that the review is about.
        /// </summary>
        /// <remarks>
        /// This is a required field that links the review to the specific game.
        /// </remarks>
        [Required]
        [Comment("Тhe id of the game the review is about")]
        public Guid GameId { get; set; }

        /// <summary>
        /// Gets or sets the game associated with this review.
        /// </summary>
        [Required]
        [ForeignKey(nameof(GameId))]
        public Game Game { get; set; } = null!;

        /// <summary>
        /// Gets or sets the unique identifier of the user who wrote the review.
        /// </summary>
        /// <remarks>
        /// This is a required field that links the review to the user who created it.
        /// </remarks>
        [Required]
        [Comment("The id of the User who wrote the review for the current game")]
        public Guid ReviewerId { get; set; }

        /// <summary>
        /// Gets or sets the user who authored the review.
        /// </summary>
        [Required]
        [ForeignKey(nameof(ReviewerId))]
        public ApplicationUser Reviewer { get; set; } = null!;
    }
}
