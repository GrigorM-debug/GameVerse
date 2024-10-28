using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameVerse.Data.Models.Games.Restrictions
{
    [PrimaryKey(nameof(GameId), nameof(RestrictionId))]
    public class GameRestriction
    {
        public Guid GameId { get; set; }

        [Required]
        [ForeignKey(nameof(GameId))]
        public Game Game { get; set; } = null!;

        public Guid RestrictionId { get; set; }

        [Required]
        [ForeignKey(nameof(RestrictionId))]
        public Restriction Restriction { get; set; } = null!;
    }
}
