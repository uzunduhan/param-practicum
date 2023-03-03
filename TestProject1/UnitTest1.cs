using AutoMapper;
using FluentAssertions;
using FluentValidation;
using Moq;
using PracticumHomeWork.Data.DBOperations;
using PracticumHomeWork.Data.Models;
using PracticumHomeWork.Data.Repository.Abstract;
using PracticumHomeWork.Data.UnitOfWork.Abstract;
using PracticumHomeWork.Dto.Dtos;
using PracticumHomeWork.Service.Concrete;
using PracticumHomeWork.Service.Validations;
using TestSetup;

namespace TestProject1
{
    public class UnitTest1 : IClassFixture<CommonTestFixture>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public UnitTest1(CommonTestFixture commonTestFixture)
        {
            _context = commonTestFixture.context;
            _mapper = commonTestFixture.Mapper;
        }


        [Fact]
        public void WhenAlreadyExistMovieTitleIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //arrange (hazýrlýk)
            var movieDto = new MovieDto() { Title = "WhenAlreadyExistMovieTitleIsGiven_InvalidOperationException_ShouldBeReturn", GenreId = 1, Duration = 200, ReleaseDate = new DateTime(1990, 01, 10) };
            Movie movie = _mapper.Map<Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();


            var _genericRepository = new Mock<IGenericRepository<Movie>>();
            var _movieRepository = new Mock<IMovieRepository>();
            var _unitOfWork = new Mock<IUnitOfWork>();


            var command = new MovieService(_context, _genericRepository.Object, _movieRepository.Object, _unitOfWork.Object, _mapper);
            //act & assert (çalýþtýrma, doðrulama)

            FluentActions
            .Invoking(() => command.InsertAsync(movieDto))
            .Should().ThrowAsync<InvalidOperationException>().WithMessage("yazar zaten mevcut");


        }

        [Fact]
        public void WhenValidInputsAreGiven_Movie_ShouldBeCreated()
        {
            var _genericRepository = new Mock<IGenericRepository<Movie>>();
            var _movieRepository = new Mock<IMovieRepository>();
            var _unitOfWork = new Mock<IUnitOfWork>();

            //arrange
            var command = new MovieService(_context, _genericRepository.Object, _movieRepository.Object, _unitOfWork.Object, _mapper);

            var movieDto = new MovieDto()
            {
                Title = "WhenAlreadyExistMovieTitleIsGiven_InvalidOperationException_ShouldBeReturn",
                GenreId = 1,
                Duration = 200,
                ReleaseDate = new DateTime(1990, 01, 10)
            };


            //act
            FluentActions.Invoking(() => command.InsertAsync(movieDto)).Invoke();

            //assert
            var movie = _context.Movies.SingleOrDefault(x => x.Title == movieDto.Title);
            movie.Should().NotBeNull();
            movie.Title.Should().Be(movieDto.Title);
            movie.GenreId.Should().Be(movieDto.GenreId);
            movie.Duration.Should().Be(movieDto.Duration);

        }


        public static readonly object[][] CorrectData =
        {
          new object[] { "title", 1, 200, 7,
                          new DateTime(2017,3,1)},
          new object[] { "test deneme", 3, 180, 4,
                          new DateTime(2020,3,1)},
          new object[] { "title deneme", 2, 300, 4,
                          new DateTime(2022,3,1)}


        };

        [Theory, MemberData(nameof(CorrectData))]
        public void WhenInvalidInputsAreGýven_Validator_ShoulBeReturnErrors(string title, int genreId, int duration, int ratingScore, DateTime releaseDate)
        {
            //arrange

            var movieDto = new MovieDto()
            {
                Title = title,
                GenreId = genreId,
                Duration = duration,
                ReleaseDate = releaseDate,
                RatingScore = ratingScore

            };

            //act
            MovieDtoValidator validator = new MovieDtoValidator();
            var result = validator.Validate(movieDto);

            //assert
            result.Errors.Count.Should().BeLessThanOrEqualTo(0);
        }
    }
}