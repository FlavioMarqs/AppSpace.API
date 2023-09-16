﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AppSpace.TMDB.Client.Interfaces
{
    public interface ITMDBApiClientOptions
    {
        string BaseUrl { get; }

        string AuthenticationUrl { get; }

        string DiscoverMoviesUrl { get; }

        string ApiKey { get; set; }

        string ApiToken { get; set; }
    }
}