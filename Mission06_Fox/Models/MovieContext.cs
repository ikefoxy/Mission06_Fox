using Microsoft.EntityFrameworkCore;

namespace Mission06_Fox.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }

        // Movies table
        public DbSet<Movie> Movies { get; set; }

        // Categories table (needed for foreign key + dropdown)
        public DbSet<Category> Categories { get; set; }
    }
}