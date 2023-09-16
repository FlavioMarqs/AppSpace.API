using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AppSpace.TMDB.Contracts.Responses
{
    public class AuthenticationResponse
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("status_code")]
        public int StatusCode { get; set; }

        [JsonPropertyName("status_message")]
        public string StatusMessage {get; set;}
    }
}
