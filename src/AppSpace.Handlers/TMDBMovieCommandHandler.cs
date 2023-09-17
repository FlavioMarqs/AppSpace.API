using AppSpace.Handlers.Commands;
using AppSpace.Handlers.DTOs;
using AppSpace.Handlers.Interfaces;
using AppSpace.TMDB.Client.Interfaces;
using AutoMapper;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AppSpace.Handlers
{
    public class TMDBMovieCommandHandler : ICommandHandler<TMDBMovieCommand, MovieDTO>
    {
        private readonly IMapper _mapper;
        private readonly ITMDBApiClient _client;

        public TMDBMovieCommandHandler(IMapper mapper, ITMDBApiClient client)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<MovieDTO> HandleAsync(TMDBMovieCommand command)
        {
            var results = await _client.SearchMovieByTitleAsync(command.OriginalTitle, command.ReleaseYear);
            return _mapper.Map<MovieDTO>(results.Results.FirstOrDefault());
        }
    }
}
