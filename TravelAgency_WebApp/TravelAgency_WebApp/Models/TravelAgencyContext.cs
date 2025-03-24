using Microsoft.EntityFrameworkCore;

namespace TravelAgency_WebApp.Models
{
  public sealed class TravelAgencyContext : DbContext
  {
    public TravelAgencyContext(DbContextOptions<TravelAgencyContext> options)
        : base(options)
    {
    }

    public DbSet<Client> Clients { get; set; }
    public DbSet<AgencyWorker> AgencyWorkers { get; set; }
    public DbSet<BookTour> BookTours { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Number> Numbers { get; set; }
    public DbSet<Residence> Residences { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Residence>().HasKey(r => new { r.BookTour_Id, r.Number_Id });
      base.OnModelCreating(modelBuilder);
    }
  }
}
