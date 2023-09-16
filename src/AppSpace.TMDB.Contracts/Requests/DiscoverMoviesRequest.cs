using System;
using System.Collections.Generic;
using System.Text;

namespace AppSpace.TMDB.Contracts.Requests
{
    public class DiscoverMoviesRequest
    {
        public int? PageNumber { get; set; }

        public bool? IncludeAdult { get; set; }

        public string? Language {  get; set; }

        public int? PrimaryReleaseYear { get; set; }

        public DateTime? PrimaryReleaseDateGte { get; set; }

        public DateTime? PrimaryReleaseTimeLte { get; set;}

        public string? Region { get; set; }

        public DateTime? ReleaseDateGte { get; set; }

        public DateTime? ReleaseDateLte { get; set; }

        public string? SortBy { get; set; }

        public float? VoteAverageGte { get; set; }

        public float? VoteAverageLte { get; set; }

        public float? VoteCountGte { get; set; }

        public float? VoteCountLte { get; set; }

        public string[] Keywords { get; set; }

        public string? WithOriginalLanguage { get; set; }

        public string[] WithPeople { get; set; }

        public IDictionary<string, string> ToDictionary()
        {
            var dictionary = new Dictionary<string, string>();
            
            if (PageNumber.HasValue)
                dictionary.Add("page", $"{PageNumber}");
            if (Keywords != null)
                dictionary.Add("with_keywords", $"{string.Concat(Keywords, ',')}");
            if (IncludeAdult.HasValue)
                dictionary.Add("include_adult", $"{IncludeAdult}");
            if (!string.IsNullOrWhiteSpace(Language))
                dictionary.Add("language", $"{Language}");
            //todo: the rest. Not mandatory tho... just page should be enough

            return dictionary;
        }
    }
}
