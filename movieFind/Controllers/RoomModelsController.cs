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
    [Route("api/moviefind/room")]
    [ApiController]
    public class RoomModelsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RoomModelsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/moviefind/room
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomModel>>> Gettbl_room()
        {
            return await _context.tbl_room.ToListAsync();
        }

        // GET: api/moviefind/room/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomModel>> GetRoomModel(int id)
        {
            var roomModel = await _context.tbl_room.FindAsync(id);

            if (roomModel == null)
            {
                return NotFound();
            }

            return roomModel;
        }

        // PUT: api/moviefind/room/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomModel(int id, RoomModel roomModel)
        {
            if (id != roomModel.id_room)
            {
                return BadRequest();
            }

            _context.Entry(roomModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomModelExists(id))
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

        // POST: api/moviefind/room
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RoomModel>> PostRoomModel(RoomModel roomModel)
        {
            _context.tbl_room.Add(roomModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoomModel", new { id = roomModel.id_room }, roomModel);
        }

        // DELETE: api/moviefind/room/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RoomModel>> DeleteRoomModel(int id)
        {
            var roomModel = await _context.tbl_room.FindAsync(id);
            if (roomModel == null)
            {
                return NotFound();
            }

            _context.tbl_room.Remove(roomModel);
            await _context.SaveChangesAsync();

            return roomModel;
        }

        private bool RoomModelExists(int id)
        {
            return _context.tbl_room.Any(e => e.id_room == id);
        }
    }
}
