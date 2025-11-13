using Application.Common.Mediator;
using Application.DTOs.UserDto;
using Domain.Common;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Queries.Users.GetUsers;

public class GetUsersQueryHandler(IUserRepository userRepository) : IQueryHandler<GetUsersQuery, List<UserDto>>
{
    public async Task<List<UserDto>> HandleAsync(GetUsersQuery query, CancellationToken? cancellationToken)
    {
        var users = await userRepository.GetAllAsync(cancellationToken);
        return users.Select(user => user.ToUserDto()).ToList();
    }
}
