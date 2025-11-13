using Application.Common.Mediator;
using Application.DTOs.UserDto;
using Domain.Common;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Commands.Users.CreateUser;

public class CreateUserCommandHandler(IUserRepository userRepository) : ICommandHandler<CreateUserCommand, Result<UserIdDto>>
{
    public async Task<Result<UserIdDto>> HandleAsync(CreateUserCommand command, CancellationToken? cancellationToken = null)
    {
        var existingUser = await userRepository.GetByUsernameAsync(command.Username.ToUpperInvariant(), cancellationToken);
        if (existingUser is not null)
            return Result<UserIdDto>.Conflict("Username already exists.");

        var result = User.Create(command.Username, command.Age);

        if (result.IsSuccess && result.Value is not null)
        {
            await userRepository.AddAsync(result.Value, cancellationToken);
            return await Task.FromResult(Result<UserIdDto>.Success(new UserIdDto(result.Value.Id)));
        }
        else
            return await Task.FromResult(Result<UserIdDto>.Failure(result.Message));
        
    }
}