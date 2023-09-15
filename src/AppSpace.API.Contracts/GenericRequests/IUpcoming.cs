using System;
using System.Collections.Generic;
using System.Text;

namespace AppSpace.API.Contracts.GenericRequests
{
    public interface IUpcoming
    {
        TimeSpan TimeFromNow { get; set; }
    }
}
