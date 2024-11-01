using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static GameVerse.Common.ApplicationConstants;

namespace GameVerse.Data.Models.Games.Restrictions
{
    /// <summary>
    /// Represents a restriction that can be applied to games within the GameVerse system.
    /// </summary>
    [Comment("Game Restriction")]
    public class Restriction
    {
        /// <summary>
        /// Gets or sets the unique identifier for the restriction.
        /// </summary>
        /// <remarks>
        /// This is a required field and is initialized with a new <see cref="Guid"/> when a new restriction is created.
        /// </remarks>
        [Key]
        [Required]
        [Comment("The restriction unique indentifier")]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Gets or sets the name of the restriction.
        /// </summary>
        /// <remarks>
        /// This is a required field with string length constraints defined by <see cref="RestrictionsConstants.RestrictionNameMaxLength"/> and <see cref="RestrictionsConstants.RestrictionNameMinLength"/>.
        /// </remarks>
        [Required]
        [StringLength(RestrictionsConstants.RestrictionNameMaxLength, MinimumLength = RestrictionsConstants.RestrictionNameMinLength, ErrorMessage = LengthErrorMessage)]
        [Comment("The name of the restriction")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Gets or sets the collection of <see cref="GameRestriction"/> objects that associate games with this restriction.
        /// </summary>
        /// <remarks>
        /// This collection establishes a many-to-many relationship between games and restrictions.
        /// </remarks>
        public ICollection<GameRestriction> GamesRestrictions { get; set; } = new HashSet<GameRestriction>();
    }
}
