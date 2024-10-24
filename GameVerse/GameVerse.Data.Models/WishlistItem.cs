using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameVerse.Data.Models
{
    public class WishlistItem
    {
        [Key]
        [Required]
        [Comment("The Wishlist item unique indetifier")]
        public Guid Id { get; set; }

        [Comment("The date and time when the item is added")]
        public DateTime AddedOn { get; set; }

        [Comment("The id of the game added in the Wishlist")]
        public Guid GameId { get; set; }

        [Required]
        [ForeignKey(nameof(GameId))]
        public Game Game { get; set; } = null!;

        //Add properties for Application User
    }
}
