using AutoMapper;
using UserViewBack.Application.Handlers.Interfaces;
using UserViewBack.Domain.Dto;
using UserViewBack.Domain.Models;
using UserViewBack.Infrastructure.Repositories.Interfaces;

namespace UserViewBack.Application.Handlers
{
    public class UserCommandHandler: IUserCommandHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<User> CreateAsync(UserCreateDto item)
        {
            var user = _mapper.Map<User>(item);
            return await _userRepository.CreateAsync(user);
        }

        public async Task UpdateAsync(UserUpdateDto item)
        {
            var user = _mapper.Map<User>(item); 
            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
        }
    }
}
