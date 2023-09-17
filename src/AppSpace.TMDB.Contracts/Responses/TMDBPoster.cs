using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AppSpace.TMDB.Contracts.Responses
{
    public class TMDBPoster
    {

        [JsonPropertyName("aspect_ratio")]
        public decimal AspectRatio { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("iso_639_1")]
        public string LanguageCode { get; set; }

        [JsonPropertyName("file_path")]
        public string ImagePath { get; set; }

        [JsonPropertyName("vote_average")]
        public decimal VoteAverage { get; set; }

        [JsonPropertyName("vote_count")]
        public int VoteCount { get; set; }

        [JsonPropertyName("width")]
        public int Width { get; set; }
    }
}
