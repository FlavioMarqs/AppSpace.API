using AppSpace.Handlers.Commands;
using AppSpace.Handlers.DTOs;
using AppSpace.Handlers.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSpace.Handlers
{
    public class ComparisonCommandHandler : ICommandHandler<ComparisonCommand, SmartBillboardDTO>
    {
        private readonly ICommandHandler<TMDBMovieCommand, MovieDTO> _commandHandler;
        private readonly ICommandHandler<SmartBillboardQuery, SmartBillboardDTO> _queryHandler;

        public ComparisonCommandHandler(
            ICommandHandler<TMDBMovieCommand, MovieDTO> commandHandler, 
            ICommandHandler<SmartBillboardQuery, SmartBillboardDTO> queryHandler)
        { 
            _commandHandler = commandHandler ?? throw new ArgumentNullException( nameof(commandHandler));
            _queryHandler = queryHandler ?? throw new ArgumentNullException( nameof(queryHandler));
        }
        
        public async Task<SmartBillboardDTO> HandleAsync(ComparisonCommand command)
        {
            var query = new SmartBillboardQuery() 
            { 
                BigRoomsCount = command.BigRoomsCount,
                SmallRoomsCount = command.SmallRoomsCount,
                TimeInterval = command.TimeInterval
            };
            var topExitsFromDb = await _queryHandler.HandleAsync(query);

            var smallRoomMoviesFromTMDB = await GetMovies(topExitsFromDb.SmallRoomMovies);
            var bigRoomMoviesFromTMDB = await GetMovies(topExitsFromDb.BigRoomMovies);

            var smallRoomMovies = CompareMovies(topExitsFromDb.SmallRoomMovies, smallRoomMoviesFromTMDB);
            var bigRoomMovies = CompareMovies(topExitsFromDb.BigRoomMovies, bigRoomMoviesFromTMDB);

            return new SmartBillboardDTO
            {
                SmallRoomMovies = smallRoomMovies,
                BigRoomMovies = bigRoomMovies
            };
        }

        private async Task<IList<MovieDTO>> GetMovies(IEnumerable<Week<MovieDTO>> moviesToSearch)
        {
            var results = new List<MovieDTO>();
            foreach (var weeklyMovies in moviesToSearch)
            {
                foreach (var movie in weeklyMovies.Values)
                {
                    var movieCommand = new TMDBMovieCommand()
                    {
                        OriginalTitle = movie.OriginalTitle,
                        ReleaseYear = movie.ReleaseDate.Year
                    };

                    var movieDto = await _commandHandler.HandleAsync(movieCommand);
                    results.Add(movieDto);
                }
            }

            return results;
        }

        private IEnumerable<Week<MovieDTO>> CompareMovies(IEnumerable<Week<MovieDTO>> weeklyMoviesList, IEnumerable<MovieDTO> updatedMovies)
        {
            var updatedWeeklyMovies = new List<Week<MovieDTO>>();
            foreach (var weeklyMovies in weeklyMoviesList)
            {
                var moviesToAdd = new List<MovieDTO>();
                foreach(var weeklyMovie in weeklyMovies.Values)
                {
                    if(updatedMovies.Any(d => d.OriginalTitle.Equals(weeklyMovie.OriginalTitle)))
                    {
                        moviesToAdd.Add(updatedMovies.First(d => d.OriginalTitle.Equals(weeklyMovie.OriginalTitle)));
                    }
                }
                var weeklyDataToReturn = new Week<MovieDTO>(weeklyMovies.WeekNumber, moviesToAdd);
                updatedWeeklyMovies.Add(weeklyDataToReturn);
            }

            return updatedWeeklyMovies;
        }
    }
}
