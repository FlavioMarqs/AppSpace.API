using AppSpace.API.Contracts.Requests;
using AppSpace.API.Contracts.Responses;
using AppSpace.Handlers.Commands;
using AppSpace.Handlers.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AppSpace.RecommendationsService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecommendationsController : ControllerBase
    {
        private readonly ICommandHandler<SmartBillboardCommand, SmartBillboardResponse> _handler;
        private readonly IMapper _mapper;

        public RecommendationsController(ICommandHandler<SmartBillboardCommand, SmartBillboardResponse> handler,
            IMapper mapper)
        {
            _handler = handler ?? throw new ArgumentNullException(nameof(handler));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet(Name = "GetSmartBillboards")]
        [Consumes(nameof(ISmartBillboardRequest))]
        public async Task<IActionResult> GetSmartBillboards(ISmartBillboardRequest request) 
        {
            var command = _mapper.Map<SmartBillboardCommand>(request);
            return Ok(_mapper.Map<SmartBillboardResponse>(await _handler.HandleAsync(command)));
        }
    }
}
