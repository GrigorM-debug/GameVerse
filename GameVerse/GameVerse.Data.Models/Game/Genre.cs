using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static GameVerse.Common.ApplicationConstants;

namespace GameVerse.Data.Models
{
    public class Genre
    {
        [Key]
        [Required]
        [Comment("The genre unique indetifier")]
        public Guid Id { get; set; }

        [Required]
        [StringLength(GenreConstants.NameMaxlength, MinimumLength = GenreConstants.NameMinLength, ErrorMessage = LengthErrorMessage)]
        [Comment("The name of the genre")]
        public string Name { get; set; } = null!;

        public ICollection<Game> Games { get; set; } = new HashSet<Game>();
    }
}
