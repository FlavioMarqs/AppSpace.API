using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AppSpace.TMDB.Contracts.Responses
{
    public class TMDBMovieImageResponse
    {
        [JsonPropertyName("backdrops")]
        public IEnumerable<TMDBBackDrop> BackDrops { get; set; }

        [JsonPropertyName("logos")]
        public IEnumerable<TMDBLogo> Logos { get; set; }

        [JsonPropertyName("posters")]
        public IEnumerable<TMDBPoster> Posters { get; set; }
    }
}
