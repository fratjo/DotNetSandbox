using Domain.Entities;

namespace Infrastructure.Contexts;

public class CacheContext
{
    public List<User> Users { get; } = new();
}
