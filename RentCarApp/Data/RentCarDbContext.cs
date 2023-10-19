using Microsoft.EntityFrameworkCore;
using RentCarApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCarApp.Data
{
    public class RentCarDbContext : DbContext
    {
        public DbSet<Car> Employees => Set<Car>();
        public DbSet<Borrower> BusinessPartners => Set<Borrower>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("StorageAppDb");
        }
    }
}
