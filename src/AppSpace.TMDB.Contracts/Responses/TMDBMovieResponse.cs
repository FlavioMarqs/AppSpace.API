using AppSpace.TMDB.Contracts.Responses.Enums;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AppSpace.TMDB.Contracts.Responses
{
    public class TMDBMovieResponse
    {
        
         [JsonPropertyName("adult")]
         public bool IsAdultRated { get; set; }

        [JsonPropertyName("backdrop_path")]
        public string ImagePath { get; set; }

        [JsonPropertyName("genre_ids")]
        public IEnumerable<MovieGenre> Genres { get; set; }

        [JsonPropertyName("id")]
        public int Identifier { get; set; }

        [JsonPropertyName("original_language")]
        public string Language {  get; set; }

        [JsonPropertyName("original_title")]
        public string OriginalTitle { get; set; }

        [JsonPropertyName("overview")]
        public string Overview {  get; set; }

        [JsonPropertyName("popularity")]
        public decimal PopularityRating { get; set; }

        [JsonPropertyName("poster_path")]
        public string PosterPath { get; set; }

        [JsonPropertyName("release_date")]
        public string ReleaseDate { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("video")]
        public bool IsVideo { get; set; }

        [JsonPropertyName("vote_average")]
        public decimal AverageVote {  get; set; }

        [JsonPropertyName("vote_count")]
        public int VoteCount { get; set; }
    }
}
