namespace UserViewBack.Infrastructure.Services.hangfire
{
    // Interfaz del servicio de descarga de usuarios
    public interface IHangfireUserDownloadService
    {
        Task DownloadAndSaveUsers();
    }
}
