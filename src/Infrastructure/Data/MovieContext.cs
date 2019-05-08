using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MoviegramApi.Core.Entities;

namespace MoviegramApi.Infrastucture.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options)
            : base(options)
        {
        }
        
        public DbSet<Movie> Movies { get; set; }
    }
}


