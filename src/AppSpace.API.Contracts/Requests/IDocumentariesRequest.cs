using AppSpace.API.Contracts.Enums;
using System.Collections.Generic;

namespace AppSpace.API.Contracts.Requests
{
    public interface IDocumentariesRequest
    {
        IEnumerable<DocumentaryGenreEnum> Topics { get; set; }
    }
}
