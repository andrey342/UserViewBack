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
    }
}
