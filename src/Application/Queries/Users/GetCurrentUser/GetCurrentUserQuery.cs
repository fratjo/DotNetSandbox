using Domain.Entities;
using Domain.Common;
using Application.Common.Mediator.Query;

namespace Application.Queries.Users.GetCurrentUser;

public record GetCurrentUserQuery : IQuery<Result<User>>;
