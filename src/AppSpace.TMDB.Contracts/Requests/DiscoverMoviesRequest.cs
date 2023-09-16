using System;
using System.Collections.Generic;
using System.Text;

namespace AppSpace.TMDB.Contracts.Requests
{
    public class DiscoverMoviesRequest
    {
        public bool? IncludeAdult { get; set; }

        public string Language {  get; set; }

        public int? PrimaryReleaseYear { get; set; }

        public DateTime? PrimaryReleaseDateGte { get; set; }

        public DateTime? PrimaryReleaseDateLte { get; set;}

        public string Region { get; set; }

        public DateTime? ReleaseDateGte { get; set; }

        public DateTime? ReleaseDateLte { get; set; }

        public string SortBy { get; set; }

        public float? VoteAverageGte { get; set; }

        public float? VoteAverageLte { get; set; }

        public float? VoteCountGte { get; set; }

        public float? VoteCountLte { get; set; }

        public string[] Keywords { get; set; }

        public string WithOriginalLanguage { get; set; }

        public string[] WithPeople { get; set; }

        public IDictionary<string, string> ToDictionary(int pageNumber)
        {
            var dictionary = new Dictionary<string, string>();
            if(pageNumber > 0)
                dictionary.Add("page", $"{pageNumber}");
            if (Keywords != null)
                dictionary.Add("with_keywords", $"{string.Concat(Keywords, ',')}");
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
            if(ReleaseDateGte.HasValue)
                dictionary.Add("release_date.gte", $"{ToDate(ReleaseDateGte.Value)}");
            if (ReleaseDateLte.HasValue)
                dictionary.Add("release_date.lte", $"{ToDate(PrimaryReleaseDateLte.Value)}");
             
            //todo: the rest. Not mandatory tho... just page should be enough

            return dictionary;
        }

        private string ToDate(DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }
    }
}
