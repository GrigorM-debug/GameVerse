using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameVerse.Data.Models
{
    [PrimaryKey(nameof(GameId), nameof(PlatformId))]
    public class GamePlatform
    {
        public Guid GameId { get; set; }

        [Required]
        [ForeignKey(nameof(PlatformId))]
        public Game Game { get; set; } = null!;

        [ForeignKey(nameof(GameId))]
        public Guid PlatformId { get; set; }

        public Platform Platform { get; set; } = null!;
    }
}
