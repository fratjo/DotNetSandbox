using Application.Common.Mediator;
using Application.DTOs.UserDto;
using Application.Queries.Users.GetCurrentUser;
using Domain.Common;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DependencyInjection;

public static partial class DependencyInjection
{
    public static IServiceCollection AddQueryHandlers(this IServiceCollection services)
    {
        services.AddScoped<IQueryHandler<GetCurrentUserQuery, Result<UserDto>>, GetCurrentUserQueryHandler>();

        return services;
    }
}
