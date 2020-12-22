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
    [Route("api/moviefind/usertypes")]
    [ApiController]
    public class UserTypeModelsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserTypeModelsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/moviefind/usertypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserTypeModel>>> Gettbl_user_type()
        {
            return await _context.tbl_user_type.ToListAsync();
        }

        // GET: api/moviefind/usertypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserTypeModel>> GetUserTypeModel(int id)
        {
            var userTypeModel = await _context.tbl_user_type.FindAsync(id);

            if (userTypeModel == null)
            {
                return NotFound();
            }

            return userTypeModel;
        }

        // PUT: api/moviefind/usertypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserTypeModel(int id, UserTypeModel userTypeModel)
        {
            if (id != userTypeModel.id_type)
            {
                return BadRequest();
            }

            _context.Entry(userTypeModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserTypeModelExists(id))
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

        // POST: api/moviefind/usertypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserTypeModel>> PostUserTypeModel(UserTypeModel userTypeModel)
        {
            _context.tbl_user_type.Add(userTypeModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserTypeModel", new { id = userTypeModel.id_type }, userTypeModel);
        }

        // DELETE: api/moviefind/usertypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserTypeModel>> DeleteUserTypeModel(int id)
        {
            var userTypeModel = await _context.tbl_user_type.FindAsync(id);
            if (userTypeModel == null)
            {
                return NotFound();
            }

            _context.tbl_user_type.Remove(userTypeModel);
            await _context.SaveChangesAsync();

            return userTypeModel;
        }

        private bool UserTypeModelExists(int id)
        {
            return _context.tbl_user_type.Any(e => e.id_type == id);
        }
    }
}
