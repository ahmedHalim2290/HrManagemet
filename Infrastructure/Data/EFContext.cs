using Domain.Base;
using Domain.Departments;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ignore the BaseDomainEvent class
            modelBuilder.Ignore<BaseDomainEvent>();

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Users)
                .WithOne(e => e.Department)
                .HasForeignKey(e => e.DepartmentId);
            
            // Other model configurations
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}