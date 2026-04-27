using Itc.Hris.Application.ModelView;
using Itc.Hris.Model.Entities;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<AppRolePermission> AppRolePermission { get; set; }
        public DbSet<AppMenuSetUp> AppMenuSetUp { get; set; }
        public DbSet<LoginResponse> LoginResponse { get; set; }
        public DbSet<AppRoleMenuPermission> AppRoleMenuPermission { get; set; }

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
            modelBuilder.Entity<AppRolePermission>(entity =>
            {
                entity.ToTable("app_RolePermission");

                entity.HasKey(e => e.Id);

                entity.HasIndex(e => e.EmployeeId)
                      .IsUnique()
                      .HasDatabaseName("UQ_Employee");

                entity.Property(e => e.RoleId).HasColumnName("RoleId");
                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeId");
                entity.Property(e => e.IsActive).HasColumnName("IsActive");
            });

            modelBuilder.Entity<AppMenuSetUp>(entity =>
            {
                entity.HasKey(e => e.MenuId);
                
            });
            modelBuilder.Entity<LoginResponse>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("V2_usp_check_user_login");

            });

            modelBuilder.Entity<AppRoleMenuPermission>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("app_RoleMenuPermission");
                entity.HasIndex(e => new { e.RoleId, e.MenuId })
                  .HasDatabaseName("UQ_Role_Menu") 
                  .IsUnique();

                
                entity.Property(e => e.RoleId).IsRequired();
                entity.Property(e => e.MenuId).IsRequired();
            });

        }
    }
}
