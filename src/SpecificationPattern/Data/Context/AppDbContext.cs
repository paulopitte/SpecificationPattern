using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    { }
    public DbSet<Developer> Developers { get; set; }
    public DbSet<Address> Address { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Developer>()
              .ToTable("Developers")
              .Ignore(x => x.Level);

        modelBuilder.Entity<Developer>()

              .Property(x => x.Name).HasMaxLength(80);
        modelBuilder.Entity<Developer>()
             .Property(x => x.Email).HasMaxLength(150);
        modelBuilder.Entity<Developer>()
             .Property(x => x.EstimatedIncome).HasPrecision(10, 2);

        modelBuilder.Entity<Address>()
                 .ToTable("Address")
             .Property(x => x.City).HasMaxLength(50);
        modelBuilder.Entity<Address>()
               .Property(x => x.Location).HasMaxLength(200);
    }
}
