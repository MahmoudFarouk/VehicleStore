using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Configuration;

namespace VehicleStore.Models
{
    public class VSDBContext : DbContext
    {
        public VSDBContext() { }

        public VSDBContext(DbContextOptions<VSDBContext> options) : base(options) { }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CodeException> CodeExceptions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=VehicleStoreDB;User Id=sa;Password=P@ssw0rd;Trusted_Connection=False;MultipleActiveResultSets=true;");
        }
    }
}