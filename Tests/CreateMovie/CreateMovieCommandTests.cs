using AutoMapper;
using FluentAssertions;
using PracticumHomeWork.Data.DBOperations;
using PracticumHomeWork.Data.Models;
using PracticumHomeWork.Data.Repository.Abstract;
using PracticumHomeWork.Data.UnitOfWork.Abstract;
using PracticumHomeWork.Dto.Dtos;
using PracticumHomeWork.Service.Concrete;

namespace Tests.CreateMovie
{
    public class CreateMovieCommandTests
    {
        private readonly DatabaseContext _context;
        private readonly IGenericRepository<Movie> _genericRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateMovieCommandTests(DatabaseContext context, IGenericRepository<Movie> genericRepository, IMovieRepository movieRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _context = context;
            _genericRepository = genericRepository;
            _movieRepository = movieRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [Fact]
        public void WhenAlreadyExistMovieTitleIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //arrange (hazırlık)
            var movieDto = new MovieDto() { Title = "WhenAlreadyExistMovieTitleIsGiven_InvalidOperationException_ShouldBeReturn", Duration = 200, ReleaseDate = new DateTime(1990, 01, 10) };
            Movie movie = _mapper.Map<Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            MovieService command = new MovieService(_context, _genericRepository, _movieRepository, _unitOfWork, _mapper);
            //act & assert (çalıştırma, doğrulama)

            FluentActions
            .Invoking(() => command.InsertAsync(movieDto))
            .Should().ThrowAsync<InvalidOperationException>().WithMessage("yazar zaten mevcut");


        }

        //[Fact]

        //public void WhenValidInputsAreGiven_Author_ShouldBeCreated()
        //{
        //    //arrange
        //    CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);
        //    CreateAuthorModel model = new CreateAuthorModel()
        //    {
        //        Name = "belgesel",
        //        SurName = "aksiyon",
        //        Birthday = new DateTime(1960, 05, 05)
        //    };

        //    command.Model = model;

        //    //act
        //    FluentActions.Invoking(() => command.Handle()).Invoke();

        //    //assert
        //    var author = _context.Authors.SingleOrDefault(x => x.Name == model.Name);
        //    author.Should().NotBeNull();
        //    author.Name.Should().Be(model.Name);
        //    author.SurName.Should().Be(model.SurName);
        //    author.Birthday.Should().Be(model.Birthday);

        //}
    }
}