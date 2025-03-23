using Microsoft.EntityFrameworkCore;

namespace TravelAgency_WebApp.Models
{
	sealed public class TravelAgencyContext : DbContext
	{
		public DbSet<Client> Clients { get; set; }
		public TravelAgencyContext()
		{
			Database.EnsureCreated();
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=TravelAgency_CourseWork;Username=postgres;Password=root");
		}
	}
}
