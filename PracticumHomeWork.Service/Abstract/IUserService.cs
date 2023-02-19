using PracticumHomeWork.Data.Models;
using PracticumHomeWork.Dto.Dtos;
using PracticumHomeWork.ViewModel.ViewModels.User;

namespace PracticumHomeWork.Service.Abstract
{
    public interface IUserService : IBaseService<UserDto, User>
    {
        public Task isUserExistByEmail(string email);
        public Task<UserDetailViewModel> getUserByEmail(string email);

    }
}
