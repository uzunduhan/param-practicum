using AutoMapper;
using PracticumHomeWork.Data.Models;
using PracticumHomeWork.Data.Repository.Abstract;
using PracticumHomeWork.Data.Repository.Concrete;
using PracticumHomeWork.Data.UnitOfWork.Abstract;
using PracticumHomeWork.Dto.Dtos;
using PracticumHomeWork.Service.Abstract;
using PracticumHomeWork.ViewModel.ViewModels.Director;
using PracticumHomeWork.ViewModel.ViewModels.Genre;

namespace PracticumHomeWork.Service.Concrete
{
    public class DirectorService : BaseService<DirectorDto, Director>, IDirectorService
    {
        private readonly IMapper _mapper;
        private readonly IDirectorRepository _directorRepository;

        public DirectorService(IGenericRepository<Director> genericRepository, IMapper mapper, IUnitOfWork unitOfWork, IDirectorRepository directorRepository) : base(genericRepository, mapper, unitOfWork)
        {
            _mapper = mapper;
            _directorRepository = directorRepository;
        }

        public async Task<DirectorDetailViewModel> GetSingleDirectorByIdWithMoviesAsync(int id)
        {
            var director = await _directorRepository.GetByIdAsync(id);
            DirectorDetailViewModel vm = _mapper.Map<DirectorDetailViewModel>(director);
            return vm;
        }

        public async Task<List<DirectorsViewModel>> GetDirectorsWithMoviesAsync()
        {
            var directors = await _directorRepository.GetAllAsync();
            List<DirectorsViewModel> vm = _mapper.Map<List<DirectorsViewModel>>(directors);
            return vm;
        }
    }
}
