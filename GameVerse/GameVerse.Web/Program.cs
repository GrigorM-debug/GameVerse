using GameVerse.Data;
using GameVerse.Data.DataSeed;
using GameVerse.Data.Models.ApplicationUsers;
using GameVerse.Data.Repositories;
using GameVerse.Data.Repositories.Interfaces;
using GameVerse.Web.ModelBinders;
using GameVerse.Web.ModelBinders.DecimalModelBinder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using GameVerse.Data.Models.Games;
using GameVerse.Services.Interfaces;
using GameVerse.Services;
using GameVerse.Web.Areas.Administrator.Services;
using GameVerse.Web.Areas.Administrator.Services.Interfaces;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddLogging(config =>
//{
//    config.AddConsole();
//});

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File("logs/GameVerseSystemLogs-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

//Add Database
builder.Services.AddDatabase(builder.Configuration);

//Repository. 
builder.Services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));

//Services
builder.Services.AddServices(builder.Configuration);

//Add Identity
builder.Services.AddApplicationIdentity(builder.Configuration);

builder.Services.AddControllersWithViews(options =>
{
    options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
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

    //await DataSeeder.SeedUsersAndRolesAsync(userManager, roleManager);
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

//app.MapControllerRoute(
//    name: "areas",
//    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "adminAreaRoute",
    pattern: "Administrator/{controller=Administrator}/{action=Dashboard}/{id?}",
    defaults: new { area = "Administrator" });

app.MapControllerRoute(
    name: "moderatorAreaRoute",
    pattern: "Moderator/{controller=Moderator}/{action=Dashboard}/{id?}",
    defaults: new { area = "Moderator" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();


app.Run();
