using AutoMapper;
using Newtonsoft.Json;
using UserViewBack.Domain.Dto;
using UserViewBack.Domain.Models;
using UserViewBack.Infrastructure.Repositories.Interfaces;

namespace UserViewBack.Infrastructure.Services
{
    public class UserDownloadService: IHostedService, IDisposable
    {
        private Timer _timer;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IMapper _mapper;

        public UserDownloadService(IHttpClientFactory httpClientFactory, IServiceScopeFactory scopeFactory, IMapper mapper)
        {
            _httpClientFactory = httpClientFactory;
            _scopeFactory = scopeFactory;
            _mapper = mapper;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DownloadAndSaveUsers, null, TimeSpan.Zero, TimeSpan.FromMinutes(2));
            return Task.CompletedTask;
        }

        private async void DownloadAndSaveUsers(object state)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetStringAsync("https://jsonplaceholder.typicode.com/users");
            // Get datos dto
            // Al obtenerlos como dto se puede aplicar logica adicional como la validacion de datos
            // o tranformacion de algun tipo y tiene mayor seguridad ya que se saben que datos recibimos
            // Garantiza que los datos tienen el formato deseado
            var usersDtos = JsonConvert.DeserializeObject<List<UserCreateDto>>(response);
            // Mapeo de datos
            var users = _mapper.Map<List<User>>(usersDtos);
            using (var scope = _scopeFactory.CreateScope())
            {
                var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();
                // Optimizar el rendimiento insertando en lote
                await userRepository.CreateUsersAsync(users);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
