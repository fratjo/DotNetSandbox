namespace Application.Common.Mediator.Command;

public interface ICommand<TResponse>;

public interface ICommand : ICommand<Unit>;

public struct Unit
{
    public static readonly Unit Value = new Unit();
}