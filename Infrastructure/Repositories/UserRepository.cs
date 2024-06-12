using Microsoft.EntityFrameworkCore;
using UserViewBack.Domain.Models;
using UserViewBack.Infrastructure.Db;
using UserViewBack.Infrastructure.Repositories.Interfaces;

namespace UserViewBack.Infrastructure.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly DbConexion _dbConexion;
        public UserRepository(DbConexion dbConexion) {
            _dbConexion = dbConexion;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _dbConexion.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _dbConexion.Users.FindAsync(id);
        }

        public async Task<User> CreateAsync(User item)
        {
            _dbConexion.Users.Add(item);
            await _dbConexion.SaveChangesAsync();
            return item;
        }

        public async Task UpdateAsync(User item)
        {
            _dbConexion.Entry(item).State = EntityState.Modified;
            try
            {
                await _dbConexion.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("Error actualizando el usuario", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _dbConexion.Users.FindAsync(id);
            if(user != null)
            {
                _dbConexion.Users.Remove(user);
                await _dbConexion.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"No se encontró el usuario con el ID: {id}");
            }
        }

        // Optimizar rendimiento insertando en lote
        public async Task CreateUsersAsync(IEnumerable<User> users)
        {
            await _dbConexion.Users.AddRangeAsync(users);
            await _dbConexion.SaveChangesAsync();
        }


    }
}
