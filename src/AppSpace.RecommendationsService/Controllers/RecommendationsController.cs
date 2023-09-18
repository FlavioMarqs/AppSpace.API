using AppSpace.API.Contracts.DTOs;
using AppSpace.API.Contracts.Requests;
using AppSpace.API.Contracts.Responses;
using AppSpace.Handlers.Commands;
using AppSpace.Handlers.DTOs;
using AppSpace.Handlers.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppSpace.RecommendationsService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecommendationsController : ControllerBase
    {
        private readonly ICommandHandler<PosterRequestCommand, string> _posterHandler;
        private readonly ICommandHandler<SmartBillboardCommand, SmartBillboardDTO> _commandHandler;
        private readonly ICommandHandler<ComparisonCommand, SmartBillboardDTO> _comparisonHandler;

        private readonly IMapper _mapper;

        public RecommendationsController(
            ICommandHandler<PosterRequestCommand, string> posterHandler,
            ICommandHandler<SmartBillboardCommand, SmartBillboardDTO> commandHandler,
            ICommandHandler<ComparisonCommand, SmartBillboardDTO> comparisonHandler,
            IMapper mapper)
        {
            _posterHandler = posterHandler ?? throw new ArgumentNullException(nameof(posterHandler));
            _commandHandler = commandHandler ?? throw new ArgumentNullException(nameof(commandHandler));
            _comparisonHandler = comparisonHandler ?? throw new ArgumentNullException(nameof(comparisonHandler));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost("CreateSmartBillboards")]
        public async Task<IActionResult> CreateSmartBillboards(SmartBillboardRequest request)
        {
            if (!request.UseWithFilters)
            {
                var command = _mapper.Map<ComparisonCommand>(request);
                var result = await _comparisonHandler.HandleAsync(command);
                await FillPostersForMovies(result.BigRoomMovies);
                await FillPostersForMovies(result.SmallRoomMovies);

                return Ok(_mapper.Map<SmartBillboardResponse>(result));
            }
            else
            {
                var command = _mapper.Map<SmartBillboardCommand>(request);
                return Ok(_mapper.Map<SmartBillboardResponse>(await _commandHandler.HandleAsync(command)));
            }
        }

        private async Task FillPostersForMovies(IEnumerable<Week<Handlers.DTOs.MovieDTO>> weeklyMovies)
        {
            foreach (var movies in weeklyMovies)
            { 
                foreach (var movie in movies.Values)
                {
                    var command = new PosterRequestCommand()
                    {
                        MovieId = movie.Id,
                        Language = movie.OriginalLanguage,
                        DefaultImagePath = movie.PosterUrl
                    };

                    movie.PosterUrl = await _posterHandler.HandleAsync(command);
                } 
            }
        }
    }
}
