using Domain.Entities;

namespace Domain.Repositories;

public interface IUserRepository : IGenericRepository<User, Guid>
{
    Task<User?> GetByUsernameAsync(string username, CancellationToken? cancellationToken = null);
}
