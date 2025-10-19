using Application.Common.Mediator;
using Application.DTOs.UserDto;
using Domain.Common;
using Domain.Entities;

namespace Application.Commands.Users;

public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, Result<UserIdDto>>
{
    public async Task<Result<UserIdDto>> HandleAsync(CreateUserCommand command, CancellationToken cancellationToken)
    {
        // Mocked user creation logic
        var result = User.Create(command.Username);

        if (result.IsSuccess && result.Value is not null)
            return await Task.FromResult(Result<UserIdDto>.Success(new UserIdDto(result.Value.Id)));
        else
            return await Task.FromResult(Result<UserIdDto>.Failure(result.Message));
        
    }
}