using Domain.Interfaces;
using Entities.Entities;
using Infrastructure.Configuration;
using Infrastructure.Storage;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureModule
{
 
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddData(configuration);
        services.AddStorage(configuration);
        
        return services;
    }
    
    private static void AddData(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ContextBase>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")!));

        services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ContextBase>();
    }
    
    public static IApplicationBuilder UpdateMigrations(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope();

        var context = serviceScope?.ServiceProvider.GetRequiredService<ContextBase>();

        if (context != null)
        {
            try
            {
                var pendingMigrations = context.Database.GetPendingMigrations();
                if (pendingMigrations != null && pendingMigrations.Any())
                {
                    context.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        return app;
    }
    
    private static void AddStorage(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionStringStorage = configuration.GetConnectionString("Storage");
        
            services.AddSingleton<IStorageService>(new StorageService(connectionStringStorage, "user"));
    }
}