using System;
using System.Collections.Generic;
using System.Text;

namespace AppSpace.Repositories.Entities
{
    public class MovieGenre
    {
        public Movie Movie { get; set; }

        public MovieGenre Genre {get; set;}
    }
}
