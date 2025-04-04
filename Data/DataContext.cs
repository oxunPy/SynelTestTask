using Microsoft.EntityFrameworkCore;
using SynelTestTask.Entity;

namespace SynelTestTask.Data
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        // DbSets for the entities
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
            options.UseSqlServer(_configuration.GetConnectionString("MSSqlServerConnection")).EnableDetailedErrors();
        }
    }
}
