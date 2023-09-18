using AppSpace.Handlers.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSpace.Handlers.Commands
{
    public class PosterRequestCommand : ICommand
    {
        public int MovieId { get; set; }

        public string Language { get; set; }

        public string DefaultImagePath { get; set; }
    }
}
