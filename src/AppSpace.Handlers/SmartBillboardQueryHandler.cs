using AppSpace.Handlers.Commands;
using AppSpace.Handlers.DTOs;
using AppSpace.Handlers.Interfaces;
using AppSpace.Repositories;
using AppSpace.TMDB.Client.Interfaces;
using AutoMapper;
using Microsoft.VisualBasic;
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
        private readonly BeezyDbContext _dbContext;
        
        public SmartBillboardQueryHandler(IMapper mapper, BeezyDbContext dbContext) 
        { 
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public Task<SmartBillboardDTO> HandleAsync(SmartBillboardQuery command)
        {
            var weekCount = command.TimeInterval.Days % 7 == 0 ? command.TimeInterval.Days / 7 : command.TimeInterval.Days / 7 + 1;
            var smallRoomSuggestedBillboards = GetMovies(weekCount, command.SmallRoomsCount, "Small");
            var bigRoomSuggestedBillboards = GetMovies(weekCount, command.BigRoomsCount, "Big");

            return Task.FromResult(new SmartBillboardDTO()
            {
                SmallRoomMovies = smallRoomSuggestedBillboards,
                BigRoomMovies = bigRoomSuggestedBillboards
            });
        }

        private Week<MovieDTO> GetMoviesForWeek(int weekNumber, int roomsCount, string roomSize)
        {
            var results = _dbContext.Session.Where(d => d.Room.Size.Equals(roomSize)).OrderByDescending(d => d.SeatsSold).Skip(weekNumber * roomsCount).Take(roomsCount).Select(d => d.Movie).ToList();
            var weeklyData = new Week<MovieDTO>(weekNumber, _mapper.Map<IList<MovieDTO>>(results));

            return weeklyData;
        }

        private IEnumerable<Week<MovieDTO>> GetMovies(int weekCount, int roomsCount, string roomSize)
        {
            var weeklyMoviesForRoom = new List<Week<MovieDTO>>();
            for(int i= 0; i < weekCount; i++)
            {
                weeklyMoviesForRoom.Add(GetMoviesForWeek(i, roomsCount, roomSize));
            }

            return weeklyMoviesForRoom;
        }
    }
}
