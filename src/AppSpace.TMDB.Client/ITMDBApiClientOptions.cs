using System;
using System.Collections.Generic;
using System.Text;

namespace AppSpace.TMDB.Client
{
    public interface ITMDBApiClientOptions
    {
        string AuthenticationUrl { get; set; }

        string ApiKey { get; set; }

        string ApiToken { get; set; }

        string ApiKeySecret { get; set; }

        string ApiTokenSecret { get; set; }
    }
}
