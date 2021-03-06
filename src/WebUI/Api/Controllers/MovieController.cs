using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

using MoviegramApi.Core.Entities;
using MoviegramApi.Infrastucture.Data;
using MoviegramApi.WebUI.Api.ApiModels;
using MoviegramApi.WebUI.Interface;

namespace MoviegramApi.WebUI.Api.Controllers
{
    [Route("api/Movie")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MovieContext _context;
        private readonly ILogger _logger;
        private IImageWriter _imageWriter;

        public MovieController(MovieContext context, ILogger<MovieController> logger, IImageWriter imageWriter)
        {
            _context = context;
            _logger = logger;
           _imageWriter = imageWriter;

            if (_context.Movies.Count() == 0)
            {
                // Create a new Movie collection with a couple of movies intially
                _context.Movies.Add(new Movie { Name = "Shallow", ShowTime = new DateTime(2018,10,9, 18,0,0), Duration = 134, Image ="3eb5dd34-f749-4560-9be4-eb9f2490df88.png"});
                _context.Movies.Add(new Movie { Name = "Bohemian Rhapsody", ShowTime = new DateTime(2018,10,24,15,0,0), Duration = 133, Image = "92920a4d-a4a7-44bb-b6e2-66ce626d719a.jpg"});
                _context.SaveChanges();
            }
        }


        /// <summary>
        /// Adds a new movie.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Movie
        ///         Details and file in body
        ///
        /// </remarks>
        [HttpPost]
        public async Task<ActionResult<Movie>> AddMovie([FromForm] MovieDTO movieDTO, IFormFile file)
        {
             // Upload image to server
            var imageFileName = await _imageWriter.UploadImage(file);

            // Create the new movie details and add to the persistent store
           _context.Movies.Add(new Movie { Name = movieDTO.Name, ShowTime = movieDTO.ShowTime, Duration = movieDTO.Duration, Image = imageFileName});
            await _context.SaveChangesAsync();
            return Ok(imageFileName);
        }

        /// <summary>
        /// Gets all movies.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /Movie
        ///
        /// </remarks>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMoviesAsync()
        {
            return await _context.Movies.ToListAsync();
        }

        /// <summary>
        /// Gets a specific movie.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /Movie/
        ///         id in body
        ///
        /// </remarks>
        /// <param name="id"></param>  
        [HttpGet("{id:long}")]
        public async Task<ActionResult<Movie>> GetMovieAsync(long id)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        /// <summary>
        /// Deletes a specific movie.
        /// </summary>
         /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /Movie/1
        ///
        /// </remarks>
        /// <param name="id"></param>        
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var movie = _context.Movies.Find(id);

            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return NoContent();
        }

        /// <summary>
        /// Returms a list of movies containing certain letters in the name.
        /// </summary>
         /// <remarks>
        /// Sample request:
        ///
        ///     Get /Movie/
        ///         name in the body
        /// </remarks>

        [HttpGet("{name}")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMoviesAsync(string name)
        {
            _logger.LogInformation("GetMoviesAsync Called with: {name}", name);
            return await _context.Movies.Where(m => m.Name.Contains(name)).ToListAsync();
        }
    }
}