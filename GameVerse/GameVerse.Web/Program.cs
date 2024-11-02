using GameVerse.Data;
using GameVerse.Data.DataSeed;
using GameVerse.Data.Models.ApplicationUsers;
using GameVerse.Data.Repositories;
using GameVerse.Data.Repositories.Interfaces;
using GameVerse.Web.ModelBinders;
using GameVerse.Web.ModelBinders.DateTimeModelBinder;
using GameVerse.Web.ModelBinders.DecimalModelBinder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using GameVerse.Services.Interfaces;
using GameVerse.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("SqlServer") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<GameVerseDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//Reposity. 
builder.Services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));

//Services
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IModeratorService, ModeratorService>();


builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
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

builder.Services.AddControllersWithViews(options =>
{
    options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
    options.ModelBinderProviders.Insert(1, new DateTimeModelBinderProvider(new[] { GameVerse.Common.ApplicationConstants.DateTimeFormat, GameVerse.Common.ApplicationConstants.EventConstants.EventDateTimeFormat }));
});

builder.Services.AddNotyf(config =>
{
    config.DurationInSeconds = 10;
    config.IsDismissable = true;
    config.Position = NotyfPosition.TopRight;
});


var app = builder.Build();

//Adding data for Roles, Admin and Moderator
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = scope.ServiceProvider.GetRequiredService<GameVerseDbContext>();
    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

    await DataSeeder.SeedUsersAndRolesAsync(userManager, roleManager);
    await context.SeedModeratorsAndAdminsDataAsync(userManager, roleManager, context);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error/500");
    app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseNotyf();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
