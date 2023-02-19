using PracticumHomeWork.Data.DBOperations;
using PracticumHomeWork.Data.Models;
using PracticumHomeWork.Data.Repository.Abstract;

namespace PracticumHomeWork.Data.Repository.Concrete
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
