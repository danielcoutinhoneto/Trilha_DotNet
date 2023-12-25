using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ResTIConnect.Domain.Interfaces;
using ResTIConnect.Persistence.Context;
using ResTIConnect.Persistence.Repositories;

namespace ResTIConnect.Persistence;

public static class ServiceExtensions
{
    public static void ConfigurePersistenceApp(this IServiceCollection services, IConfiguration configuration)

    {
        var connectionString = configuration.GetConnectionString("Sqlite");
        services.AddDbContext<AppDbContext>(opt => opt.UseSqlite(connectionString));

        services.AddScoped<IUnitofWork, UnitOfWork>();
        services.AddScoped<IUserRepository, UserRepository>();
    }
}
