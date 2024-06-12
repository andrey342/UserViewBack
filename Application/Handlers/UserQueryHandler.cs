using AutoMapper;
using UserViewBack.Application.Handlers.Interfaces;
using UserViewBack.Domain.Dto;
using UserViewBack.Domain.Models;
using UserViewBack.Infrastructure.Repositories.Interfaces;

namespace UserViewBack.Application.Handlers
{
    public class UserQueryHandler: IUserQueryHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;


        public UserQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserReadDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            // Mapeamos por buenas practicas, mas seguros
            // Para transferir datos a traves de la capa de aplicacion
            return _mapper.Map<List<UserReadDto>>(users);
        }

        public async Task<UserReadDto> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return _mapper.Map<UserReadDto>(user);
        }
    }
}
