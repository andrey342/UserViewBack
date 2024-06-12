using UserViewBack.Application.Handlers.Interfaces;
using UserViewBack.Domain.Models;
using UserViewBack.Infrastructure.Repositories.Interfaces;

namespace UserViewBack.Application.Handlers
{
    public class UserQueryHandler: IUserQueryHandler
    {
        private readonly IUserRepository _userRepository;

        public UserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }
    }
}
