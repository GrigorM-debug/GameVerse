using GameVerse.Data.Models;
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
                .Entity<Game>()
                .Property(g => g.Type)
                .HasConversion<string>(); // Convert Enum to string in the Database. 

            base.OnModelCreating(builder);
        }
    }
}
