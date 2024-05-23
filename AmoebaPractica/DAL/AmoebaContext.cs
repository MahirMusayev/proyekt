using AmoebaPractica.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AmoebaPractica.DAL
{
	public class AmoebaContext : IdentityDbContext<AppUser>
	{
		public AmoebaContext(DbContextOptions options) : base(options)
		{
		}
        public DbSet<Team> Teams { get; set; }
    }
}
