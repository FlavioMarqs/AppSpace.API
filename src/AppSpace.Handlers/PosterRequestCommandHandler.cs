using AppSpace.Handlers.Commands;
using AppSpace.Handlers.Interfaces;
using AppSpace.Repositories.Entities;
using AppSpace.TMDB.Client.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSpace.Handlers
{
    public class PosterRequestCommandHandler : ICommandHandler<PosterRequestCommand, string>
    {
        private readonly ITMDBApiClient _client;
        private const string _baseImageUrl = "https://image.tmdb.org/t/p/";

        public PosterRequestCommandHandler(ITMDBApiClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<string> HandleAsync(PosterRequestCommand command)
        {
            var posters = await _client.GetImagesForMovie(command.MovieId, command.Language);
            if (posters.Posters != null)
            {
                var poster = posters.Posters.OrderByDescending(d => d.VoteAverage).FirstOrDefault();
                return $"{_baseImageUrl}original{poster.ImagePath}";
            }
            else
            {
                return $"{_baseImageUrl}original{command.DefaultImagePath}";
            }
        }
    }
}
