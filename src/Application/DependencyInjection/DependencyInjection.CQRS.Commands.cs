using Application.Commands.Users.CreateUser;
using Application.Commands.Users.PatchUser;
using Application.Common.Mediator;
using Application.DTOs.UserDto;
using Domain.Common;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DependencyInjection;

public static partial class DependencyInjection
{
    public static IServiceCollection AddCommandHandlers(this IServiceCollection services)
    {
        services.AddScoped<ICommandHandler<CreateUserCommand, Result<UserIdDto>>, CreateUserCommandHandler>();
        services.AddScoped<ICommandHandler<UpdateUserCommand, Result>, UpdateUserCommandHandler>();

        return services;
    }
}
