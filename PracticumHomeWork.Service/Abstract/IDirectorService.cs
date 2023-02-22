using PracticumHomeWork.Data.Models;
using PracticumHomeWork.Dto.Dtos;
using PracticumHomeWork.ViewModel.ViewModels.Director;
using PracticumHomeWork.ViewModel.ViewModels.Genre;

namespace PracticumHomeWork.Service.Abstract
{
    public interface IDirectorService : IBaseService<DirectorDto, Director>
    {
        public Task<DirectorDetailViewModel> GetSingleDirectorByIdWithMoviesAsync(int id);
        public Task<List<DirectorsViewModel>> GetDirectorsWithMoviesAsync();
    }
}
