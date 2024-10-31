using GameVerse.Data.DataSeed;
using GameVerse.Data.Models.ApplicationUsers;
using GameVerse.Data.Models.Carts;
using GameVerse.Data.Models.Events;
using GameVerse.Data.Models.Games;
using GameVerse.Data.Models.Games.Genres;
using GameVerse.Data.Models.Games.Platform;
using GameVerse.Data.Models.Games.Restrictions;
using GameVerse.Data.Models.Games.Review;
using GameVerse.Data.Models.GameUserActions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameVerse.Data
{
    public class GameVerseDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    { 
        public GameVerseDbContext(DbContextOptions<GameVerseDbContext> options) : base(options)
        {
        }

        public DbSet<Event> Events { get; set; } = null!;

        public DbSet<EventRegistration> EventsRegistrations { get; set; } = null!;

        public DbSet<Genre> Genres { get; set; } = null!;

        public DbSet<Platform> Platforms { get; set; } = null!;

        public DbSet<Restriction> Restrictions { get; set; } = null!;

        public DbSet<GameReview> GameReviews { get; set; } = null!;

        public DbSet<Game> Games { get; set; } = null!;

        public DbSet<GameGenre> GamesGenres { get; set; } = null!;

        public DbSet<GameRestriction> GamesRestrictions { get; set; } = null!;

        public DbSet<GamePlatform> GamesPlatforms { get; set; } = null!;

        public DbSet<Cart> Carts { get; set; } = null!;

        public DbSet<GameCart> GamesCarts { get; set; } = null!;

        public DbSet<EventCart> EventsCarts { get; set; } = null!;

        //Games that users marked as completed. Games that they finiched playing.
        public DbSet<GameUserCompleted> GamesUsersCompleted { get; set; } = null!;

        //Games that users are currently playing.
        public DbSet<GameUserCurrentlyPlaying> GamesUsersCurrentlyPlaying { get; set; } = null!;

        //Games that users would like to buy and play. 
        public DbSet<GameUserWishlist> GameUserWishlists { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Data seeding
            DataSeeder.SeedGenres(builder);
            DataSeeder.SeedPlatforms(builder);
            DataSeeder.SeedRestrictions(builder);

            builder
                .Entity<Game>()
                .Property(g => g.Type)
                .HasConversion<string>(); // Convert Enum to string in the Database. 

            builder
                .Entity<Event>()
                .Property(e => e.IsDeleted)
                .HasDefaultValue(false);

            base.OnModelCreating(builder);
        }
    }
}
