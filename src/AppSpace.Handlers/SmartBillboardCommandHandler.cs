using AppSpace.Handlers.Commands;
using AppSpace.Handlers.DTOs;
using AppSpace.Handlers.Interfaces;
using AppSpace.TMDB.Client.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppSpace.Handlers
{
    public class SmartBillboardCommandHandler : ICommandHandler<SmartBillboardCommand, SmartBillboardDTO>
    {
        private readonly IMapper _mapper;
        private readonly ITMDBApiClient _client;

        public SmartBillboardCommandHandler(IMapper mapper, ITMDBApiClient client)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public Task<SmartBillboardDTO> HandleAsync(SmartBillboardCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
