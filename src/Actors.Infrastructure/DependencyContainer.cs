using Actors.Application.Common.Interfaces;
using Actors.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Actors.Infrastructure;
public static class DependencyContainer
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEntityFrameworkNpgsql();
        var useInMemory = bool.Parse(configuration.GetSection("UseInMemoryDatabase").Value!);
        if (useInMemory)
        {
            services.AddDbContext<ActorsContext>(options =>
                options.UseInMemoryDatabase("Actors"));
        }
        else
        {

            services.AddDbContextPool<ActorsContext>((serviceProvider, options) =>
            {
                options.UseNpgsql(
                     configuration.GetConnectionString("DefaultConnection"),
                     b =>
                     {
                         b.MigrationsAssembly(typeof(ActorsContext).Assembly.FullName);
                     });

                options.UseInternalServiceProvider(serviceProvider);
            });
        }


        services.AddScoped<IActorsContext>(provider => provider.GetRequiredService<ActorsContext>());
    }
}
