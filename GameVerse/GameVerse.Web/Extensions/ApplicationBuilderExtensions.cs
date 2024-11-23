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

            return services;
        }

        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration config)
        {
            services.AddDefaultIdentity<ApplicationUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireDigit = true;
                    options.Password.RequireNonAlphanumeric = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireUppercase = true;
                    options.Password.RequiredLength = 8;
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
