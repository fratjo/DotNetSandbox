using Domain.Entities;
using Domain.Common;
using Application.Common.Mediator.Query;

namespace Application.Queries.Users.GetCurrentUser;

public class GetCurrentUserQueryHandler : IQueryHandler<GetCurrentUserQuery, Result<User>>
{
    public async Task<Result<User>> HandleAsync(GetCurrentUserQuery query, CancellationToken cancellationToken)
    {
        // Mocked user retrieval from http context or authentication service
        var username = Environment.UserName;

        // Mocked user retrieval from some data source could be placed here
        var result = User.Create(username);

        return await Task.FromResult(result);
    }
}
