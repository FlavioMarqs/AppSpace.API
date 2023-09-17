using AppSpace.Handlers.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSpace.Handlers.Commands
{
    public class TMDBMovieCommand : ICommand
    {
        public string OriginalTitle { get; set; }

        public int ReleaseYear { get; set; }

        public string[] Keywords { get; set; }
    }
}
