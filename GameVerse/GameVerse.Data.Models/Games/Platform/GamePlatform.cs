using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameVerse.Data.Models.Games.Platform
{
    [PrimaryKey(nameof(GameId), nameof(PlatformId))]
    public class GamePlatform
    {
        public Guid GameId { get; set; }

        [Required]
        [ForeignKey(nameof(PlatformId))]
        public Game Game { get; set; } = null!;

        public Guid PlatformId { get; set; }

        [Required]
        [ForeignKey(nameof(GameId))]
        public Platform Platform { get; set; } = null!;
    }
}
