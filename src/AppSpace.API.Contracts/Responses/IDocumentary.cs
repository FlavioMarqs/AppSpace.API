using AppSpace.API.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSpace.API.Contracts.Responses
{
    public interface IDocumentary : IRecommendation
    {
        DocumentaryGenreEnum Topic { get; set; }
    }
}
