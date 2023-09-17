using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AppSpace.TMDB.Contracts.Responses
{
    public class PaginatedResult<T>
    {
        [JsonPropertyName("page")]
        public int PageNumber { get; set; }

        [JsonPropertyName("results")]
        public IEnumerable<T> Results { get; set; }

        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }

        [JsonPropertyName("total_results")]
        public int TotalResults {  get; set; }
    }
}
