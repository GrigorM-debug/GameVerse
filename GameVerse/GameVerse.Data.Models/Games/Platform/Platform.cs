using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static GameVerse.Common.ApplicationConstants;

namespace GameVerse.Data.Models.Games.Platform
{
    /// <summary>
    /// Represents a gaming platform within the GameVerse system.
    /// </summary>
    [Comment("Game Platform")]
    public class Platform
    {
        /// <summary>
        /// Gets or sets the unique identifier for the platform.
        /// </summary>
        /// <remarks>
        /// This is a required field and is initialized with a new <see cref="Guid"/> when a new platform is created.
        /// </remarks>
        [Key]
        [Required]
        [Comment("The platform unique identifier.")]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Gets or sets the name of the platform.
        /// </summary>
        /// <remarks>
        /// This is a required field with string length constraints defined by <see cref="PlatformConstants.NameMaxLength"/> and <see cref="PlatformConstants.NameMinLength"/>.
        /// </remarks>
        [Required]
        [StringLength(PlatformConstants.NameMaxLength, MinimumLength = PlatformConstants.NameMinLength, ErrorMessage = LengthErrorMessage)]
        [Comment("The name of the platform")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Gets or sets the collection of <see cref="GamePlatform"/> objects that associate games with this platform.
        /// </summary>
        /// <remarks>
        /// This collection establishes a many-to-many relationship between games and platforms.
        /// </remarks>
        public ICollection<GamePlatform> GamesPlatforms { get; set; } = new HashSet<GamePlatform>();
    }
}
