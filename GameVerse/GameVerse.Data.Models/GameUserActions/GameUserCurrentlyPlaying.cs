using GameVerse.Data.Models.Games;

namespace GameVerse.Data.Models.GameUserActions
{
    public class GameUserCurrentlyPlaying
    {
        public Guid GameId { get; set; }

        public Game Game { get; set; } = null!;

        public DateTime AddedOn { get; set; }

        // Add properties for ApplicationUser
    }
}
