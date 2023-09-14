using AppSpace.API.Contracts.GenericRequests;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSpace.API.Contracts.Requests
{
    public interface ISuggestedBillboardsRequest : IUpcoming
    {
        int Screens { get; set; }
    }
}
