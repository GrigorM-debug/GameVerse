using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameVerse.Data.Models.Games.Genres
{
    /// <summary>
    /// Represents the many-to-many relationship between games and genres.
    /// </summary>
    /// <remarks>
    /// Each instance links a specific game to a specific genre.
    /// </remarks>
    [Comment("Established many-to-many relation between Game and Genre tables")]
    [PrimaryKey(nameof(GameId), nameof(GenreId))]
    public class GameGenre
    {
        /// <summary>
        /// Gets or sets the unique identifier for the game in this relationship.
        /// </summary>
        [Required]
        [Comment("The game unique indentifier")]
        public Guid GameId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the game in this relationship.
        /// </summary>
        [Required]
        [ForeignKey(nameof(GameId))]
        public Game Game { get; set; } = null!;

        /// <summary>
        /// Gets or sets the unique identifier for the genre in this relationship.
        /// </summary>
        [Required]
        [Comment("The genre unique indentifier")]
        public Guid GenreId { get; set; }

        /// <summary>
        /// Gets or sets the genre entity associated with this relationship.
        /// </summary>
        [Required]
        [ForeignKey(nameof(GenreId))]
        public Genre Genre { get; set; } = null!;
    }
}
