using Infrastructure;

namespace WebAPIs.Configurations;

public static class Ioc
{
    public static IServiceCollection AddIoC(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddInfrastructure(configuration);

        return services;
    }
}