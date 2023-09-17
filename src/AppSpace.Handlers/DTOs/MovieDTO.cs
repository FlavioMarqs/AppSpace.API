using System;
using System.Collections.Generic;
using System.Text;

namespace AppSpace.Handlers.DTOs
{
    public class MovieDTO
    {
        public int Id { get; set; }

        public string OriginalTitle { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string OriginalLanguage { get; set; }

        public bool Adult { get; set; }

        public string PosterPath { get; set; }
    }
}
