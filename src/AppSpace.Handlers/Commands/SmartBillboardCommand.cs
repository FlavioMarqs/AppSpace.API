using AppSpace.Handlers.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSpace.Handlers.Commands
{
    public class SmartBillboardCommand : SmartBillboardQuery
    {
        public IDictionary<string, string> Filters { get; set; }
    }
}
