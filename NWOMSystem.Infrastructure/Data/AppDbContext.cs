namespace NWOMSystem.Infrastructure.Data
{
    using Microsoft.EntityFrameworkCore;
    using NWOMSystem.Domain.Entities;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }

        // Additional DbSets for other entities can be added here

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().ToTable("Orders");
            // Configure entity relationships and constraints here if needed
        }
    }
}