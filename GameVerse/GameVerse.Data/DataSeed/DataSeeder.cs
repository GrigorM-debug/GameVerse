using GameVerse.Data.Models.Games.Genres;
using GameVerse.Data.Models.Games.Platform;
using GameVerse.Data.Models.Games.Restrictions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameVerse.Data.DataSeed
{
    internal static class DataSeeder
    {
        public static void SeedGenres(ModelBuilder modelBuilder)
        {
            List<Genre> genres = new List<Genre>()
            {
                new Genre { Id = Guid.NewGuid(), Name = "Adventure"},
                new Genre { Id = Guid.NewGuid(), Name = "Action"},
                new Genre { Id = Guid.NewGuid(), Name = "Sports"},
                new Genre { Id = Guid.NewGuid(), Name = "Simulation" },
                new Genre { Id = Guid.NewGuid(), Name = "Platformer" },
                new Genre { Id = Guid.NewGuid(), Name = "RPG" },
                new Genre { Id = Guid.NewGuid(), Name = "First-Person Shooter" },
                new Genre { Id = Guid.NewGuid(), Name = "Action-adventure" },
                new Genre { Id = Guid.NewGuid(), Name = "Fighting" },
                new Genre { Id = Guid.NewGuid(), Name = "Real-time strategy" },
                new Genre { Id = Guid.NewGuid(), Name = "Racing" },
                new Genre { Id = Guid.NewGuid(), Name = "Shooter" },
                new Genre { Id = Guid.NewGuid(), Name = "Puzzle" },
                new Genre { Id = Guid.NewGuid(), Name = "Casual" },
                new Genre { Id = Guid.NewGuid(), Name = "Strategy game" },
                new Genre { Id = Guid.NewGuid(), Name = "Stealth" },
                new Genre { Id = Guid.NewGuid(), Name = "Party" },
                new Genre { Id = Guid.NewGuid(), Name = "Action RPG" },
                new Genre { Id = Guid.NewGuid(), Name = "Survival" },
                new Genre { Id = Guid.NewGuid(), Name = "Battle Royale" }
            };

            modelBuilder.Entity<Genre>().HasData(genres);
        }

        public static void SeedPlatforms(ModelBuilder modelBuilder)
        {
            List<Platform> platforms = new List<Platform>()
            {
                new Platform { Id = Guid.NewGuid(), Name = "PC" },
                new Platform { Id = Guid.NewGuid(), Name = "Mac"},
                new Platform { Id = Guid.NewGuid(), Name = "PlayStation 1"},
                new Platform { Id = Guid.NewGuid(), Name = "PlayStation 2" },
                new Platform { Id = Guid.NewGuid(), Name = "PlayStation 3"},
                new Platform { Id = Guid.NewGuid(), Name = "PlayStation 4"},
                new Platform { Id = Guid.NewGuid(), Name = "PlayStation 5"},
                new Platform { Id = Guid.NewGuid(), Name = "Xbox One"},
                new Platform { Id = Guid.NewGuid(), Name = "Linux"},
                new Platform { Id = Guid.NewGuid(), Name = "Nintendo Switch"},
                new Platform { Id = Guid.NewGuid(), Name = "Nintendo Wii" },
                new Platform { Id = Guid.NewGuid(), Name = "Xbox Series X"},
                new Platform { Id = Guid.NewGuid(), Name = "Xbox 360"},
                new Platform { Id = Guid.NewGuid(), Name = "Nintendo DS"},
                new Platform { Id = Guid.NewGuid(), Name = "Super Nintendo" },
                new Platform { Id = Guid.NewGuid(), Name = "PlayStation Portable" },
                new Platform { Id = Guid.NewGuid(), Name = "PlayStation Vita" },
                new Platform { Id = Guid.NewGuid(), Name = "Game Boy" },
                new Platform { Id = Guid.NewGuid(), Name = "Game Boy Advanced" },
                new Platform { Id = Guid.NewGuid(), Name = "Sega Mega Drive" }
            };

            modelBuilder.Entity<Platform>().HasData(platforms);
        }

        public static void SeedRestrictions(ModelBuilder modelBuilder)
        {
            List<Restriction> restrictions = new List<Restriction>()
            {
                new Restriction {Id = Guid.NewGuid(), Name = "PEGI 3"},
                new Restriction {Id = Guid.NewGuid(), Name = "PEGI 7"},
                new Restriction {Id = Guid.NewGuid(), Name = "PEGI 12"},
                new Restriction {Id = Guid.NewGuid(), Name = "PEGI 16 "},
                new Restriction {Id = Guid.NewGuid(), Name = "PEGI 18"},
                new Restriction {Id = Guid.NewGuid(), Name = "Bad Language"},
                new Restriction {Id = Guid.NewGuid(), Name = "Discrimination"},
                new Restriction {Id = Guid.NewGuid(), Name = "Drugs"},
                new Restriction {Id = Guid.NewGuid(), Name = "Fear"},
                new Restriction {Id = Guid.NewGuid(), Name = "Gambling"},
                new Restriction {Id = Guid.NewGuid(), Name = "Sex"},
                new Restriction {Id = Guid.NewGuid(), Name = "Violence"},
                new Restriction {Id = Guid.NewGuid(), Name = "In-Game Purchases"},
            };

            modelBuilder.Entity<Restriction>().HasData(restrictions);
        }
    }
}
