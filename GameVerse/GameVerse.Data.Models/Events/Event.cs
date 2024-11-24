using GameVerse.Data.Models.ApplicationUsers;
using GameVerse.Data.Models.Carts;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GameVerse.Common.Enums;
using static GameVerse.Common.ApplicationConstants;

namespace GameVerse.Data.Models.Events
{
    /// <summary>
    /// Represents an event within the GameVerse application.
    /// </summary>
    [Comment("Gaming Event")]
    public class Event
    {
        /// <summary>
        /// Gets or sets the unique identifier for the event.
        /// </summary>
        /// <remarks>
        /// This is a required field and is initialized with a new <see cref="Guid"/> when a new event is created.
        /// </remarks>
        [Key]
        [Required]
        [Comment("The event unique identifier")]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Gets or sets the topic of the event.
        /// </summary>
        /// <remarks>
        /// This is a required field with string length constraints defined by <see cref="EventConstants.TopicMaxLength"/> 
        /// and <see cref="EventConstants.TopicMinLength"/>.
        /// </remarks>
        [Required]
        [StringLength(EventConstants.TopicMaxLength, MinimumLength = EventConstants.TopicMinLength, ErrorMessage = LengthErrorMessage)]
        [Comment("The topic of the event")]
        public string Topic { get; set; } = null!;

        /// <summary>
        /// Gets or sets the description of the event.
        /// </summary>
        /// <remarks>
        /// This is a required field with string length constraints defined by <see cref="EventConstants.DescriptionMaxLength"/> 
        /// and <see cref="EventConstants.DescriptionMinLength"/>.
        /// </remarks>
        [Required]
        [StringLength(EventConstants.DescriptionMaxLength, MinimumLength = EventConstants.DescriptionMinLength, ErrorMessage = LengthErrorMessage)]
        [Comment("The description of the event")]
        public string Description { get; set; } = null!;

        /// <summary>
        /// Gets or sets the starting date and time of the event.
        /// </summary>
        /// <remarks>
        /// This is a required field that specifies when the event begins.
        /// </remarks>
        [Required]
        [Comment("The event starting date and time")]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the ending date and time of the event.
        /// </summary>
        /// <remarks>
        /// This is a required field that specifies when the event ends.
        /// </remarks>
        [Required]
        [Comment("The event end date and time")]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or sets the latitude coordinate for the event location.
        /// </summary>
        /// <remarks>
        /// This is a required field representing the width coordinate of the event's location.
        /// </remarks>
        [Required]
        [Comment("Event location width coordinate")]
        public double Latitude { get; set; }  // Width

        /// <summary>
        /// Gets or sets the longitude coordinate for the event location.
        /// </summary>
        /// <remarks>
        /// This is a required field representing the length coordinate of the event's location.
        /// </remarks>
        [Required]
        [Comment("Event location length coordinate")]
        public double Longitude { get; set; } // Length

        /// <summary>
        /// Gets or sets the number of seats available for the event.
        /// </summary>
        /// <remarks>
        /// This field is optional and indicates how many seats are available for participants.
        /// </remarks>
        [Required]
        [Comment("The event's number of seats")]
        public int Seats { get; set; }

        /// <summary>
        /// Gets or sets the ticket price for the event.
        /// </summary>
        /// <remarks>
        /// This field is optional and is a decimal type with constraints defined by <see cref="EventConstants.TicketPriceMinValue"/> 
        /// and <see cref="EventConstants.TicketPriceMaxValue"/>.
        /// </remarks>
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Range(EventConstants.TicketPriceMinValue, EventConstants.TicketPriceMaxValue, ErrorMessage = RangeErrorMessage, ConvertValueInInvariantCulture = true)]
        [Comment("The price for ticket")]
        public decimal TicketPrice { get; set; }

        /// <summary>
        /// Gets or sets the image URL for the event.
        /// </summary>
        /// <remarks>
        /// This is a required field that specifies the URL of an image related to the event.
        /// </remarks>
        [Required]
        [Comment("The event image url")]
        public string Image { get; set; } = null!;

        /// <summary>
        /// Gets or sets the unique identifier for the event's publisher.
        /// </summary>
        /// <remarks>
        /// This is a required field that links the event to its publisher.
        /// </remarks>
        [Required]
        [Comment("The event's publisher unique id")]
        public Guid PublisherId { get; set; }

        /// <summary>
        /// Gets or sets the moderator who publishes the event.
        /// </summary>
        /// <remarks>
        /// This is a required field that establishes a foreign key relationship with the <see cref="Moderator"/> entity.
        /// </remarks>
        [Required]
        [ForeignKey(nameof(PublisherId))]
        public Moderator Publisher { get; set; } = null!;


        /// <summary>
        /// Gets or sets a value indicating whether the event has been soft deleted.
        /// </summary>
        /// <remarks>
        /// This field is used for marking events as deleted without removing them from the database.
        /// </remarks>
        [Required]
        [Comment("Soft Delete flag")]
        public bool IsDeleted { get; set; }


        /// <summary>
        /// Gets or sets the collection of shopping cart entries associated with the event.
        /// </summary>
        /// <remarks>
        /// This collection allows multiple users to add the event to their shopping carts.
        /// </remarks>
        public ICollection<EventCart> EventsCarts { get; set; } = new HashSet<EventCart>();
    }
}
