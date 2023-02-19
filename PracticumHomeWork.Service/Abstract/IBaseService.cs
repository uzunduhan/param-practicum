namespace PracticumHomeWork.Service.Abstract
{
    public interface IBaseService<Dto, Entity>
    {
        Task<Entity> GetByIdAsync(int id);
        Task<List<Entity>> GetAllAsync();
        Task InsertAsync(Dto insertResource);
        Task UpdateAsync(int id, Dto updateResource);
        Task RemoveAsync(int id);
    }
}
