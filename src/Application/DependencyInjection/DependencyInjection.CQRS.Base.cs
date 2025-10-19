using Microsoft.Extensions.DependencyInjection;

namespace Application.DependencyInjection;

public static partial class DependencyInjection
{
    public static IServiceCollection AddApplicationCQRS(this IServiceCollection services)
    {
        services
            .AddCommandHandlers()
            .AddQueryHandlers();

        return services;
    }
}
