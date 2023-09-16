using AppSpace.API.Contracts.Requests;
using AppSpace.API.Contracts.Responses;
using AppSpace.Handlers.Commands;
using AppSpace.Handlers.DTOs;
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
        private readonly ICommandHandler<SmartBillboardQuery, SmartBillboardDTO> _queryHandler;
        private readonly ICommandHandler<SmartBillboardCommand, SmartBillboardDTO> _commandHandler;
        private readonly ICommandHandler<ComparisonCommand, SmartBillboardDTO> _comparisonHandler;

        private readonly IMapper _mapper;

        public RecommendationsController(ICommandHandler<SmartBillboardQuery, SmartBillboardDTO> queryhandler,
            ICommandHandler<SmartBillboardCommand, SmartBillboardDTO> commandHandler,
            ICommandHandler<ComparisonCommand, SmartBillboardDTO> comparisonHandler,
            IMapper mapper)
        {
            _queryHandler = queryhandler ?? throw new ArgumentNullException(nameof(queryhandler));
            _commandHandler = commandHandler ?? throw new ArgumentNullException(nameof(commandHandler));
            _comparisonHandler = comparisonHandler ?? throw new ArgumentNullException(nameof(comparisonHandler));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet(Name = "GetSmartBillboards")]
        [Consumes(nameof(SmartBillboardRequest))]
        public async Task<IActionResult> GetSmartBillboards(SmartBillboardRequest request)
        {
            if (request.UseWithFilters)
            {
                var command = _mapper.Map<SmartBillboardCommand>(request);
                var commandResult = await _commandHandler.HandleAsync(command);
                var query = _mapper.Map<SmartBillboardQuery>(request);
                var queryResult = await _queryHandler.HandleAsync(query);
                var comparisonCommand = new ComparisonCommand()
                {
                    QueryResult = queryResult,
                    CommandResult = commandResult
                };
                var result = await _comparisonHandler.HandleAsync(comparisonCommand);

                return Ok(result);
            }
            else
            {
                var query = _mapper.Map<SmartBillboardQuery>(request);
                return Ok(_mapper.Map<SmartBillboardResponse>(await _queryHandler.HandleAsync(query)));
            }
        }
    }
}
