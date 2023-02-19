using AutoMapper;
using PracticumHomeWork.Data.Repository.Abstract;
using PracticumHomeWork.Data.UnitOfWork.Abstract;
using PracticumHomeWork.Service.Abstract;

namespace PracticumHomeWork.Service.Concrete
{
    public abstract class BaseService<Dto, Entity> : IBaseService<Dto, Entity> where Entity : class
    {
        private readonly IGenericRepository<Entity> genericRepository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public BaseService(IGenericRepository<Entity> genericRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.genericRepository = genericRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public virtual async Task<List<Entity>> GetAllAsync()
        {
            var tempEntity = await genericRepository.GetAllAsync();

            return tempEntity.ToList();
        }

        public virtual async Task<Entity> GetByIdAsync(int id)
        {
            var tempEntity = await genericRepository.GetByIdAsync(id);
            var type = typeof(Entity).Name;

            if (tempEntity is null)
                throw new InvalidOperationException(type + " not found");

            return tempEntity;
        }

        public virtual async Task InsertAsync(Dto insertResource)
        {
            var tempEntity = mapper.Map<Dto, Entity>(insertResource);

            await genericRepository.InsertAsync(tempEntity);
            await unitOfWork.CompleteAsync();

        }

        public virtual async Task RemoveAsync(int id)
        {
            var tempEntity = await genericRepository.GetByIdAsync(id);
            var type = typeof(Entity).Name;

            if (tempEntity is null)
                throw new InvalidOperationException(type + " not found");

            genericRepository.RemoveAsync(tempEntity);
            await unitOfWork.CompleteAsync();

        }

        public virtual async Task UpdateAsync(int id, Dto updateResource)
        {

            var tempEntity = await genericRepository.GetByIdAsync(id);
            var type = typeof(Entity).Name;

            if (tempEntity is null)
                throw new InvalidOperationException(type + " not found");

            var mapped = mapper.Map(updateResource, tempEntity);

            genericRepository.Update(mapped);
            await unitOfWork.CompleteAsync();

        }

    }
}
