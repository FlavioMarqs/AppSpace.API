using AppSpace.API.Contracts.Enums;
using System.Collections.Generic;

namespace AppSpace.API.Contracts.GenericRequests
{
    public interface IViewerInterests
    {
        IEnumerable<string> Keywords { get; set; }

        IEnumerable<GenreEnum> Genres { get; set; }
    }
}
