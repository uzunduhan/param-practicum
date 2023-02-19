using PracticumHomeWork.Data.Models;
using PracticumHomeWork.Data.Repository.Abstract;

namespace PracticumHomeWork.Data.UnitOfWork.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Movie> MovieRepository { get; }
        IGenericRepository<User> UserRepository { get; }


        Task CompleteAsync();
    }
}
