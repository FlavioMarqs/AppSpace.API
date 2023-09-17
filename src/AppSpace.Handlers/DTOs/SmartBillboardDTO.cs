using System;
using System.Collections.Generic;
using System.Text;

namespace AppSpace.Handlers.DTOs
{
    public class SmartBillboardDTO
    {
        public IEnumerable<Week<MovieDTO>> SmallRoomMovies { get; set; }

        public IEnumerable<Week<MovieDTO>> BigRoomMovies { get; set; }
    }
}
