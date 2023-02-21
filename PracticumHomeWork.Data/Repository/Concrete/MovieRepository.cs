using Microsoft.EntityFrameworkCore;
using PracticumHomeWork.Data.DBOperations;
using PracticumHomeWork.Data.Models;
using PracticumHomeWork.Data.Repository.Abstract;

namespace PracticumHomeWork.Data.Repository.Concrete
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<Movie> getSingleMovieByIdWithGenreAsync(int id)
        {
            return await _context.Movies.Include(x => x.Genre).Where(x => x.Id == id).SingleOrDefaultAsync();
        }

        public async Task<List<Movie>> getMoviesWithGenreAsync()
        {
            return await _context.Movies.Include(x => x.Genre).ToListAsync();
        }
    }
}
