using Application.Common.Mediator;
using Application.DTOs.UserDto;
using Domain.Common;
using Domain.Entities;

namespace Application.Queries.Users.GetUsers;

public record GetUsersQuery() : IQuery<List<UserDto>>;
