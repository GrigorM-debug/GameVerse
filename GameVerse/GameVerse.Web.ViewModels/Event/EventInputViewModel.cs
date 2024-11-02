using System.ComponentModel.DataAnnotations;
using System.Globalization;
using static GameVerse.Common.ApplicationConstants;

namespace GameVerse.Web.ViewModels.Event
{
    public class EventInputViewModel
    {
        [Required]
        [StringLength(EventConstants.TopicMaxLength, MinimumLength = EventConstants.TopicMinLength, ErrorMessage = LengthErrorMessage)]
        public string Topic { get; set; } = string.Empty;

        [Required]
        [StringLength(EventConstants.DescriptionMaxLength, MinimumLength = EventConstants.DescriptionMinLength, ErrorMessage = LengthErrorMessage)]
        public string Description {  get; set; } = string.Empty;

        public string StartDate { get; set; } = DateTime.Now.ToString(EventConstants.EventDateTimeFormat, CultureInfo.InvariantCulture);

        public string EndDate { get; set; } = DateTime.Now.AddHours(2).ToString(EventConstants.EventDateTimeFormat, CultureInfo.InvariantCulture);

        [Required]
        public double Latitude { get; set; }    

        [Required]
        public double Longitude { get; set; }

        [Required]
        [Range(EventConstants.SeatsMinValue, EventConstants.SeatsMaxValue , ErrorMessage = RangeErrorMessage)]
        public int Seats { get; set; }

        [Required]
        [Range(EventConstants.TicketPriceMinValue, EventConstants.TicketPriceMaxValue, ErrorMessage = RangeErrorMessage)]
        public decimal TicketPrice { get; set; }

        [Required]
        public string Image { get; set; } = string.Empty;
    }
}
