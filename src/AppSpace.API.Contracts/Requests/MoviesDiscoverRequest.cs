using System;
using System.Collections.Generic;
using System.Text;

namespace AppSpace.API.Contracts.Requests
{
    public class MoviesDiscoverRequest
    {
        public bool? IncludeAdult { get; set; }

        public string Language { get; set; }

        public int? PrimaryReleaseYear { get; set; }

        public DateTime? PrimaryReleaseDateGte { get; set; }

        public DateTime? PrimaryReleaseDateLte { get; set; }

        public string Region { get; set; }

        public DateTime? ReleaseDateGte { get; set; }

        public DateTime? ReleaseDateLte { get; set; }

        public string[] Keywords { get; set; }
    }
}
