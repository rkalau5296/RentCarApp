using Microsoft.EntityFrameworkCore;
using RentCarApp.Data.Entities;

namespace RentCarApp.Data
{
    public class RentCarDbContext : DbContext
    {
        public RentCarDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Car> Cars => Set<Car>();
        public DbSet<Borrower> Borrowers => Set<Borrower>();
        public DbSet<Truck> Trucks => Set<Truck>();
        public DbSet<Client> Client => Set<Client>();
    }
}
