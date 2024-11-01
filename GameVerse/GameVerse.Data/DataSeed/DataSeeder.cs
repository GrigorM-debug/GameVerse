using GameVerse.Data.Models.ApplicationUsers;
using GameVerse.Data.Models.Games.Genres;
using GameVerse.Data.Models.Games.Platform;
using GameVerse.Data.Models.Games.Restrictions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GameVerse.Data.DataSeed
{
    public static class DataSeeder
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

        public static async Task SeedUsersAndRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<Guid>> roleManager)
        {
            //Passwords Hash
            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();

            //Creating the Roles
            string[] roles = { "Admin", "Moderator" };

            foreach (string role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole<Guid>(role));
                }
            }

            //Creating Admin
            ApplicationUser adminUser = new ApplicationUser()
            {
                UserName = "AdminAdminov6740",
                NormalizedUserName = "ADMINADMINOV6740",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                FirstName = "Admin",
                LastName = "Adminov"
            };

            if (await userManager.FindByEmailAsync(adminUser.Email) == null)
            {
                adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "AdminPassword123!");

                await userManager.CreateAsync(adminUser);
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }

            //Creating Moderator
            ApplicationUser moderatorUser = new ApplicationUser()
            {
                UserName = "TheModerator",
                NormalizedUserName = "THEMODERATOR",
                Email = "moderator@gmail.com",
                NormalizedEmail = "MODERATOR@GMAIL.COM",
                FirstName = "Moderator",
                LastName = "Moderatorov"
            };

            if(await userManager.FindByEmailAsync(moderatorUser.Email) == null)
            {
                moderatorUser.PasswordHash = passwordHasher.HashPassword(moderatorUser, "ModeratorPassword123!");

                await userManager.CreateAsync(moderatorUser);
                await userManager.AddToRoleAsync(moderatorUser, "Moderator");
            }
        }
    }
}
