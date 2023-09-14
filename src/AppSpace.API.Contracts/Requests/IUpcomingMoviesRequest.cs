using AppSpace.API.Contracts.Enums;
using AppSpace.API.Contracts.GenericRequests;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSpace.API.Contracts.Requests
{
    public interface IUpcomingMoviesRequest : IUpcoming
    {
        AgeRateEnum AgeRate { get; set; }

        GenreEnum Genre { get; set; }
    }
}
