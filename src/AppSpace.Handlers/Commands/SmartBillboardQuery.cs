using AppSpace.Handlers.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSpace.Handlers.Commands
{
    public class SmartBillboardQuery : ICommand
    {
        public int SmallRoomsCount { get; set; }

        public int BigRoomsCount { get; set; }

        public TimeSpan TimeInterval { get; set; }
    }
}
