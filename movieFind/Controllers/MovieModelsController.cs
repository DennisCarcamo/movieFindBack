using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movieFind.Contexts;
using movieFind.Models;

namespace movieFind.Controllers
{
    [Route("api/moviefind/movie")]
    [ApiController]
    public class MovieModelsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MovieModelsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/moviefind/movie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieModel>>> Gettbl_movie()
        {
            return await _context.tbl_movie.ToListAsync();
        }

        // GET: api/moviefind/movie/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieModel>> GetMovieModel(int id)
        {
            var movieModel = await _context.tbl_movie.FindAsync(id);

            if (movieModel == null)
            {
                return NotFound();
            }

            return movieModel;
        }

        // PUT: api/moviefind/movie/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovieModel(int id, MovieModel movieModel)
        {
            if (id != movieModel.id_movie)
            {
                return BadRequest();
            }

            _context.Entry(movieModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/moviefind/movie
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MovieModel>> PostMovieModel(MovieModel movieModel)
        {
            _context.tbl_movie.Add(movieModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovieModel", new { id = movieModel.id_movie }, movieModel);
        }

        // DELETE: api/moviefind/movie/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MovieModel>> DeleteMovieModel(int id)
        {
            var movieModel = await _context.tbl_movie.FindAsync(id);
            if (movieModel == null)
            {
                return NotFound();
            }

            _context.tbl_movie.Remove(movieModel);
            await _context.SaveChangesAsync();

            return movieModel;
        }

        private bool MovieModelExists(int id)
        {
            return _context.tbl_movie.Any(e => e.id_movie == id);
        }
    }
}
