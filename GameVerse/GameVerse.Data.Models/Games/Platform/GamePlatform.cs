using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameVerse.Data.Models.Games.Platform
{
    /// <summary>
    /// Represents the many-to-many relationship between games and platforms.
    /// </summary>
    /// <remarks>
    /// Each instance links a specific game to a specific platform.
    /// </remarks>
    [Comment("Established many-to-many relation between Game and Platform tables")]
    [PrimaryKey(nameof(GameId), nameof(PlatformId))]
    public class GamePlatform
    {
        /// <summary>
        /// Gets or sets the unique identifier for the game in this relationship.
        /// </summary>
        [Required]
        [Comment("The game unique indentifier")]
        public Guid GameId { get; set; }

        /// <summary>
        /// Gets or sets the game entity associated with this relationship.
        /// </summary>
        [Required]
        [ForeignKey(nameof(GameId))]
        public Game Game { get; set; } = null!;

        /// <summary>
        /// Gets or sets the unique identifier for the platform in this relationship.
        /// </summary>
        [Required]
        [Comment("The platform unique identifier")]
        public Guid PlatformId { get; set; }

        /// <summary>
        /// Gets or sets the platform entity associated with this relationship.
        /// </summary>
        [Required]
        [ForeignKey(nameof(PlatformId))]
        public Platform Platform { get; set; } = null!;
    }
}
