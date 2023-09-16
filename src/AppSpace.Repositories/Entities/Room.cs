using System;
using System.Collections.Generic;
using System.Text;

namespace AppSpace.Repositories.Entities
{
    public class Room
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Size { get; set; }

        public int Seats { get; set; }

        public Cinema Cinema { get; set; }
    }
}
