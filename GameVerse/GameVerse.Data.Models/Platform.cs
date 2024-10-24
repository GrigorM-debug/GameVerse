using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameVerse.Common.ApplicationConstants;

namespace GameVerse.Data.Models
{
    public class Platform
    {
        [Key]
        [Required]
        [Comment("The platform unique identifier.")]
        public Guid Id { get; set; }

        [Required]
        [StringLength(PlatformConstants.NameMaxLength, MinimumLength = PlatformConstants.NameMinLength, ErrorMessage = LengthErrorMessage]
        public string Name { get; set; } = null!;

        public ICollection<GamePlatform> GamePlatforms { get; set; } = new HashSet<GamePlatform>();
    }
}
