using Microsoft.EntityFrameworkCore;

namespace ManageJobs.Models
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext>options):base(options)
        {
            
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Jobs> Jobs { get; set; }
    }
}
