using Hangfire;
using Hangfire.SqlServer;
using UserViewBack.Application.Handlers;
using UserViewBack.Application.Handlers.Interfaces;
using UserViewBack.Infrastructure.Db;
using UserViewBack.Infrastructure.Mapping;
using UserViewBack.Infrastructure.Repositories;
using UserViewBack.Infrastructure.Repositories.Interfaces;
using UserViewBack.Infrastructure.Services;
using UserViewBack.Infrastructure.Services.hangfire;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// IoC
builder.Services.AddDbContext<DbConexion>(); // Db
builder.Services.AddScoped<IUserCommandHandler, UserCommandHandler>(); // CQRS Escritura 
builder.Services.AddScoped<IUserQueryHandler, UserQueryHandler>(); // CQRS  Lectura
builder.Services.AddScoped<IUserRepository, UserRepository>(); // IREPO -> Repo

// Configurar AutoMapper para mapear DTOs a las entidades
builder.Services.AddAutoMapper(typeof(UserMappings));
// Registrar el HttpClientFactory para crear instancias HttpClient
builder.Services.AddHttpClient();
// Registrar el UserDownloadService
builder.Services.AddHostedService<UserDownloadService>();

// Configurar Hangfire para usar SQL Server para almacenar trabajos en segundo plano y registrar servidor
builder.Services.AddHangfire(config => config
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection"), new SqlServerStorageOptions
    {
        CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
        SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
        QueuePollInterval = TimeSpan.Zero,
        UseRecommendedIsolationLevel = true,
        DisableGlobalLocks = true
    }));

// Registrar el UserDownloadService como trabajo recurrente
builder.Services.AddSingleton<IHangfireUserDownloadService, HangfireUserDownloadService>();


// Agregar el servidor de Hangfire
builder.Services.AddHangfireServer();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Usar el panel de Hangfire donde ver y gestionar trabajos en segundo plano
app.UseHangfireDashboard();

// Configurar el trabajo recurrente para ejecutar cada 1 min
RecurringJob.AddOrUpdate<IHangfireUserDownloadService>(
    service => service.DownloadAndSaveUsers(),
    Cron.MinuteInterval(1));

app.Run();
