﻿using GameVerse.Data.Models;
using GameVerse.Data.Models.Games;
using GameVerse.Data.Models.Games.Genres;
using GameVerse.Data.Models.Games.Platform;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameVerse.Data
{
    public class GameVerseContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    { 
        public GameVerseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Platform>()
                .HasData(
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
                );

            builder
                .Entity<Genre>()
                .HasData(
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
                );

            builder
                .Entity<Game>()
                .Property(g => g.Type)
                .HasConversion<string>(); // Convert Enum to string in the Database. 

            base.OnModelCreating(builder);
        }
    }
}
