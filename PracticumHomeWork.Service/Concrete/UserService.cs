using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PracticumHomeWork.Data.DBOperations;
using PracticumHomeWork.Data.Models;
using PracticumHomeWork.Data.Repository.Abstract;
using PracticumHomeWork.Data.UnitOfWork.Abstract;
using PracticumHomeWork.Dto.Dtos;
using PracticumHomeWork.Service.Abstract;
using PracticumHomeWork.ViewModel.ViewModels.User;

namespace PracticumHomeWork.Service.Concrete
{
    public class UserService : BaseService<UserDto, User>, IUserService
    {
        private readonly DatabaseContext _context;
        private readonly IGenericRepository<User> genericRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(DatabaseContext context, IGenericRepository<User> genericRepository, IUnitOfWork unitOfWork, IMapper mapper) : base(genericRepository, mapper, unitOfWork)
        {
            _context = context;
            this.genericRepository = genericRepository;
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




    }
}
