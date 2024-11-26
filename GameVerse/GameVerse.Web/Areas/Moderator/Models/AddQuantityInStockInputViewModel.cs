using System.ComponentModel.DataAnnotations;
using static GameVerse.Common.ApplicationConstants;
using static GameVerse.Common.ApplicationConstants.GameConstants;

namespace GameVerse.Web.Areas.Moderator.Models
{
    public class AddQuantityInStockInputViewModel
    {
        public string GameId { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string CreatedOn { get; set; } = null!;

        [Required]
        [Range(QuantityInStockMinValue, QuantityInStockMaxValue, ErrorMessage = RangeErrorMessage)]
        public int QuantityInStock { get; set; }
    }
}
