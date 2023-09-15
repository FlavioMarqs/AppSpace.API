using AppSpace.API.Contracts.GenericRequests;

namespace AppSpace.API.Contracts.Requests
{
    public interface ISmartBillboardRequest : IUpcoming
    {
        int SmallRoomsScreensCount { get; set; }

        int BigRoomsScreensCount { get; set; }
    }
}
