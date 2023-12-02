using App;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
             : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Tasks> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tasks>()
            .HasOne(t => t.User)
            .WithMany(e => e.Tasks)
            .HasForeignKey(t => t.UserId);

            modelBuilder.Entity<User>().HasData(new User { Id = 1, Username = "SuperAdmin", FIO = "ADMIN", Position = "Директор", Password = UserHelper.HashPassword("Spr!Brs@Adm3") });
        }
    }
}
