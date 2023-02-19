using Microsoft.EntityFrameworkCore;
using PracticumHomeWork.Data.Repository.Abstract;
using PracticumHomeWork.Data.DBOperations;

namespace PracticumHomeWork.Data.Repository.Concrete
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {

        protected readonly DatabaseContext _context;
        private DbSet<Entity> entities;


        public GenericRepository(DatabaseContext context)
        {
            _context = context;
            this.entities = _context.Set<Entity>();
        }


        public async Task<IEnumerable<Entity>> GetAllAsync()
        {
            return await entities.AsNoTracking().ToListAsync();
        }

        public async Task<Entity> GetByIdAsync(int entityId)
        {
            return await entities.FindAsync(entityId);
        }

        public async Task InsertAsync(Entity entity)
        {
            await entities.AddAsync(entity);
        }

        public void RemoveAsync(Entity entity)
        {

            var type = typeof(Entity).Name;


            entities.Remove(entity);

        }

        public void Update(Entity entity)
        {
            entities.Update(entity);
        }
    }
}
