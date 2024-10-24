using Microsoft.EntityFrameworkCore;

namespace GameVerse.Data.Models
{
    public class GameUserCompleted
    {
        [Comment("The id of the Game")]
        public Guid GameId { get; set; }

        public Game Game { get; set; } = null!;

        //Add properties for Application user

        [Comment("The date and time when the game is completed")]
        public DateTime CompletedOnm { get; set; } 
    }
}
