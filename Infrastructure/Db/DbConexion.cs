using Microsoft.EntityFrameworkCore;
using System;
using UserViewBack.Domain.Models;

namespace UserViewBack.Infrastructure.Db
{
    public class DbConexion: DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\UserView;Database=UserView;Trusted_Connection=True;");
        }
        // Relaciones de las tablas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.Address)
                .WithOne()
                .HasForeignKey<Address>(a => a.Id);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Company)
                .WithOne()
                .HasForeignKey<Company>(c => c.Id);

            modelBuilder.Entity<Address>()
                .HasOne(a => a.Geo)
                .WithOne()
                .HasForeignKey<Geo>(g => g.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
