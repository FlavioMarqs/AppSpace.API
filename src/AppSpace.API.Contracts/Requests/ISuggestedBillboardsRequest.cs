using AppSpace.API.Contracts.GenericRequests;

namespace AppSpace.API.Contracts.Requests
{
    public interface ISuggestedBillboardsRequest : ITimeInterval
    {
        int Screens { get; set; }
    }
}
