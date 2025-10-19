using Application.Common.Mediator.Command;
using Application.Common.Mediator.Query;

namespace Application.Common.Mediator;

public interface IMediator
{
    Task<TResponse> SendAsync<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken);

    Task<TResponse> SendAsync<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken);
}

