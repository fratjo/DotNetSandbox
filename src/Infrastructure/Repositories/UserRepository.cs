using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories;

public class UserRepository(CacheContext context) : IUserRepository
{
    public async Task AddAsync(User entity, CancellationToken cancellationToken = default)
    {
        context.Users.Add(entity);
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(User entity, CancellationToken cancellationToken = default)
    {
        context.Users.Remove(entity);
        await Task.CompletedTask;
    }

    public async Task<IReadOnlyList<User>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await Task.FromResult(context.Users.ToList());
    }

    public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await Task.FromResult(context.Users.FirstOrDefault(u => u.Id == id));
    }

    public async Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken = default)
    {
        return await Task.FromResult(context.Users.FirstOrDefault(u => u.Username == username));
    }

    public async Task UpdateAsync(User entity, CancellationToken cancellationToken = default)
    {
        var u = context.Users.FirstOrDefault(x => x.Id == entity.Id);
        if (u != null)
        {
            context.Users.Remove(u);
            context.Users.Add(entity);
        }
        await Task.CompletedTask;
    }
}
