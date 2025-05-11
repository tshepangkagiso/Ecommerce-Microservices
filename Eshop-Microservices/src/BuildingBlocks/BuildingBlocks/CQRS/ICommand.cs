﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.CQRS
{
    //Returns response.
    public interface ICommand<out TResponse>: IRequest<TResponse> where TResponse : notnull
    {
    }

    //Returns no response.
    public interface ICommand: ICommand<Unit>
    {
    }
}
