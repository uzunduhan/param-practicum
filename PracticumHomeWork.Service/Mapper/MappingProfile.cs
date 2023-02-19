using AutoMapper;
using PracticumHomeWork.Data.Models;
using PracticumHomeWork.Dto.Dtos;
using PracticumHomeWork.ViewModel.ViewModels.Movie;
using PracticumHomeWork.ViewModel.ViewModels.User;

namespace PracticumHomeWork.Service.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, MovieDetailViewModel>();
            CreateMap<Movie, MoviesViewModel>();

            CreateMap<User, UserDetailViewModel>();
            CreateMap<User, UsersViewModel>();

            CreateMap<Movie, MovieDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();


        }
    }
}
