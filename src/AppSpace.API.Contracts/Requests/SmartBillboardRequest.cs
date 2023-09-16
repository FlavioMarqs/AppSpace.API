using AppSpace.API.Contracts.GenericRequests;
using System;

namespace AppSpace.API.Contracts.Requests
{
    public class SmartBillboardRequest : ITimeInterval
    {
        public int SmallRoomsScreensCount { get; set; }

        public int BigRoomsScreensCount { get; set; }

        public MoviesDiscoverRequest Filters { get; set; }

        public bool UseWithFilters { get; set; }

        public DateTime StartTime { get; set; }
        
        public DateTime EndTime { get; set; }
    }
}
