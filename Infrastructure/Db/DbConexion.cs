using Microsoft.EntityFrameworkCore;
using System;
using UserViewBack.Domain.Models;

namespace UserViewBack.Infrastructure.Db
{
    public class DbConexion: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Geo> Geos { get; set; }
        public DbSet<Company> Companies { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\UserView;Database=UserView;Trusted_Connection=True;");
        }
        // Relaciones de las tablas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar relación uno a uno entre User y Address con eliminación en cascada
            modelBuilder.Entity<User>()
                .HasOne(u => u.Address)
                .WithMany()
                .HasForeignKey(u => u.AddressId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>()
                .HasOne(u => u.Company)
                .WithMany()
                .HasForeignKey(u => u.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Address>()
                .HasOne(a => a.Geo)
                .WithMany()
                .HasForeignKey(a => a.GeoId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
