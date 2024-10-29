using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static GameVerse.Common.ApplicationConstants;

namespace GameVerse.Data.Models.Games.Review
{
    public class GameReview
    {
        [Key]
        [Required]
        [Comment("The review unique identifier")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(ReviewConstants.ContentMaxLength, MinimumLength = ReviewConstants.ContentMinLength, ErrorMessage = LengthErrorMessage)]
        [Comment("The content of the review")]
        public string Content { get; set; } = null!;

        [Range(ReviewConstants.RatingMinValue, ReviewConstants.RatingMaxValue, ErrorMessage = RangeErrorMessage)]
        [Comment("The review rating")]
        public int Rating { get; set; }

        [Comment("The date and time when the review is created")]
        public DateTime CreatedOn { get; set; }

        [Comment("Тhe id of the game the review is about")]
        public Guid GameId { get; set; }

        [Required]
        [ForeignKey(nameof(GameId))]
        public Game Game { get; set; } = null!;

        [Comment("The id of the User who wrote the review for the current game")]
        public Guid ReviewerId { get; set; }

        [Required]
        [ForeignKey(nameof(ReviewerId))]
        public ApplicationUser Reviewer { get; set; } = null!;
    }
}
