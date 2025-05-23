namespace BuildingBlocks.CQRS;

//Returns response.
public interface IQuery<out TResponse> : IRequest<TResponse>
{
}

//Returns no response.
public interface IQuery : IQuery<Unit>
{
}
