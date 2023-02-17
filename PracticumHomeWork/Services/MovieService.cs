using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using PracticumHomeWork.Models;
using PracticumHomeWork.UnitOfWork.Abstract;
using PracticumHomeWork.ViewModels.Movie;
using PracticumHomeWork.DTOs;
using PracticumHomeWork.Validations;
using PracticumHomeWork.DBOperations;

namespace PracticumHomeWork.Services
{
    public class MovieService : IMovieService
    {
        private readonly DatabaseContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MovieService(DatabaseContext context, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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
                           .OrderBy(x => x.ID).ToListAsync();

            List<MoviesViewModel> vm = _mapper.Map<List<MoviesViewModel>>(movieList);


            return vm;
        }

        public async Task<List<MoviesViewModel>> GetMoviesByTitleToDescending()
        {
            var movieList = await _context.Movies.OrderByDescending(x => x.Title).ToListAsync<Movie>();
            List<MoviesViewModel> vm = _mapper.Map<List<MoviesViewModel>>(movieList);
            return vm;
        }

        public async Task<bool> isMovieExistByTitle(string title)
        {
            var movie = await _context.Movies.Where(x => x.Title == title).FirstOrDefaultAsync();

            if (movie == null)
            {
                return false;
            }

            return true;
        }

        public async Task<List<MoviesViewModel>> GetMovies()
        {
            var movieList = await _unitOfWork.MovieRepository.GetAllAsync();
            List<MoviesViewModel> vm = _mapper.Map<List<MoviesViewModel>>(movieList);
            return vm;
        }

        public async Task<MovieDetailViewModel> GetMovieByID(int id)
        {
            var movie = await _context.Movies.Where(x => x.ID == id).FirstOrDefaultAsync();

            if (movie is null)
            {
                throw new InvalidOperationException("movie not found");
            }

            MovieDetailViewModel vm = _mapper.Map<MovieDetailViewModel>(movie);

            return vm;
        }

        public async Task AddMovie(CreateMovieModel newMovie)
        {
            CreateMovieValidations validator = new CreateMovieValidations();

            validator.ValidateAndThrow(newMovie);

            var movieTitle = await isMovieExistByTitle(newMovie.Title);


            if (movieTitle)
            {
                throw new InvalidOperationException("error " + newMovie.Title + "  has already been added");
            }

            var movie  = _mapper.Map<Movie>(newMovie);


            await _unitOfWork.MovieRepository.InsertAsync(movie);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateMovie(int id, UpdateMovieModel updatedMovie)
        {
            UpdateMovieValidations validator = new UpdateMovieValidations();

            validator.ValidateAndThrow(updatedMovie);

            if (id < 1)
            {
                throw new InvalidOperationException("id cannot less than 1");
            }

            var movie = await _context.Movies.Where(x => x.ID == id).FirstOrDefaultAsync();

            if(movie is null) 
            {
                throw new InvalidOperationException("movie not found");
            }

            if (movie.Title == updatedMovie.Title)
            {
                throw new InvalidOperationException("new title value as same as old title value");
            }

           

            movie.Title = updatedMovie.Title != default ? updatedMovie.Title: movie.Title;
            movie.GenreId = updatedMovie.GenreId != default  ? updatedMovie.GenreId : movie.GenreId;


            _unitOfWork.MovieRepository.Update(movie);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteMovie(int id)
        {
            var movie = await _context.Movies.Where(x => x.ID == id).FirstOrDefaultAsync();

            _unitOfWork.MovieRepository.RemoveAsync(movie);
            await _unitOfWork.CompleteAsync();
        }

        public async Task PatchMovie(int id, JsonPatchDocument updatedMovie)
        {
            var movie = await GetMovieByID(id);

            updatedMovie.ApplyTo(movie);

            await _unitOfWork.CompleteAsync();
        }

    }
}
