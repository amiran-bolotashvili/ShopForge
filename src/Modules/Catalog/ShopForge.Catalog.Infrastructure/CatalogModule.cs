using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopForge.Catalog.Application;
using ShopForge.Catalog.Application.Abstractions;
using ShopForge.Catalog.Infrastructure.Database;

namespace ShopForge.Catalog.Infrastructure;

public static class CatalogModule
{
    public static IServiceCollection AddCatalogModule(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCatalogApplication();
        services.AddCatalogInfrastructure(configuration);
        return services;
    }

    public static IServiceCollection AddCatalogInfrastructure(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CatalogDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("Database"),
                sql => sql.MigrationsHistoryTable("_EFMigrationsHistory", Schemas.Catalog)));

        services.AddScoped<ICatalogDbContext>(sp => sp.GetRequiredService<CatalogDbContext>());

        return services;
    }
}
