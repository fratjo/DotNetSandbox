using Application.Common.Mediator;
using Application.DTOs.UserDto;
using Application.Queries.Users.GetUser;
using Application.Queries.Users.GetUsers;
using Domain.Common;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DependencyInjection;

public static partial class DependencyInjection
{
    public static IServiceCollection AddQueryHandlers(this IServiceCollection services)
    {
        services.AddScoped<IQueryHandler<GetUserQuery, UserDto>, GetUserQueryHandler>();
        services.AddScoped<IQueryHandler<GetUsersQuery, List<UserDto>>, GetUsersQueryHandler>();

        return services;
    }
}
