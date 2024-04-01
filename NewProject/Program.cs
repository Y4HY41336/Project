using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NewProject.Context;
using NewProject.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<NestDbContext>(options =>
{
    options.UseSqlServer("name=ConnectionStrings:default");
});

builder.Services.AddIdentity<AppUser,IdentityRole>(options =>
{
    options.User.RequireUniqueEmail= true;

    options.Password.RequiredLength= 8;
    options.Password.RequireNonAlphanumeric= true;
    options.Password.RequireDigit= true;
    options.Password.RequireLowercase= true;
    options.Password.RequireUppercase= true;

    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
    options.Lockout.AllowedForNewUsers = true;
})
    .AddEntityFrameworkStores<NestDbContext>();

var app = builder.Build();

app.UseStaticFiles();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=home}/{action=Index}/{Id?}"

    );

app.Run();