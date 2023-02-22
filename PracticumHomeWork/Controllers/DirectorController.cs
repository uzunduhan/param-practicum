using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PracticumHomeWork.Dto.Dtos;
using PracticumHomeWork.Service.Abstract;
using PracticumHomeWork.Service.Concrete;
using PracticumHomeWork.Service.Validations;

namespace PracticumHomeWork.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly IDirectorService _directorService;

        public DirectorController(IDirectorService directorService)
        {
            _directorService = directorService;
        }
        [HttpGet]

        public async Task<IActionResult> GetDirectors()
        {
            var directorList = await _directorService.GetDirectorsWithMoviesAsync();

            return Ok(directorList);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var director = await _directorService.GetSingleDirectorByIdWithMoviesAsync(id);

            return Ok(director);
        }

        [HttpPost]
        public async Task<IActionResult> AddDirector([FromBody] DirectorDto newDirector)
        {
            DirectorDtoValidator validator = new DirectorDtoValidator();

            validator.ValidateAndThrow(newDirector);


            //await _genreService.isMovieExistByTitle(newMovie.Title);

            await _directorService.InsertAsync(newDirector);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDirector([FromQuery] int id, [FromBody] DirectorDto updatedDirector)
        {
            DirectorDtoValidator validator = new DirectorDtoValidator();
            validator.ValidateAndThrow(updatedDirector);

            await _directorService.UpdateAsync(id, updatedDirector);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDirector([FromQuery] int id)
        {
            await _directorService.RemoveAsync(id);

            return NoContent();
        }
    }
}
