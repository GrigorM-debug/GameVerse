
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using static GameVerse.Common.ApplicationConstants;
using static GameVerse.Common.ApplicationConstants.ReviewConstants;
namespace GameVerse.Web.ViewModels.Game.Review
{
    public class ReviewInputViewModel
    {
        [Required]
        [StringLength(ContentMaxLength, MinimumLength = ContentMinLength, ErrorMessage = LengthErrorMessage)]
        public string Content { get; set; } = string.Empty;

        [Required]
        [Range(RatingMinValue, RatingMaxValue, ErrorMessage = RangeErrorMessage)]
        public int Rating { get; set; }

        [Required]
        public string CreatedOn { get; set; } = DateTime.Now.ToString(DateTimeFormat, CultureInfo.InvariantCulture);
    }
}
