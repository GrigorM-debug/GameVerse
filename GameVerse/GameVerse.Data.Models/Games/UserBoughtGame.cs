using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameVerse.Data.Models.ApplicationUsers;
using Microsoft.EntityFrameworkCore;

namespace GameVerse.Data.Models.Games
{
    [PrimaryKey(nameof(GameId), nameof(UserId))]
    public class UserBoughtGame
    {
        [Required]
        public Guid GameId { get; set; }

        [Required]
        [ForeignKey(nameof(GameId))]
        public Game Game { get; set; } = null!;

        [Required]
        public Guid UserId { get; set; }

        [Required]
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        [Required]
        public DateTime BoughtOn { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
