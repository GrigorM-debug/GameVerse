using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static GameVerse.Common.ApplicationConstants;

namespace GameVerse.Data.Models.Games.Platform
{
    public class Platform
    {
        [Key]
        [Required]
        [Comment("The platform unique identifier.")]
        public Guid Id { get; set; }

        [Required]
        [StringLength(PlatformConstants.NameMaxLength, MinimumLength = PlatformConstants.NameMinLength, ErrorMessage = LengthErrorMessage)]
        [Comment("The name of the platform")]
        public string Name { get; set; } = null!;

        public ICollection<GamePlatform> GamesPlatforms { get; set; } = new HashSet<GamePlatform>();
    }
}
