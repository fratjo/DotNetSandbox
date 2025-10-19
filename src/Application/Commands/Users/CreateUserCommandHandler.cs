using Application.Common.Mediator.Command;
using Domain.Common;
using Domain.Entities;

namespace Application.Commands.Users;

public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, Result<Guid>>
{
    public async Task<Result<Guid>> HandleAsync(CreateUserCommand command, CancellationToken cancellationToken)
    {
        // Mocked user creation logic
        var result = User.Create(command.Username);

        if (result.IsSuccess && result.Value is not null)
            return await Task.FromResult(Result<Guid>.Success(result.Value.Id));
        else
            return await Task.FromResult(Result<Guid>.Failure(result.Message));
        
    }
}