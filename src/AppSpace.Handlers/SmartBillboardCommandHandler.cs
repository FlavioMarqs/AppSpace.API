using AppSpace.Handlers.Commands;
using AppSpace.Handlers.Interfaces;
using AppSpace.TMDB.Client.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppSpace.Handlers
{
    public class SmartBillboardCommandHandler : ICommandHandler<SmartBillboardCommand, ISmartBillboardDTO>
    {
        private readonly IMapper _mapper;
        private readonly ITMDBApiClient _tmdbClient;
        
        public SmartBillboardCommandHandler(IMapper mapper, ITMDBApiClient tmdbClient) 
        { 
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _tmdbClient = tmdbClient ?? throw new ArgumentNullException(nameof(tmdbClient));
        }
        public Task<ISmartBillboardDTO> HandleAsync(SmartBillboardCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
