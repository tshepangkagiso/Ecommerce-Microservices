using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.CQRS
{
    //Returns response.
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }

    //Returns no response.
    public interface IQuery : IQuery<Unit>
    {
    }
}
