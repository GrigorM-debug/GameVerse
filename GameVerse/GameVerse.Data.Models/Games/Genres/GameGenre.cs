﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameVerse.Data.Models.Games.Genres
{
    [PrimaryKey(nameof(GameId), nameof(GenreId))]
    public class GameGenre
    {
        public Guid GameId { get; set; }

        [Required]
        [ForeignKey(nameof(GameId))]
        public Game Game { get; set; } = null!;

        public Guid GenreId { get; set; }

        [Required]
        [ForeignKey(nameof(GenreId))]
        public Genre Genre { get; set; } = null!;
    }
}