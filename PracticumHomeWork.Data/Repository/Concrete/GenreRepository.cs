using Microsoft.EntityFrameworkCore;
using PracticumHomeWork.Data.DBOperations;
using PracticumHomeWork.Data.Models;
using PracticumHomeWork.Data.Repository.Abstract;

namespace PracticumHomeWork.Data.Repository.Concrete
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(DatabaseContext context) : base(context)
        {
        }

        public override async Task<Genre> GetByIdAsync(int id)
        {
            return await _context.Genres.Include(x => x.Movies).Where(x => x.Id == id).SingleOrDefaultAsync();
        }

        public override async Task<IEnumerable<Genre>> GetAllAsync()
        {
            return await _context.Genres.Include(x => x.Movies).ToListAsync();
        }
    }
}
