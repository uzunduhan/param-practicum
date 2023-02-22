using PracticumHomeWork.Data.Models;

namespace PracticumHomeWork.Data.Repository.Abstract
{
    public interface IGenreRepository : IGenericRepository<Genre>
    {
        public Task<Genre> GetByIdAsync(int id);
        public Task<IEnumerable<Genre>> GetAllAsync();
    }
}
