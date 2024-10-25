using GameVerse.Data.Models.Games;

namespace GameVerse.Data.Models
{
    public class GameCart
    {
        public Guid CartId { get; set; }

        public Cart Cart { get; set; } = null!;

        public Guid GameId { get; set; }
        public Game Game { get; set; } = null!;

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
