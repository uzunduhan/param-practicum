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
    }
}
