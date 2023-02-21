using PracticumHomeWork.Data.Models;

namespace PracticumHomeWork.Data.Repository.Abstract
{
    public interface IMovieRepository: IGenericRepository<Movie>
    {
        public Task<Movie> getSingleMovieByIdWithGenreAsync(int id);
        public Task<List<Movie>> getMoviesWithGenreAsync();

    }
}
