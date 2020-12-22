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
    [Route("api/moviefind/subsidiary")]
    [ApiController]
    public class SubsidiaryModelsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SubsidiaryModelsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/moviefind/subsidiary
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubsidiaryModel>>> Gettbl_subsidiary()
        {
            return await _context.tbl_subsidiary.ToListAsync();
        }

        // GET: api/moviefind/subsidiary/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubsidiaryModel>> GetSubsidiaryModel(int id)
        {
            var subsidiaryModel = await _context.tbl_subsidiary.FindAsync(id);

            if (subsidiaryModel == null)
            {
                return NotFound();
            }

            return subsidiaryModel;
        }

        // PUT: api/moviefind/subsidiary/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubsidiaryModel(int id, SubsidiaryModel subsidiaryModel)
        {
            if (id != subsidiaryModel.id_subsidiary)
            {
                return BadRequest();
            }

            _context.Entry(subsidiaryModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubsidiaryModelExists(id))
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

        // POST: api/moviefind/subsidiary
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SubsidiaryModel>> PostSubsidiaryModel(SubsidiaryModel subsidiaryModel)
        {
            _context.tbl_subsidiary.Add(subsidiaryModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubsidiaryModel", new { id = subsidiaryModel.id_subsidiary }, subsidiaryModel);
        }

        // DELETE: api/moviefind/subsidiary/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SubsidiaryModel>> DeleteSubsidiaryModel(int id)
        {
            var subsidiaryModel = await _context.tbl_subsidiary.FindAsync(id);
            if (subsidiaryModel == null)
            {
                return NotFound();
            }

            _context.tbl_subsidiary.Remove(subsidiaryModel);
            await _context.SaveChangesAsync();

            return subsidiaryModel;
        }

        private bool SubsidiaryModelExists(int id)
        {
            return _context.tbl_subsidiary.Any(e => e.id_subsidiary == id);
        }
    }
}
