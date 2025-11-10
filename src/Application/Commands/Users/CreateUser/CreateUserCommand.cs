using Application.Common.Mediator;
using Application.DTOs.UserDto;
using Domain.Common;
using Domain.Entities;

namespace Application.Commands.Users.CreateUser;

public record CreateUserCommand(string Username, int Age) : ICommand<Result<UserIdDto>>;