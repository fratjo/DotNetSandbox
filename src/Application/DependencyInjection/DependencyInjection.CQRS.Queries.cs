using Application.Common.Mediator;
using Application.DTOs.UserDto;
using Application.Queries.Users.GetUser;
using Domain.Common;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DependencyInjection;

public static partial class DependencyInjection
{
    public static IServiceCollection AddQueryHandlers(this IServiceCollection services)
    {
        services.AddScoped<IQueryHandler<GetUserQuery, Result<UserDto>>, GetUserQueryHandler>();

        return services;
    }
}
