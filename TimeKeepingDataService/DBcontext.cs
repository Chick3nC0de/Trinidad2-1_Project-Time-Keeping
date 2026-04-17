using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using TimeKeeping.Models;

namespace TimeKeeping.DataService
{
    public class TimeKeepingContext : DbContext
    {
        public DbSet<Staffs> Employees { get; set; }
        public DbSet<hoursLog> Logs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Application Name=\"SQL Server Management Studio\";Command Timeout=0";

            options.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Staffs>().HasKey(s => s.empID);
            modelBuilder.Entity<hoursLog>().HasKey(l => l.Timestamp);
        }
    }
}