using Microsoft.EntityFrameworkCore;
using PracticumHomeWork.Data.DBOperations;
using PracticumHomeWork.Data.Models;
using PracticumHomeWork.Data.Repository.Abstract;

namespace PracticumHomeWork.Data.Repository.Concrete
{
    public class DirectorRepository : GenericRepository<Director>, IDirectorRepository
    {
        public DirectorRepository(DatabaseContext context) : base(context)
        {
        }

        public override async Task<Director> GetByIdAsync(int id)
        {
            return await _context.Directors.Include(x => x.Movies).ThenInclude(x=>x.Genre).Where(x => x.Id == id).SingleOrDefaultAsync();
        }

        public override async Task<IEnumerable<Director>> GetAllAsync()
        {
            return await _context.Directors.Include(x => x.Movies).ThenInclude(x=>x.Genre).ToListAsync();
        }
    }
}
