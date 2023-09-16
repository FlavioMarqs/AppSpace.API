using AppSpace.API.Contracts.GenericRequests;

namespace AppSpace.API.Contracts.Requests
{
    public interface ISmartBillboardRequest : ITimeInterval
    {
        int SmallRoomsScreensCount { get; set; }

        int BigRoomsScreensCount { get; set; }

        bool UseOnlyFilters { get; set; }
    }
}
