namespace BuildingBlocks.CQRS;

//Returns response.
public interface ICommand<out TResponse>: IRequest<TResponse> where TResponse : notnull
{
}

//Returns no response.
public interface ICommand: ICommand<Unit>
{
}
