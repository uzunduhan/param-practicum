using AutoMapper;
using PracticumHomeWork.Data.Models;
using PracticumHomeWork.Data.Repository.Abstract;
using PracticumHomeWork.Data.UnitOfWork.Abstract;
using PracticumHomeWork.Dto.Dtos;
using PracticumHomeWork.Service.Abstract;

namespace PracticumHomeWork.Service.Concrete
{
    public class GenreService : BaseService<GenreDto, Genre>, IGenreService
    {
        public GenreService(IGenericRepository<Genre> genericRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(genericRepository, mapper, unitOfWork)
        {
        }
    }
}
