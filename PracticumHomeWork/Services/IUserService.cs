using PracticumHomeWork.DTOs;
using PracticumHomeWork.Models;
using PracticumHomeWork.ViewModels.User;

namespace PracticumHomeWork.Services
{
    public interface IUserService
    {
        public Task<bool> isUserExistByEmail(string email);
        public Task<UserDetailViewModel> getUserByEmail(string email);
        public Task<List<UsersViewModel>> GetUsers();
        public Task UpdateUser(int id, UpdateUserModel updatedUser);
        public Task<User> getUserById(int id);
        public Task AddUser(CreateUserModel user);
        public Task DeleteUser(int id);

    }
}
