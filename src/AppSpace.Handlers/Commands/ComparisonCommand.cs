using AppSpace.Handlers.DTOs;
using AppSpace.Handlers.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSpace.Handlers.Commands
{
    public class ComparisonCommand : ICommand
    {
        public SmartBillboardDTO QueryResult { get; set; }

        public SmartBillboardDTO CommandResult {  get; set; }
    }
}
