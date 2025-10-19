using Application.Common.Mediator;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyInjection;

public static partial class DependencyInjection
{
    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddScoped<IMediator, Mediator.Mediator>();

        return services;
    }
}
