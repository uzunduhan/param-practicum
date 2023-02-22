using PracticumHomeWork.Data.Models;
using PracticumHomeWork.Dto.Dtos;
using PracticumHomeWork.ViewModel.ViewModels.Genre;

namespace PracticumHomeWork.Service.Abstract
{
    public interface IGenreService : IBaseService<GenreDto, Genre>
    {
        public Task<GenreDetailViewModel> GetSingleGenreByIdWithMoviesAsync(int id);
        public Task<List<GenresViewModel>> GetGenresWithMoviesAsync();
    }
}
