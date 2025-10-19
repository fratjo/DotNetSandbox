using Domain.Entities;
using Domain.Common;
using Application.DTOs.UserDto;
using Application.Common.Mediator;

namespace Application.Queries.Users.GetCurrentUser;

public class GetCurrentUserQueryHandler : IQueryHandler<GetCurrentUserQuery, Result<UserDto>>
{
    public async Task<Result<UserDto>> HandleAsync(GetCurrentUserQuery query, CancellationToken cancellationToken)
    {
        // Mocked user retrieval from http context or authentication service
        var username = Environment.UserName;

        // Mocked user retrieval from some data source could be placed here
        var result = User.Create(username);

        if (result.IsSuccess && result.Value is not null)
        {
            var user = result.Value;
            var userDto = new UserDto(user.Id, user.Username);
            return await Task.FromResult(Result<UserDto>.Success(userDto));
        }
        else
        {
            return await Task.FromResult(Result<UserDto>.Failure("User not found."));
        }
    }
}
