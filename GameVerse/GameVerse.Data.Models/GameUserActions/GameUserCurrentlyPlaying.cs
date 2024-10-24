namespace GameVerse.Data.Models
{
    public class GameUserCurrentlyPlaying
    {
        public Guid GameId { get; set; }

        public Game Game { get; set; } = null!;

        public DateTime AddedOn { get; set; }

        // Add properties for ApplicationUser
    }
}
