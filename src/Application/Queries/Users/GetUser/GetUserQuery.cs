using Application.Common.Mediator;
using Application.DTOs.UserDto;
using Domain.Common;
using Domain.Entities;

namespace Application.Queries.Users.GetUser;

public record GetUserQuery(Guid UserId) : IQuery<Result<UserDto>>;
