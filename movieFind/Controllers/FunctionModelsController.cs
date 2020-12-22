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
    [Route("api/moviefind/functions")]
    [ApiController]
    public class FunctionModelsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FunctionModelsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/moviefind/functions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FunctionModel>>> Gettbl_function()
        {
            return await _context.tbl_function.ToListAsync();
        }

        // GET: api/moviefind/functions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FunctionModel>> GetFunctionModel(int id)
        {
            var functionModel = await _context.tbl_function.FindAsync(id);

            if (functionModel == null)
            {
                return NotFound();
            }

            return functionModel;
        }

        // PUT: api/moviefind/functions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFunctionModel(int id, FunctionModel functionModel)
        {
            if (id != functionModel.id_function)
            {
                return BadRequest();
            }

            _context.Entry(functionModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FunctionModelExists(id))
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

        // POST: api/moviefind/functions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FunctionModel>> PostFunctionModel(FunctionModel functionModel)
        {
            _context.tbl_function.Add(functionModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFunctionModel", new { id = functionModel.id_function }, functionModel);
        }

        // DELETE: api/moviefind/functions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FunctionModel>> DeleteFunctionModel(int id)
        {
            var functionModel = await _context.tbl_function.FindAsync(id);
            if (functionModel == null)
            {
                return NotFound();
            }

            _context.tbl_function.Remove(functionModel);
            await _context.SaveChangesAsync();

            return functionModel;
        }

        private bool FunctionModelExists(int id)
        {
            return _context.tbl_function.Any(e => e.id_function == id);
        }
    }
}
