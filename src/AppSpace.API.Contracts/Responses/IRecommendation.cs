using AppSpace.API.Contracts.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;

namespace AppSpace.API.Contracts.Responses
{
    public interface IRecommendation
    {
        string Title { get; set; }

        string Overview { get; set; }

        GenreEnum Genre { get; set; }

        LanguageEnum Language { get; set; }

        DateTime ReleaseDate { get; set; }

        DateTime FirstAirDate { get; set; }

        string Website { get; set; }

        IEnumerable<string> AssociatedKeywords { get; set; }
    }
}
