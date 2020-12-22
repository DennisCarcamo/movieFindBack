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
    [Route("api/moviefind/departments")]
    [ApiController]
    public class DepartmentModelsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DepartmentModelsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/moviefind/departments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentModel>>> GetDepartmentModel()
        {
            return await _context.tbl_department.ToListAsync();
        }

        // GET: api/moviefind/departments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentModel>> GetDepartmentModel(int id)
        {
            var departmentModel = await _context.tbl_department.FindAsync(id);

            if (departmentModel == null)
            {
                return NotFound();
            }

            return departmentModel;
        }

        // PUT: api/moviefind/departments/5
        // Updates a department
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartmentModel(int id, DepartmentModel departmentModel)
        {
            if (id != departmentModel.id_department)
            {
                return BadRequest();
            }

            _context.Entry(departmentModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentModelExists(id))
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

        // POST: api/moviefind/departments
        // Adds a department
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DepartmentModel>> PostDepartmentModel(DepartmentModel departmentModel)
        {
            _context.tbl_department.Add(departmentModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDepartmentModel", new { id = departmentModel.id_department }, departmentModel);
        }

        // DELETE: api/moviefind/departments/5
        // deletes a department
        [HttpDelete("{id}")]
        public async Task<ActionResult<DepartmentModel>> DeleteDepartmentModel(int id)
        {
            var departmentModel = await _context.tbl_department.FindAsync(id);
            if (departmentModel == null)
            {
                return NotFound();
            }

            _context.tbl_department.Remove(departmentModel);
            await _context.SaveChangesAsync();

            return departmentModel;
        }

        private bool DepartmentModelExists(int id)
        {
            return _context.tbl_department.Any(e => e.id_department == id);
        }
    }
}
