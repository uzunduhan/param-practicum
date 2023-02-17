using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PracticumHomeWork.Models;
using PracticumHomeWork.DTOs;
using PracticumHomeWork.Services;

namespace PracticumHomeWork.Controllers
{

    [ApiController]
    [Route("[controller]s")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]

        //list all movies
        public async Task<IActionResult> GetMovies()
        {
            var movieList = await _movieService.GetMovies();

            return Ok(movieList);
        }


        //get movie by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var movie = await _movieService.GetMovieByID(id);

            return Ok(movie);
        }

        //add movie
        [HttpPost]
        public async Task<IActionResult> AddMovie([FromBody] CreateMovieModel newMovie)
        {
            await _movieService.AddMovie(newMovie);

            return Ok();
        }


        //update movie
        [HttpPut]
        public async Task<IActionResult> UpdateMovie([FromQuery] int id, [FromBody] UpdateMovieModel updatedMovie)
        {

            await _movieService.UpdateMovie(id, updatedMovie);

            return Ok();
        }

        //delete movie by id
        [HttpDelete]
        public async Task<IActionResult> DeleteMovie([FromQuery] int id)
        {
            await _movieService.DeleteMovie(id);

            return NoContent();
        }

        //update movie column by id
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchMovie([FromRoute] int id, [FromBody] JsonPatchDocument updatedMovie)
        {
            await _movieService.PatchMovie(id, updatedMovie);

            return Ok();
        }

        //descending movie list
        [HttpGet]
        [Route("DescendingByTitle")]
        public async Task<IActionResult> GetMoviesByTitleToDescending()
        {
            var movieList = await _movieService.GetMoviesByTitleToDescending();

            return Ok(movieList);
        }

        //ascending movie list by user input string
        [HttpGet]
        [Route("AscendingByColumnName")]
        public async Task<IActionResult> GetMoviesByColumnNameToAscending([FromQuery] string columnName)
        {
            var movieList = await _movieService.GetMoviesByColumnNameToAscending(columnName);

            return Ok(movieList);
        }

        //get movies by year range
        [HttpGet]
        [Route("FilterByYear")]
        public async Task<IActionResult> GetMoviesByFiltering([FromQuery] MovieParameters movieParameters)
        {
            var movieList = await _movieService.GetMoviesByFiltering(movieParameters);

            return Ok(movieList);
        }

    }
}