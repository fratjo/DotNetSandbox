using Application.Common.Mediator.Command;
using Domain.Common;

namespace Application.Commands.Users;

public record CreateUserCommand(string Username) : ICommand<Result<Guid>>;