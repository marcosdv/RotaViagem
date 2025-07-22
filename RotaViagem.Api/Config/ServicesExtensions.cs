using Microsoft.EntityFrameworkCore;
using RotaViagem.Application.Handlers.Rotas;
using RotaViagem.Domain.Repositories;
using RotaViagem.Infra.Contexts;
using RotaViagem.Infra.Repositories;

namespace RotaViagem.Api.Config;

public static class ServicesExtensions
{
    public static void AddInjecaoDependencias(this IServiceCollection services, IConfigurationManager configuration)
    {
        AddDependenciasRepositories(services, configuration);
        AddDependenciasHandlers(services);
    }

    private static void AddDependenciasRepositories(IServiceCollection services, IConfigurationManager configuration)
    {
        services.AddDbContext<DataContext>(x =>
            x.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
        );

        services.AddScoped<IRotaRepository, RotaRepository>();
    }

    private static void AddDependenciasHandlers(IServiceCollection services)
    {
        services.AddScoped<RotaCreateHandler, RotaCreateHandler>();
        services.AddScoped<RotaUpdateHandler, RotaUpdateHandler>();
        services.AddScoped<RotaDeleteHandler, RotaDeleteHandler>();
        services.AddScoped<RotaGetAllHandler, RotaGetAllHandler>();
        services.AddScoped<RotaGetByIdHandler, RotaGetByIdHandler>();
        services.AddScoped<RotaGetMelhorRotaHandler, RotaGetMelhorRotaHandler>();
    }
}