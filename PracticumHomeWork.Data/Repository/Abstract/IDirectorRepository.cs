using PracticumHomeWork.Data.Models;

namespace PracticumHomeWork.Data.Repository.Abstract
{
    public interface IDirectorRepository : IGenericRepository<Director>
    {
        public Task<Director> GetByIdAsync(int id);
        public Task<IEnumerable<Director>> GetAllAsync();
    }
}
