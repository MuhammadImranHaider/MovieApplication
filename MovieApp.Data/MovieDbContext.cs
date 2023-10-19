using Microsoft.EntityFrameworkCore;
using MovieApp.Core.Data;

namespace MovieApp.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {
        }

        public MovieDbContext()
        {
        }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, ReleaseYear = new DateTime(2006, 1, 1), Title = "Very Real Movie", Genre = Genre.Comedy },
                new Movie { Id = 2, ReleaseYear = new DateTime(2020,1,1), Title = "Very Real Movie 2", Genre = Genre.Tragedy },
                new Movie { Id = 3, ShortDescription = "Just your typical romance.", Title = "Something, something Love", Genre = Genre.Romance },
                new Movie { Id = 4, Title = ".gitignore: The Movie", Genre = Genre.Horror }
        );
        }

    }
}
