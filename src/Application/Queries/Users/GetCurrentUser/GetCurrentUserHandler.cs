using Domain.Entities;
using Domain.Common;
using Application.Common.Mediator.Query;

namespace Application.Queries.Users.GetCurrentUser;

public class GetCurrentUserHandler : IQueryHandler<GetCurrentUserQuery, Result<User>>
{
    public async Task<Result<User>> HandleAsync(GetCurrentUserQuery query, CancellationToken cancellationToken)
    {
        // Mocked user retrieval
        var username = Environment.UserName;
        
        var result = User.Create(username);

        return await Task.FromResult(result);
    }
}
