using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameVerse.Data.Models.Games.Restrictions
{
    /// <summary>
    /// Represents the many-to-many relationship between games and restrictions.
    /// </summary>
    /// <remarks>
    /// Each instance links a specific game to a specific restriction.
    /// </remarks>
    [Comment("Established many-to-many relation between Games and Restrictions Tables")]
    [PrimaryKey(nameof(GameId), nameof(RestrictionId))]
    public class GameRestriction
    {
        // <summary>
        /// Gets or sets the unique identifier for the game in this relationship.
        /// </summary>
        [Required]
        [Comment("The game unique identifier")]
        public Guid GameId { get; set; }

        /// <summary>
        /// Gets or sets the game entity associated with this relationship.
        /// </summary>
        [Required]
        [ForeignKey(nameof(GameId))]
        public Game Game { get; set; } = null!;

        /// <summary>
        /// Gets or sets the unique identifier for the restriction in this relationship.
        /// </summary>
        [Required]
        [Comment("The restriction unique indentifier")]
        public Guid RestrictionId { get; set; }

        /// <summary>
        /// Gets or sets the restriction entity associated with this relationship.
        /// </summary>
        [Required]
        [ForeignKey(nameof(RestrictionId))]
        public Restriction Restriction { get; set; } = null!;
    }
}
