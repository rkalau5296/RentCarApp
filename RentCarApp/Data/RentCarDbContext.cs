using Microsoft.EntityFrameworkCore;
using RentCarApp.Data.Entities;

namespace RentCarApp.Data
{
    public class RentCarDbContext : DbContext
    {
        private readonly string _connectionString = "Server=DESKTOP-6QU5KCP;Database=RentCarDb;Trusted_Connection=True; TrustServerCertificate=True;";
        public DbSet<Car> Cars => Set<Car>();
        public DbSet<Borrower> Borrowers => Set<Borrower>();
        public DbSet<Truck> Trucks => Set<Truck>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .Property(c => c.Brand)
                .IsRequired()
                .HasMaxLength(25);

            modelBuilder.Entity<Borrower>()
               .Property(c => c.FirstName)
               .IsRequired()
               .HasMaxLength(25);

            modelBuilder.Entity<Truck>()
               .Property(t => t.Brand)
               .IsRequired()
               .HasMaxLength(25);
        }
    }
}
