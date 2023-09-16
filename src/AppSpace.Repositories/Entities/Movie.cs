using System;
using System.Collections.Generic;
using System.Text;

namespace AppSpace.Repositories.Entities
{
    public class Movie
    {
        public int Id { get; set; }

        public string OriginalTitle { get; set; }

        public DateTime ReleaseDate {  get; set; }

        public string OriginalLanguage { get; set; }

        public bool Adult { get; set; }
    }
}
