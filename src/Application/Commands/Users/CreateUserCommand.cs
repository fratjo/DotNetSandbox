using Application.Common.Mediator;
using Application.DTOs.UserDto;
using Domain.Common;

namespace Application.Commands.Users;

public record CreateUserCommand(string Username) : ICommand<Result<UserIdDto>>;