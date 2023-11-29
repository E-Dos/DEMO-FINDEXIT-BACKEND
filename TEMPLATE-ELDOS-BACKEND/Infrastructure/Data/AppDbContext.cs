using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using TEMPLATE_ELDOS_BACKEND.App;
using TEMPLATE_ELDOS_BACKEND.Domain.Entities;

namespace TEMPLATE_ELDOS_BACKEND.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
             : base(options)
        {
            // Database.EnsureCreated();
        }

        public DbSet<SecurityResource> SecurityResources { get; set; }
        public DbSet<SecurityRole> SecurityRoles { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<SecurityRole>().HasData(
               new SecurityRole { Id = 1, Name = "SuperAdmin", },
               new SecurityRole { Id = 2, Name = "Admin", },
               new SecurityRole { Id = 3, Name = "Employee" }
                );

            modelBuilder.Entity<SecurityResource>().HasData(
              new SecurityResource { Id = 1, Name = "*" },
              new SecurityResource { Id = 2, Name = "edit.data" },
              new SecurityResource { Id = 3, Name = "export.data" }
               );

            modelBuilder.Entity<User>().HasData(new User { Id = 1, Username = "SuperAdmin", RoleId = 1, Password = UserHelper.HashPassword("Spr!Brs@Adm3"), Created = new DateTime(2023, 01, 01, 01, 01, 01), Updated = new DateTime(2023, 01, 01, 01, 01, 01) });
        }
    }
}
