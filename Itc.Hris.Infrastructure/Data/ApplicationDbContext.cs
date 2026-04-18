using Microsoft.EntityFrameworkCore;
using Itc.Hris.Model.Entities;

namespace Itc.Hris.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<AppRole> AppRole { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<VwEmployeeDetails> VwEmployeeDetails { get; set; }
        public DbSet<VwEmployeeName> VwEmployeeName { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppRole>(entity =>
            {
                entity.HasKey(e => e.RoleId);
                entity.Property(e => e.RoleName).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Key).IsRequired().HasMaxLength(100);
            });
            modelBuilder.Entity<VwEmployeeDetails>(entity =>
            {
                entity.HasNoKey(); 
                entity.ToView("vw_employee_details"); 
            });
            modelBuilder.Entity<VwEmployeeName>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("vw_employee_name");
            });
        }
    }
}
