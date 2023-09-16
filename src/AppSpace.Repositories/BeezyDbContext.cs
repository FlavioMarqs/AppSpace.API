using AppSpace.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSpace.Repositories
{
    public class BeezyDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public BeezyDbContext(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
           => options.UseSqlServer(_configuration["Databases:BeezyDBConnectionString"]);

        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Session> Sessions { get; set; }
    }
}
