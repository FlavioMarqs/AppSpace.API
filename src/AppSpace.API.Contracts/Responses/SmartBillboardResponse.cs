using AppSpace.API.Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSpace.API.Contracts.Responses
{
    public class SmartBillboardResponse
    {
        public IEnumerable<WeekDTO<MovieDTO>> SmallRoomMovies { get; set; }

        public IEnumerable<WeekDTO<MovieDTO>> BigRoomMovies { get; set; }
    }
}
