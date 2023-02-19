using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using PracticumHomeWork.Data.DBOperations;
using PracticumHomeWork.Data.Models;
using PracticumHomeWork.Data.Repository.Abstract;
using PracticumHomeWork.Data.UnitOfWork.Abstract;
using PracticumHomeWork.Dto.Dtos;
using PracticumHomeWork.Service.Abstract;
using PracticumHomeWork.ViewModel.ViewModels.Movie;
using System.Text.RegularExpressions;

namespace PracticumHomeWork.Service.Concrete
{
    public class MovieService : BaseService<MovieDto, Movie>, IMovieService
    {
        private readonly DatabaseContext _context;
        private readonly IGenericRepository<Movie> genericRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICommonService _commonService;

        public MovieService(DatabaseContext context, IGenericRepository<Movie> genericRepository, IUnitOfWork unitOfWork, IMapper mapper, ICommonService commonService) : base(genericRepository, mapper, unitOfWork)
        {
            _context = context;
            this.genericRepository = genericRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _commonService = commonService;
        }


        public async Task<List<MoviesViewModel>> GetMoviesByColumnNameToAscending(string columnName)
        {
            //if the field to sort is not found, return empty list
            if (columnName != "ID" && columnName != "Title" && columnName != "GenreId"
                && columnName != "Duration" && columnName != "ReleaseDate" && columnName != "RatingScore")
            {
                throw new InvalidOperationException("column name not found");
            }



            var movieList = await _context.Movies.OrderBy(p => EF.Property<object>(p, columnName)).ToListAsync();

            List<MoviesViewModel> vm = _mapper.Map<List<MoviesViewModel>>(movieList);

            return vm;
        }

        public async Task<List<MoviesViewModel>> GetMoviesByFiltering(MovieParameters movieParameters)
        {
            if (!movieParameters.ValidYearRange)
            {
                throw new InvalidOperationException("Release date max cannot be less than release date min");
            }


            var movieList = await _context.Movies.Where(x => x.ReleaseDate.Value.Year >= movieParameters.ReleaseDateMin &&
                               x.ReleaseDate.Value.Year < movieParameters.ReleaseDateMax)
                           .OrderBy(x => x.Id).ToListAsync();

            List<MoviesViewModel> vm = _mapper.Map<List<MoviesViewModel>>(movieList);


            return vm;
        }

        public async Task<List<MoviesViewModel>> GetMoviesByTitleToDescending()
        {
            var movieList = await _context.Movies.OrderByDescending(x => x.Title).ToListAsync<Movie>();
            List<MoviesViewModel> vm = _mapper.Map<List<MoviesViewModel>>(movieList);
            return vm;
        }

        public async Task isMovieExistByTitle(string title)
        {
            var titleWithSpacesDeleted = _commonService.getDataWithSpacesDeleted(title);

            var movie = from movies in _context.Movies
                        where _commonService.getDataWithSpacesDeleted(movies.Title).ToLower() == titleWithSpacesDeleted.ToLower()
                        select movies;

            if (movie is not null)
            {
                throw new InvalidOperationException("the movie is already recorded");
            }

        }


        public async Task PatchMovie(int id, JsonPatchDocument updatedMovie)
        {
            var movie = await genericRepository.GetByIdAsync(id);

            updatedMovie.ApplyTo(movie);

            await _unitOfWork.CompleteAsync();
        }

    }
}
