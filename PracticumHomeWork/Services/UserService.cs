using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticumHomeWork.DBOperations;
using PracticumHomeWork.DTOs;
using PracticumHomeWork.Models;
using PracticumHomeWork.UnitOfWork.Abstract;
using PracticumHomeWork.Validations;
using PracticumHomeWork.ViewModels.User;

namespace PracticumHomeWork.Services
{
    public class UserService : IUserService
    {
        private readonly DatabaseContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(DatabaseContext context, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<bool> isUserExistByEmail(string mail)
        {
            var user = await _context.Users.Where(x => x.Email == mail).FirstOrDefaultAsync();

            if (user == null)
            {
                return false;
            }

            return true;
        }

        public async Task<UserDetailViewModel> getUserByEmail(string email)
        {
            var user = await _context.Users.Where(x => x.Email == email).FirstOrDefaultAsync();

            if (user is null)
            {
                throw new InvalidOperationException("user not found");
            }

            UserDetailViewModel vm = _mapper.Map<UserDetailViewModel>(user);

            return vm;

        }

        public async Task<List<UsersViewModel>> GetUsers()
        {
            var users = await _unitOfWork.UserRepository.GetAllAsync();
            List<UsersViewModel> vm = _mapper.Map<List<UsersViewModel>>(users);
            return vm.ToList();
        }

        public async Task<User> getUserById(int id)
        {
            var user = await _context.Users.Where(x => x.ID == id).FirstOrDefaultAsync();

            if (user == null)
            {
                throw new InvalidOperationException("user not found");
            }

            return user;
        }

        public async Task UpdateUser(int id, [FromBody] UpdateUserModel updatedUser)
        {
            UpdateUserValidations validator = new UpdateUserValidations();
            validator.ValidateAndThrow(updatedUser);

            if (id < 1)
            {
                throw new InvalidOperationException("id cannot less than 1");
            }

            var user = await getUserById(id);

            if (user is null)
            {
                throw new InvalidOperationException("user not found");
            }

            user.Email = updatedUser.Email != default ? updatedUser.Email : user.Email;


            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.CompleteAsync();
        }

        public async Task AddUser(CreateUserModel user)
        {
            CreateUserValidations validator = new CreateUserValidations();
            validator.ValidateAndThrow(user);

            var mapUser = _mapper.Map<User>(user);

            if (await isUserExistByEmail(mapUser.Email))
            {
                throw new InvalidOperationException("error " + user.Email + "  has already been added");
            }



            await _unitOfWork.UserRepository.InsertAsync(mapUser);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteUser(int id)
        {
            var user = await getUserById(id);

            _unitOfWork.UserRepository.RemoveAsync(user);

            await _unitOfWork.CompleteAsync();
        }


    }
}
