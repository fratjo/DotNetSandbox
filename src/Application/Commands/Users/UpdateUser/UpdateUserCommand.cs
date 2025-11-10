using Application.Common.Mediator;
using Domain.Common;

namespace Application.Commands.Users.PatchUser;

public record UpdateUserCommand(Guid UserId, string? Username, int? Age) : ICommand<Result>;
