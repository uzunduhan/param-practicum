using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PracticumHomeWork.Data.Repository.Abstract;
using PracticumHomeWork.Dto.Dtos;
using PracticumHomeWork.Service.Abstract;
using PracticumHomeWork.Service.Validations;

namespace PracticumHomeWork.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]

        public async Task<IActionResult> GetGenres()
        {
            var genreList = await _genreService.GetGenresWithMoviesAsync();

            return Ok(genreList);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var genre = await _genreService.GetSingleGenreByIdWithMoviesAsync(id);

            return Ok(genre);
        }

        [HttpPost]
        public async Task<IActionResult> AddGenre([FromBody] GenreDto newGenre)
        {
            GenreDtoValidator validator = new GenreDtoValidator();

            validator.ValidateAndThrow(newGenre);


            //await _genreService.isMovieExistByTitle(newMovie.Title);

            await _genreService.InsertAsync(newGenre);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGenre([FromQuery] int id, [FromBody] GenreDto updatedGenre)
        {
            GenreDtoValidator validator = new GenreDtoValidator();
            validator.ValidateAndThrow(updatedGenre);

            await _genreService.UpdateAsync(id, updatedGenre);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteGenre([FromQuery] int id)
        {
            await _genreService.RemoveAsync(id);

            return NoContent();
        }
    }
}
