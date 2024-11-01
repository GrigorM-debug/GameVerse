using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static GameVerse.Common.ApplicationConstants;

namespace GameVerse.Data.Models.Games.Genres
{
    /// <summary>
    /// Represents a game genre within the GameVerse system.
    /// </summary>
    [Comment("Game Genre")]
    public class Genre
    {
        /// <summary>
        /// Gets or sets the unique identifier for the genre.
        /// </summary>
        /// <remarks>
        /// This is a required field and is generated as a new <see cref="Guid"/> when a new genre is created.
        /// </remarks>
        [Key]
        [Required]
        [Comment("The genre unique indetifier")]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Gets or sets the name of the genre.
        /// </summary>
        /// <remarks>
        /// This is a required field with a string length constraint, as defined by <see cref="GenreConstants.NameMaxLength"/> and <see cref="GenreConstants.NameMinLength"/>.
        /// </remarks>
        [Required]
        [StringLength(GenreConstants.NameMaxlength, MinimumLength = GenreConstants.NameMinLength, ErrorMessage = LengthErrorMessage)]
        [Comment("The name of the genre")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Gets or sets the collection of <see cref="GameGenre"/> objects that associate games with this genre.
        /// </summary>
        /// <remarks>
        /// This collection establishes a many-to-many relationship between games and genres.
        /// </remarks>
        public ICollection<GameGenre> GamesGenres { get; set; } = new HashSet<GameGenre>();
    }
}
