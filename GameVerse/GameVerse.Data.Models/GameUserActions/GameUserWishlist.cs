using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GameVerse.Data.Models.Games;
using GameVerse.Data.Models.ApplicationUsers;

namespace GameVerse.Data.Models.GameUserActions
{
    [PrimaryKey(nameof(GameId), nameof(UserId))]
    public class GameUserWishlist
    {
        [Comment("The id of the game added in the Wishlist")]
        public Guid GameId { get; set; }

        [Required]
        [ForeignKey(nameof(GameId))]
        public Game Game { get; set; } = null!;

        [Comment("The id of the User")]
        public Guid UserId { get; set; }

        [Required]
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        [Comment("The date and time when the item is added")]
        public DateTime AddedOn { get; set; }
    }
}
