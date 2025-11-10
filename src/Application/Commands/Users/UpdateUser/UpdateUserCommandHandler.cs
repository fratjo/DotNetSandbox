using Application.Common.Mediator;
using Domain.Common;
using Domain.Repositories;

namespace Application.Commands.Users.PatchUser;

public class UpdateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork) : ICommandHandler<UpdateUserCommand, Result>
{
    public async Task<Result> HandleAsync(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(command.UserId, cancellationToken);
        if (user is null)
            return Result.NotFound("User not found.");
        
        if (command.Username is not null)
        {
            var updateResult = user.UpdateUsername(command.Username);
            if (!updateResult.IsSuccess)
                return updateResult;
        }

        if (command.Age is not null)
        {
            var updateResult = user.UpdateAge(command.Age.Value);
            if (!updateResult.IsSuccess)
                return updateResult;
        }

        await userRepository.UpdateAsync(user, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success("Username updated successfully.");
    }
}
