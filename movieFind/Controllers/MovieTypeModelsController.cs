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
    [Route("api/moviefind/movietypes")]
    [ApiController]
    public class MovieTypeModelsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MovieTypeModelsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/moviefind/movietypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieTypeModel>>> Gettbl_movie_type()
        {
            return await _context.tbl_movie_type.ToListAsync();
        }

        // GET: api/moviefind/movietypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieTypeModel>> GetMovieTypeModel(int id)
        {
            var movieTypeModel = await _context.tbl_movie_type.FindAsync(id);

            if (movieTypeModel == null)
            {
                return NotFound();
            }

            return movieTypeModel;
        }

        // PUT: api/moviefind/movietypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovieTypeModel(int id, MovieTypeModel movieTypeModel)
        {
            if (id != movieTypeModel.id_type)
            {
                return BadRequest();
            }

            _context.Entry(movieTypeModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieTypeModelExists(id))
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

        // POST: api/moviefind/movietypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MovieTypeModel>> PostMovieTypeModel(MovieTypeModel movieTypeModel)
        {
            _context.tbl_movie_type.Add(movieTypeModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovieTypeModel", new { id = movieTypeModel.id_type }, movieTypeModel);
        }

        // DELETE: api/moviefind/movietypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MovieTypeModel>> DeleteMovieTypeModel(int id)
        {
            var movieTypeModel = await _context.tbl_movie_type.FindAsync(id);
            if (movieTypeModel == null)
            {
                return NotFound();
            }

            _context.tbl_movie_type.Remove(movieTypeModel);
            await _context.SaveChangesAsync();

            return movieTypeModel;
        }

        private bool MovieTypeModelExists(int id)
        {
            return _context.tbl_movie_type.Any(e => e.id_type == id);
        }
    }
}
