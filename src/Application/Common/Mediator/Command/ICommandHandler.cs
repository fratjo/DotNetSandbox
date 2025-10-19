namespace Application.Common.Mediator.Command;

public interface ICommandHandler<in TCommand, TResponse> where TCommand : ICommand<TResponse>
{
    Task<TResponse> HandleAsync(TCommand command, CancellationToken cancellationToken);
}

public interface ICommandHandler<in TCommand> : ICommandHandler<TCommand, Unit> where TCommand : ICommand;