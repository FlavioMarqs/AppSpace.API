using AppSpace.Handlers.Commands;
using AppSpace.Handlers.DTOs;
using AppSpace.Handlers.Interfaces;
using AppSpace.TMDB.Client.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<SmartBillboardDTO> HandleAsync(SmartBillboardCommand command)
        {
            var weekCount = command.TimeInterval.Days % 7 == 0 ? command.TimeInterval.Days / 7 : command.TimeInterval.Days / 7 + 1;
            var bigRoomSuggestedBillboards = await GetMovies(weekCount, command.BigRoomsCount, command.Filters);
            var smallRoomSuggestedBillboards = await GetMovies(weekCount, command.SmallRoomsCount, command.Filters);

            return new SmartBillboardDTO()
            {
                SmallRoomMovies = smallRoomSuggestedBillboards,
                BigRoomMovies = bigRoomSuggestedBillboards
            };
        }

        private async Task<IList<Week<MovieDTO>>> GetMovies(int weekCount, int roomsCount, IDictionary<string, string> filters, int skip = 0)
        {
            var weeklyMoviesForRoom = new List<Week<MovieDTO>>();
            for (int week = 0; week < weekCount; week++)
            {
                weeklyMoviesForRoom.Add(await GetMoviesForWeek(week+1, roomsCount, filters, skip));
                skip += (roomsCount);
            }

            return weeklyMoviesForRoom;
        }

        private async Task<Week<MovieDTO>> GetMoviesForWeek(int weekNumber, int roomsCount, IDictionary<string, string> filters, int skip)
        {
            var pageNumber = 1;
            var results = new List<MovieDTO>();
            while (pageNumber <= (roomsCount * weekNumber))
            {
                var clientResults = await _client.GetMovieDiscoveryAsync(filters, pageNumber);
                results.AddRange(_mapper.Map<IEnumerable<MovieDTO>>(clientResults.Results).Skip(skip).Take(roomsCount - clientResults.Results.Count() > 0 ? roomsCount - clientResults.Results.Count() : roomsCount - results.Count));
                if (clientResults.TotalPages > pageNumber && results.Count() < roomsCount)
                {     
                    pageNumber++;
                    skip = 0;
                }
                else
                { 
                    break; 
                }
            }

            var weeklyData = new Week<MovieDTO>(weekNumber, results);

            return weeklyData;
        }
    }
}
