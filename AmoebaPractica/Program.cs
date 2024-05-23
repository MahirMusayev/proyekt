
using AmoebaPractica.DAL;
using AmoebaPractica.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AmoebaContext>(opt => { opt.UseSqlServer(builder.Configuration.GetConnectionString("default")); });
builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
{
	opt.Password.RequireNonAlphanumeric=false;
	opt.Password.RequireLowercase=false;
	opt.Password.RequireUppercase=false;
	opt.User.RequireUniqueEmail=true;
	opt.Lockout.MaxFailedAccessAttempts=5;
}).AddEntityFrameworkStores<AmoebaContext>()
.AddDefaultTokenProviders();
var app = builder.Build();


app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
  name: "areas",
  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

