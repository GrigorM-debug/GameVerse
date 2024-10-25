
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GameVerse.Data.Models
{
    public class Event
    {
        [Key]
        [Required]
        [Comment("The event unique identifier")]
        public Guid Id { get; set; }

        [Required]
        [Comment("The topic of the event")]
        public string Topic { get; set; } = null!;

        [Required]
        [Comment("The description of the event")]
        public string Description { get; set; } = null!;

        [Comment("The event starting date and time")]
        public DateTime StartDate { get; set; }

        [Comment("The event end date and time")]
        public DateTime EndDate { get; set; }

        [Required]
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
