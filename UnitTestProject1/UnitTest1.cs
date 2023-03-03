using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Xunit;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
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
    
    }
}
