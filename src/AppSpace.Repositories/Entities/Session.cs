using System;
using System.Collections.Generic;
using System.Text;

namespace AppSpace.Repositories.Entities
{
    public class Session
    {
        public int Id { get; set; }

        public Room Room { get; set; }

        public Movie Movie { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int SeatsSold { get; set; }
    }
}
