using PracticumHomeWork.Models;
using PracticumHomeWork.Repository.Abstract;

namespace PracticumHomeWork.UnitOfWork.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Movie> MovieRepository { get; }
        IGenericRepository<User> UserRepository { get; }


        Task CompleteAsync();
    }
}
