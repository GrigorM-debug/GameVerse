using GameVerse.Data.Models.ApplicationUsers;
using GameVerse.Data.Models.Carts;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static GameVerse.Common.ApplicationConstants;

namespace GameVerse.Data.Models.Events
{
    public class Event
    {
        [Key]
        [Required]
        [Comment("The event unique identifier")]
        public Guid Id { get; set; } = Guid.NewGuid();

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

        public double Latitude { get; set; }  // Width
        public double Longitude { get; set; } // Length

        [Comment("The event's number of seats")]
        public int Seats { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Range(EventConstants.TicketPriceMinValue, EventConstants.TicketPriceMaxValue, ErrorMessage = RangeErrorMessage)]
        [Comment("The price for ticket")]
        public decimal TicketPrice { get; set; }

        [Required]
        [Comment("The event image url")]
        public string Image { get; set; } = null!;

        [Comment("The event's publisher unique id")]
        public Guid PublisherId { get; set; }

        [Required]
        [ForeignKey(nameof(PublisherId))]
        public ApplicationUser Publisher { get; set; } = null!;

        public ICollection<EventCart> EventsCarts { get; set; } = new HashSet<EventCart>();
    }
}
