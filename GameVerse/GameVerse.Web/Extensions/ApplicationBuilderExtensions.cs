using GameVerse.Data;
using GameVerse.Data.Models.ApplicationUsers;
using GameVerse.Services.Interfaces;
using GameVerse.Services;
using GameVerse.Web.Areas.Administrator.Services.Interfaces;
using GameVerse.Web.Areas.Administrator.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ApplicationBuilderExtensions
    {
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

            return services;
        }

        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration config)
        {
            IConfigurationSection passwordSettings = config.GetSection("IdentitySettings:Password");
            IConfigurationSection signInSettings = config.GetSection("IdentitySettings:SignIn");

            services.AddDefaultIdentity<ApplicationUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = bool.Parse(signInSettings["RequireConfirmedAccount"]);
                    options.Password.RequireDigit = bool.Parse(passwordSettings["RequireDigit"]);
                    options.Password.RequireNonAlphanumeric = bool.Parse(passwordSettings["RequireNonAlphanumeric"]);
                    options.Password.RequireLowercase = bool.Parse(passwordSettings["RequireLowercase"]); 
                    options.Password.RequireUppercase = bool.Parse(passwordSettings["RequireUppercase"]);
                    options.Password.RequiredLength = int.Parse(passwordSettings["RequiredLength"]);
                })
                .AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<GameVerseDbContext>();

            return services;
        }

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
