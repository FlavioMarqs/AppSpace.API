using AppSpace.API.Contracts.Enums;
using AppSpace.API.Contracts.GenericRequests;

namespace AppSpace.API.Contracts.Requests
{
    public interface IUpcomingMoviesRequest : IUpcoming
    {
        AgeRateEnum AgeRate { get; set; }

        GenreEnum Genre { get; set; }
    }
}
