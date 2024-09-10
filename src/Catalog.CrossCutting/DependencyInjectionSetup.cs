using Catalog.Application.UseCases.Categories;
using Catalog.Application.UseCases.Products;
using Catalog.Data;
using Catalog.Data.Repositories;
using Catalog.Domain.Contracts.Infra;
using Catalog.Domain.Contracts.Repositories;
using Catalog.Domain.Entities;
using Catalog.Domain.Exceptions.Infra;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Catalog.CrossCutting;

public static class DependencyInjectionSetup
{
    public static void AddCrossCuttingDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddApplicationServices();
        services.AddDataServices(configuration);
    }
    
    public static void UseCrossCuttingDependencies(this WebApplication app)
    {
        if (!app.Environment.IsDevelopment()) return;
        
        // obter logger
        var logger = app.Services.GetRequiredService<ILogger<CatalogDbContext>>();
        logger.LogInformation("Applying migrations...");
        
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<CatalogDbContext>();
        Thread.Sleep(500);
        dbContext.Database.Migrate();
    }
    
    private static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<ICategoryService, CategoryService>();
        services.AddTransient<IProductService, ProductService>();
    }
    
    private static void AddDataServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<ICategoryRepository, CategoryRepository>();
        services.AddTransient<IProductRepository, ProductRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        services.AddDbContext<CatalogDbContext>(options =>
        {
            var connString = 
                configuration.GetConnectionString("DbConnection") ??
                throw new ConnStringNullReferenceException("DbConnection not found");
            options.UseSqlServer(connString);
        });
    }
    
}