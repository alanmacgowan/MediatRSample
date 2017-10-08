using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatRSample.Domain
{
    public enum OrderStatus
    {
        Placed = 0,
        Shipped = 1,
        Cancelled = 2,
    }
}
