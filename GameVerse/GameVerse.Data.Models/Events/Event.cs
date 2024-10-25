using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static GameVerse.Common.ApplicationConstants;

namespace GameVerse.Data.Models.Events
{
    public class Event
    {
        [Key]
        [Required]
        [Comment("The event unique identifier")]
        public Guid Id { get; set; }

        [Required]
        [StringLength(EventConstants.TopicMaxLength, MinimumLength = EventConstants.TopicMinLength, ErrorMessage = LengthErrorMessage)]
        [Comment("The topic of the event")]
        public string Topic { get; set; } = null!;

        [Required]
        [StringLength(EventConstants.DescriptionMaxLength, MinimumLength = EventConstants.DescriptionMinLength, ErrorMessage = LengthErrorMessage)]
        [Comment("The description of the event")]
        public string Description { get; set; } = null!;

        [Comment("The event starting date and time")]
        public DateTime StartDate { get; set; }

        [Comment("The event end date and time")]
        public DateTime EndDate { get; set; }

        [Required]
        [StringLength(EventConstants.LocationMaxLength, MinimumLength = EventConstants.LocationMinLength, ErrorMessage = LengthErrorMessage)]
        [Comment("The event location")]
        public string Location { get; set; } = null!;

        [Comment("The event's number of seats")]
        public int Seats { get; set; }

        [Comment("The price for ticket")]
        public decimal TicketPrice { get; set; }

        [Required]
        [Comment("The event image url")]
        public string ImageUrl { get; set; } = null!;


    }
}
