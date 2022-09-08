using Microsoft.EntityFrameworkCore;
using HMS_web.Models.Domain;

namespace HMS_web.Data
{
    public class MVCDBContext : DbContext
    {
        public MVCDBContext(DbContextOptions  options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Patients> Patients { get; set; } 
        public DbSet<Appointments> Appointments { get; set; }

    }
}
