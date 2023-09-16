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

        public DbSet<Cinema> Cinema { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<MovieGenre> MovieGenre { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Session> Session { get; set; }
    }
}
