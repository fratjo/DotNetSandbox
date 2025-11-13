using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories;

public class UnitOfWork(CacheContext context) : IUnitOfWork
{
    public async Task SaveChangesAsync(CancellationToken? cancellationToken = default) => await Task.CompletedTask;
}
