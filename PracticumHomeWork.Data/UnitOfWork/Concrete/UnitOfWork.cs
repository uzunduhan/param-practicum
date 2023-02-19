using PracticumHomeWork.Data.DBOperations;
using PracticumHomeWork.Data.Models;
using PracticumHomeWork.Data.Repository.Abstract;
using PracticumHomeWork.Data.Repository.Concrete;
using PracticumHomeWork.Data.UnitOfWork.Abstract;

namespace PracticumHomeWork.Data.UnitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        public bool disposed;



        public IGenericRepository<Movie> MovieRepository { get; private set; }

        public IGenericRepository<User> UserRepository { get; private set; }

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;

            MovieRepository = new GenericRepository<Movie>(_context);
            UserRepository = new GenericRepository<User>(_context);
        }



        public async Task CompleteAsync()
        {
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    // logging                    
                    dbContextTransaction.Rollback();
                }
            }
        }

        protected virtual void Clean(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Clean(true);
            GC.SuppressFinalize(this);
        }
    }
}

