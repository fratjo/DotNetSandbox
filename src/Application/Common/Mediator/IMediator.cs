namespace Application.Common.Mediator;

public interface IMediator
{
    Task<TResponse> SendAsync<TResponse>(ICommand<TResponse> command, CancellationToken? cancellationToken = null);

    Task<TResponse> SendAsync<TResponse>(IQuery<TResponse> query, CancellationToken? cancellationToken = null);
}

