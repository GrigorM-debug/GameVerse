using AspNetCoreHero.ToastNotification.Notyf.Models;
using GameVerse.Data;
using GameVerse.Data.Models.ApplicationUsers;
using GameVerse.Services.Interfaces;
using GameVerse.Services;
using GameVerse.Web.Areas.Administrator.Services.Interfaces;
using GameVerse.Web.Areas.Administrator.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Provides extension methods for configuring application services, identity, and database connections.
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Registers application services in the dependency injection container.
        /// </summary>
        /// <param name="services">The service collection to which the services will be added.</param>
        /// <param name="config">The application configuration containing settings for services.</param>
        /// <returns>
        /// The updated <see cref="IServiceCollection"/> with the registered services.
        /// </returns>
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IModeratorService, ModeratorService>();
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<IShoppingCartService, ShoppingCartService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserManagementService, UserManagementService>();
            services.AddScoped<ILogService, LogService>();
            services.AddScoped<IEventsRegistrationsService, EventsRegistrationsService>();
            services.AddScoped<IUsersBoughtGamesService, UsersBoughtGamesService>();
            services
                .AddScoped<GameVerse.Web.Areas.Moderator.Services.Interfaces.IModeratorService,
                    GameVerse.Web.Areas.Moderator.Services.ModeratorService>();
            services.AddScoped<IImageValidationService, ImageValidationService>();
            services.AddScoped<IQrCodeService, QrCodeService>();
            services.AddScoped<IEmailSender, EmailSender>();

            return services;
        }

        /// <summary>
        /// Configures and registers application identity services with custom settings for password policies and sign-in requirements.
        /// </summary>
        /// <param name="services">The service collection to which the identity services will be added.</param>
        /// <param name="config">The application configuration containing identity settings.</param>
        /// <returns>
        /// The updated <see cref="IServiceCollection"/> with the registered identity services.
        /// </returns>
        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration config)
        {
            IConfigurationSection passwordSettings = config.GetSection("IdentitySettings:Password");
            IConfigurationSection signInSettings = config.GetSection("IdentitySettings:SignIn");
            IConfiguration userSettings = config.GetSection("IdentitySettings:User");
            IConfiguration lockoutSettings = config.GetSection("IdentitySettings:Lockout");

            services.AddDefaultIdentity<ApplicationUser>(options =>
                {
                    //Sign In 
                    options.SignIn.RequireConfirmedAccount = bool.Parse(signInSettings["RequireConfirmedAccount"]);
                    options.SignIn.RequireConfirmedEmail = bool.Parse(signInSettings["RequireConfirmedEmail"]);
                    
                    //Password
                    options.Password.RequireDigit = bool.Parse(passwordSettings["RequireDigit"]);
                    options.Password.RequireNonAlphanumeric = bool.Parse(passwordSettings["RequireNonAlphanumeric"]);
                    options.Password.RequireLowercase = bool.Parse(passwordSettings["RequireLowercase"]); 
                    options.Password.RequireUppercase = bool.Parse(passwordSettings["RequireUppercase"]);
                    options.Password.RequiredLength = int.Parse(passwordSettings["RequiredLength"]);
                    options.Password.RequiredUniqueChars = int.Parse(passwordSettings["RequiredUniqueChars"]);

                    //User
                    options.User.AllowedUserNameCharacters = userSettings["AllowedUserNameCharacters"];
                    options.User.RequireUniqueEmail = bool.Parse(userSettings["RequireUniqueEmail"]);

                    //Lockout
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                    options.Lockout.MaxFailedAccessAttempts = int.Parse(lockoutSettings["MaxFailedAccessAttempts"]);
                    options.Lockout.AllowedForNewUsers = bool.Parse(lockoutSettings["AllowedForNewUsers"]);
                })
                .AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<GameVerseDbContext>();

            return services;
        }

        /// <summary>
        /// Configures and registers the application's database context using a SQL Server connection.
        /// </summary>
        /// <param name="services">The service collection to which the database context will be added.</param>
        /// <param name="config">The application configuration containing the connection string.</param>
        /// <returns>
        /// The updated <see cref="IServiceCollection"/> with the registered database context.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the connection string for the database is not found in the configuration.
        /// </exception>
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("SqlServer") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            services.AddDbContext<GameVerseDbContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }
    }
}
