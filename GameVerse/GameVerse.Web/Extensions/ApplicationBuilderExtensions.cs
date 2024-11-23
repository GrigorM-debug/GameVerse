using GameVerse.Services.Interfaces;
using GameVerse.Services;
using GameVerse.Web.Areas.Administrator.Services.Interfaces;
using GameVerse.Web.Areas.Administrator.Services;

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
    }
}
