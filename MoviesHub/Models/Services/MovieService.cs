using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using MoviesHub.Models.Interfaces;

namespace MoviesHub.Models
{
    public class MovieService : IMovieService
    {
        private readonly MoviesMvcContext context_;

        public MovieService(MoviesMvcContext context)
        {
            context_ = context;
        }
        public async Task<IList<Movie>> GetAllAsync()
        {
            var movies = await context_.Movie.ToListAsync();

            return movies;
        }


        public async Task<Movie> GetAsync(int id)
        {
            var movie = await context_.Movie
                .Include(m => m.ContentRating)
                .SingleOrDefaultAsync(m => m.MovieId == id);

            return movie;
        }
    }
}
