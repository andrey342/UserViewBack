using UserViewBack.Domain.Models;

namespace UserViewBack.Application.Handlers.Interfaces
{
    /// <summary>
    /// Interfaz para el servicio de manejo de Users
    /// </summary>
    public interface IUserQueryHandler
    {
        // Patron CQRS - Logica de lectura
        Task<List<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
    }
}
