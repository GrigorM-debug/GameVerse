using GameVerse.Data.Models.Games;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameVerse.Data.Models.Carts
{
    [PrimaryKey(nameof(GameId), nameof(CartId))]
    public class GameCart
    {
        [Required]
        public Guid GameId { get; set; }

        [Required]
        [ForeignKey(nameof(GameId))]
        public Game Game { get; set; } = null!;

        [Required]
        public Guid CartId { get; set; }

        [Required]
        [ForeignKey(nameof(CartId))]
        public Cart Cart { get; set; } = null!;

        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime AddedOn { get; set; }

        [Required]
        public bool IsDeleted { get; set; }
    }
}
