using AppSpace.Handlers.Commands;
using AppSpace.Handlers.DTOs;
using AppSpace.Handlers.Interfaces;
using AppSpace.Repositories;
using AppSpace.Repositories.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSpace.Handlers
{
    public class SmartBillboardQueryHandler : ICommandHandler<SmartBillboardQuery, SmartBillboardDTO>
    {
        private readonly IMapper _mapper;
        private readonly ITopRatedMoviesRepository _moviesRepository;
        
        public SmartBillboardQueryHandler(IMapper mapper, ITopRatedMoviesRepository moviesRepository) 
        { 
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _moviesRepository = moviesRepository ?? throw new ArgumentNullException(nameof(moviesRepository));
        }
        public async Task<SmartBillboardDTO> HandleAsync(SmartBillboardQuery command)
        {
            var weekCount = command.TimeInterval.Days % 7 == 0 ? command.TimeInterval.Days / 7 : command.TimeInterval.Days / 7 + 1;
            var smallRoomSuggestedBillboards = await GetMovies(weekCount, command.SmallRoomsCount, "Small");
            var bigRoomSuggestedBillboards = await GetMovies(weekCount, command.BigRoomsCount, "Big");

            return new SmartBillboardDTO()
            {
                SmallRoomMovies = smallRoomSuggestedBillboards,
                BigRoomMovies = bigRoomSuggestedBillboards
            };
        }

        private async Task<Week<MovieDTO>> GetMoviesForWeek(int weekNumber, int roomsCount, string roomSize)
        {
            var movies = await _moviesRepository.GetTopRatedMoviesAsync(weekNumber, roomsCount, roomSize);

            var weeklyData = new Week<MovieDTO>(weekNumber, _mapper.Map<IList<MovieDTO>>(movies));

            return weeklyData;
        }

        private async Task<IEnumerable<Week<MovieDTO>>> GetMovies(int weekCount, int roomsCount, string roomSize)
        {
            var weeklyMoviesForRoom = new List<Week<MovieDTO>>();
            for(int week= 1; week <= weekCount; week++)
            {
                weeklyMoviesForRoom.Add(await GetMoviesForWeek(week, roomsCount, roomSize));
            }

            return weeklyMoviesForRoom;
        }
    }
}
