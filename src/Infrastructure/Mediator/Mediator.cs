using Application.Common.Mediator;

namespace Infrastructure.Mediator;

public class Mediator(IServiceProvider serviceProvider) : IMediator
{
    public async Task<TResponse> SendAsync<TResponse>(ICommand<TResponse> command, CancellationToken? cancellationToken = null)
    {
        var handlerType = typeof(ICommandHandler<,>).MakeGenericType(command.GetType(), typeof(TResponse));
        var handler = serviceProvider.GetService(handlerType);
        if (handler == null)
            throw new InvalidOperationException($"No handler found for command of type {command.GetType().Name}");

        return await ((dynamic)handler).HandleAsync((dynamic)command, cancellationToken);
    }

    public async Task<TResponse> SendAsync<TResponse>(IQuery<TResponse> query, CancellationToken? cancellationToken = null)
    {
        var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResponse));
        var handler = serviceProvider.GetService(handlerType);
        if (handler == null)
            throw new InvalidOperationException($"No handler found for query of type {query.GetType().Name}");

        return await ((dynamic)handler).HandleAsync((dynamic)query, cancellationToken);
    }
}
