namespace BuildingBlocks.CQRS;

//Returns no response.
public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, Unit>
where TCommand : ICommand<Unit>
{
}

//Returns response.
public interface ICommandHandler<in TCommand, TResponse>: IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
    where TResponse : notnull
{
}
