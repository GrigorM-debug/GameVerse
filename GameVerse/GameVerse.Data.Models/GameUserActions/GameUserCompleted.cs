using GameVerse.Data.Models.Games;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameVerse.Data.Models.GameUserActions
{
    [PrimaryKey(nameof(GameId), nameof(UserId))]
    public class GameUserCompleted
    {
        [Comment("The id of the Game added in User completed games list")]
        public Guid GameId { get; set; }

        [Required]
        [ForeignKey(nameof(GameId))]
        public Game Game { get; set; } = null!;

        [Comment("The id of the User")]
        public Guid UserId { get; set; }

        [Required]
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        [Comment("The date and time when the game is completed")]
        public DateTime CompletedOn { get; set; }
    }
}
