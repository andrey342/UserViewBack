using UserViewBack.Domain.Dto;
using UserViewBack.Domain.Models;

namespace UserViewBack.Application.Handlers.Interfaces
{
    /// <summary>
    /// Interfaz para el servicio de manejo de Users
    /// </summary>
    public interface IUserQueryHandler
    {
        // Patron CQRS - Logica de lectura
        Task<List<UserReadDto>> GetAllAsync();
        Task<UserReadDto> GetByIdAsync(int id);
    }
}
