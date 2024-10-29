using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static GameVerse.Common.ApplicationConstants;

namespace GameVerse.Data.Models.Games.Genres
{
    public class Genre
    {
        [Key]
        [Required]
        [Comment("The genre unique indetifier")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(GenreConstants.NameMaxlength, MinimumLength = GenreConstants.NameMinLength, ErrorMessage = LengthErrorMessage)]
        [Comment("The name of the genre")]
        public string Name { get; set; } = null!;

        public ICollection<GameGenre> GamesGenres { get; set; } = new HashSet<GameGenre>();
    }
}
