using AutoMapper;
using Newtonsoft.Json;
using UserViewBack.Domain.Dto;
using UserViewBack.Domain.Models;
using UserViewBack.Infrastructure.Repositories.Interfaces;

namespace UserViewBack.Infrastructure.Services.hangfire
{
    public class HangfireUserDownloadService: IHangfireUserDownloadService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IMapper _mapper;

        public HangfireUserDownloadService(IHttpClientFactory httpClientFactory, IServiceScopeFactory scopeFactory, IMapper mapper)
        {
            _httpClientFactory = httpClientFactory;
            _scopeFactory = scopeFactory;
            _mapper = mapper;
        }

        public async Task DownloadAndSaveUsers()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetStringAsync("https://jsonplaceholder.typicode.com/users");
            var userDtos = JsonConvert.DeserializeObject<List<UserCreateDto>>(response);

            var users = _mapper.Map<List<User>>(userDtos);

            using (var scope = _scopeFactory.CreateScope())
            {
                var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();
                await userRepository.CreateUsersAsync(users);
            }
        }
    }
}
