using AutoMapper;
using PracticumHomeWork.Data.Models;
using PracticumHomeWork.Data.Repository.Abstract;
using PracticumHomeWork.Data.UnitOfWork.Abstract;
using PracticumHomeWork.Dto.Dtos;
using PracticumHomeWork.Service.Abstract;
using PracticumHomeWork.ViewModel.ViewModels.Genre;

namespace PracticumHomeWork.Service.Concrete
{
    public class GenreService : BaseService<GenreDto, Genre>, IGenreService
    {
        private readonly IMapper _mapper;
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenericRepository<Genre> genericRepository, IMapper mapper, IUnitOfWork unitOfWork, IGenreRepository genreRepository) : base(genericRepository, mapper, unitOfWork)
        {
            _mapper = mapper;
            _genreRepository = genreRepository;
        }

        public async Task<GenreDetailViewModel> GetSingleGenreByIdWithMoviesAsync(int id)
        {
            var genre = await _genreRepository.GetByIdAsync(id);
            GenreDetailViewModel vm = _mapper.Map<GenreDetailViewModel>(genre);
            return vm;
        }

        public async Task<List<GenresViewModel>> GetGenresWithMoviesAsync()
        {
            var genres = await _genreRepository.GetAllAsync();
            List<GenresViewModel> vm = _mapper.Map<List<GenresViewModel>>(genres);
            return vm;
        }
    }
}
