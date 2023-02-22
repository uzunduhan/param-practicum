using AutoMapper;
using PracticumHomeWork.Data.Models;
using PracticumHomeWork.Dto.Dtos;
using PracticumHomeWork.ViewModel.ViewModels.Director;
using PracticumHomeWork.ViewModel.ViewModels.Genre;
using PracticumHomeWork.ViewModel.ViewModels.Movie;
using PracticumHomeWork.ViewModel.ViewModels.User;

namespace PracticumHomeWork.Service.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, MovieDetailViewModel>().ForMember(destination=>destination.Genre, opt=>opt.MapFrom(src=>src.Genre.Name));
            CreateMap<Movie, MoviesViewModel>().ForMember(destination => destination.Genre, opt => opt.MapFrom(src => src.Genre.Name));

            CreateMap<Director, DirectorDetailViewModel>().ForMember(destination => destination.FullName, opt => opt.MapFrom(src => src.Name + " " + src.SurName)).
            ForMember(destination => destination.Movies, opt => opt.MapFrom(src => src.Movies));

            CreateMap<Director, DirectorsViewModel>().ForMember(destination => destination.FullName, opt => opt.MapFrom(src => src.Name + " " + src.SurName))
            .ForMember(destination => destination.Movies, opt => opt.MapFrom(src => src.Movies));

            CreateMap<User, UserDetailViewModel>();
            CreateMap<User, UsersViewModel>();

            CreateMap<Movie, MovieDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Genre, GenreDto>().ReverseMap();
            CreateMap<Director, DirectorDto>().ReverseMap();

            CreateMap<Genre, GenresViewModel>().ForMember(destination => destination.Movies, opt => opt.MapFrom(src => src.Movies));
            CreateMap<Genre, GenreDetailViewModel>().ForMember(destination => destination.Movies, opt => opt.MapFrom(src => src.Movies));


        }
    }
}
