using AutoMapper;
using PracticumHomeWork.Models;
using PracticumHomeWork.ViewModels.Movie;
using PracticumHomeWork.DTOs;
using PracticumHomeWork.ViewModels.User;

namespace PracticumHomeWork.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, MovieDetailViewModel>();
            CreateMap<Movie, MoviesViewModel>();
            CreateMap<CreateMovieModel, Movie>();

            CreateMap<User, UserDetailViewModel>();
            CreateMap<User, UsersViewModel>();
            CreateMap<CreateUserModel, User>();

        }
    }
}
