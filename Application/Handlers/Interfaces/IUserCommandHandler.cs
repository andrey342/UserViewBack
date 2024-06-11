using UserViewBack.Domain.Models;

namespace UserViewBack.Application.Handlers.Interfaces
{
    /// <summary>
    /// Interfaz para el servicio de manejo de Users
    /// </summary>
    public interface IUserCommandHandler
    {
        // Patron CQRS - logica de comandos
        Task<User> CreateAsync(UserCreateDto item);
        Task UpdateAsync(UserUpdateDto item);
        Task DeleteAsync(int id);

    }
}
