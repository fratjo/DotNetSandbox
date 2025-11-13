using System.Security.Cryptography;

namespace Domain.Repositories;

public interface IGenericRepository<TEntity, TId> where TEntity : class
{
    Task<TEntity?> GetByIdAsync(TId id, CancellationToken? cancellationToken = null);
    Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken? cancellationToken = null);
    Task AddAsync(TEntity entity, CancellationToken? cancellationToken = null);
    Task UpdateAsync(TEntity entity, CancellationToken? cancellationToken = null);
    Task DeleteAsync(TEntity entity, CancellationToken? cancellationToken = null);
}
