using Microsoft.AspNetCore.JsonPatch;
using PracticumHomeWork.Models;
using PracticumHomeWork.ViewModels.Movie;
using PracticumHomeWork.DTOs;

namespace PracticumHomeWork.Services
{
    public interface IMovieService
    {
        public Task<List<MoviesViewModel>> GetMoviesByTitleToDescending();
        public Task<List<MoviesViewModel>> GetMoviesByColumnNameToAscending(string columnName);
        public Task<List<MoviesViewModel>> GetMoviesByFiltering(MovieParameters movieParameters);
        public Task<bool> isMovieExistByTitle(string title);
        public Task<List<MoviesViewModel>> GetMovies();
        public Task<MovieDetailViewModel> GetMovieByID(int id);
        public Task AddMovie(CreateMovieModel newMovie);
        public Task UpdateMovie(int id, UpdateMovieModel updatedMovie);
        public Task DeleteMovie(int id);
        public Task PatchMovie(int id, JsonPatchDocument updatedMovie);
    }
}
