using GameVerse.Data.Models.Events;
using GameVerse.Data.Models.Games;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameVerse.Data.Models.ApplicationUsers
{
    /// <summary>
    /// Represents a moderator within the GameVerse system.
    /// </summary>
    [Comment("Moderator in GameVerse System")]
    public class Moderator
    {
        /// <summary>
        /// Gets or sets the unique identifier for the moderator.
        /// </summary>
        /// <remarks>
        /// This is a required field and is initialized with a new <see cref="Guid"/> when a new moderator is created.
        /// </remarks>
        [Key]
        [Required]
        [Comment("Moderator unique identifier")]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Gets or sets the unique identifier for the user associated with this moderator.
        /// </summary>
        /// <remarks>
        /// This is a required field that links the moderator to a specific user.
        /// </remarks>
        [Required]
        [Comment("User indetifier")]
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the user associated with this moderator.
        /// </summary>
        /// <remarks>
        /// This is a required field and establishes a foreign key relationship with the <see cref="ApplicationUser"/> entity.
        /// </remarks>
        [Required]
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        /// <summary>
        /// Gets or sets the collection of events owned by the moderator.
        /// </summary>
        /// <remarks>
        /// This collection allows the moderator to manage and oversee events within the system.
        /// </remarks>
        public ICollection<Event> OwnedEvents { get; set; } = new HashSet<Event>();

        /// <summary>
        /// Gets or sets the collection of games owned by the moderator.
        /// </summary>
        /// <remarks>
        /// This collection allows the moderator to manage and oversee games within the system.
        /// </remarks>
        public ICollection<Game> OwnedGames { get; set; } = new HashSet<Game>();
    }
}
