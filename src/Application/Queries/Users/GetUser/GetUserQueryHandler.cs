using Application.Common.Mediator;
using Application.DTOs.UserDto;
using Domain.Common;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Queries.Users.GetUser;

public class GetUserQueryHandler(IUserRepository userRepository) : IQueryHandler<GetUserQuery, Result<UserDto>>
{
    public async Task<Result<UserDto>> HandleAsync(GetUserQuery query, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(query.UserId, cancellationToken);
        if (user is null)
        {
            return Result<UserDto>.NotFound($"User with ID {query.UserId} was not found.");
        }

        return Result<UserDto>.Success(user.ToUserDto());
    }
}
