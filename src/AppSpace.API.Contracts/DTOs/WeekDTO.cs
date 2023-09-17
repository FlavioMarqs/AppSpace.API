using System;
using System.Collections.Generic;
using System.Text;

namespace AppSpace.API.Contracts.DTOs
{
    public class WeekDTO<T>
    {
        public int WeekNumber { get; set; }

        public IEnumerable<T> Values { get; set; }
    }
}
