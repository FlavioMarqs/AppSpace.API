using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AppSpace.Handlers.DTOs
{
    public class Week<T>
    {
        public Week(int weekNumber, IEnumerable<T> list)
        {
            WeekNumber = weekNumber;
            Values = list;
        }

        public int WeekNumber { get; set; }

        public IEnumerable<T> Values { get; set; }
    }
}
