using Microsoft.AspNetCore.JsonPatch;
using PracticumHomeWork.Data.Models;
using PracticumHomeWork.Dto.Dtos;
using PracticumHomeWork.ViewModel.ViewModels.Movie;

namespace PracticumHomeWork.Service.Abstract
{
    public interface IMovieService : IBaseService <MovieDto, Movie>
    {
        public Task<List<MoviesViewModel>> GetMoviesByTitleToDescending();
        public Task<List<MoviesViewModel>> GetMoviesByColumnNameToAscending(string columnName);
        public Task<List<MoviesViewModel>> GetMoviesByFiltering(MovieParameters movieParameters);
        public Task isMovieExistByTitle(string title);
        public Task PatchMovie(int id, JsonPatchDocument updatedMovie);
        public Task<MoviesViewModel> GetSingleMovieByIdWithGenreAsync(int id);
        public Task<List<MoviesViewModel>> GetMoviesWithGenreAsync();
    }
}
