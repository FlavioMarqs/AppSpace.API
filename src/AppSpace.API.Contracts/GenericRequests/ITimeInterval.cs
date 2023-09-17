using System;
using System.Collections.Generic;
using System.Text;

namespace AppSpace.API.Contracts.GenericRequests
{
    public interface ITimeInterval
    {
        DateTime StartTime { get; set; }

        DateTime EndTime { get; set; }
    }
}
