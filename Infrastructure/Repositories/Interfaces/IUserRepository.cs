using UserViewBack.Domain.Dto;
using UserViewBack.Domain.Models;

namespace UserViewBack.Infrastructure.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task<User> CreateAsync(User item);
        Task UpdateAsync(User item);
        Task DeleteAsync(int id);
        // Creación en lote
        Task CreateUsersAsync(IEnumerable<User> users); 

    }
}
