using Domain.Entities;
using Domain.Common;
using Application.DTOs.UserDto;
using Application.Common.Mediator;

namespace Application.Queries.Users.GetCurrentUser;

public record GetCurrentUserQuery : IQuery<Result<UserDto>>;
