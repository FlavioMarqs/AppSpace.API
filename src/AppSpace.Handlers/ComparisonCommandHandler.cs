using AppSpace.Handlers.Commands;
using AppSpace.Handlers.DTOs;
using AppSpace.Handlers.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppSpace.Handlers
{
    public class ComparisonCommandHandler : ICommandHandler<ComparisonCommand, SmartBillboardDTO>
    {
        public Task<SmartBillboardDTO> HandleAsync(ComparisonCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
