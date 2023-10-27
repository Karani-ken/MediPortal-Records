using MediPortal_Records.Models;
using Microsoft.EntityFrameworkCore;

namespace MediPortal_Records.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Record> Records { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Record>()
                .Property(r => r.Allergies)
                .HasConversion(
                    v => string.Join(";", v),  // Convert List<string> to string
                    v => v.Split(";", StringSplitOptions.RemoveEmptyEntries).ToList()  // Convert string to List<string>
                );

            modelBuilder.Entity<Record>()
                .Property(r => r.ChronicConditions)
                .HasConversion(
                    v => string.Join(";", v),  // Convert List<string> to string
                    v => v.Split(";", StringSplitOptions.RemoveEmptyEntries).ToList()  // Convert string to List<string>
                );

            modelBuilder.Entity<Record>()
                .Property(r => r.Medications)
                .HasConversion(
                    v => string.Join(";", v),  // Convert List<string> to string
                    v => v.Split(";", StringSplitOptions.RemoveEmptyEntries).ToList()  // Convert string to List<string>
                );
        }



    }
}
