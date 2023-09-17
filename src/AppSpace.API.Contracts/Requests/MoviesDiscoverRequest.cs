using System;
using System.Collections.Generic;
using System.Linq;
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

        public IDictionary<string, string> ToDictionary(int pageNumber)
        {
            var dictionary = new Dictionary<string, string>();
            if (pageNumber > 0)
                dictionary.Add("page", $"{pageNumber}");
            if (Keywords != null && Keywords.Length > 0)
                dictionary.Add("with_keywords", $"{string.Join( ',', Keywords)}");
            if (IncludeAdult.HasValue)
                dictionary.Add("include_adult", $"{IncludeAdult}");
            if (!string.IsNullOrWhiteSpace(Language))
                dictionary.Add("language", $"{Language}");
            if (PrimaryReleaseYear.HasValue)
                dictionary.Add("primary_release_year", $"{PrimaryReleaseYear}");
            if (PrimaryReleaseDateGte.HasValue)
                dictionary.Add("primary_release_date.gte", $"{ToDate(PrimaryReleaseDateGte.Value)}");
            if (PrimaryReleaseDateLte.HasValue)
                dictionary.Add("primary_release_date.lte", $"{ToDate(PrimaryReleaseDateLte.Value)}");
            if (!string.IsNullOrWhiteSpace(Region))
                dictionary.Add("region", Region);
            if (ReleaseDateGte.HasValue)
                dictionary.Add("release_date.gte", $"{ToDate(ReleaseDateGte.Value)}");
            if (ReleaseDateLte.HasValue)
                dictionary.Add("release_date.lte", $"{ToDate(ReleaseDateLte.Value)}");

            //todo: the rest. Not mandatory tho... just page should be enough

            return dictionary;
        }

        private string ToDate(DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }
    }
}
