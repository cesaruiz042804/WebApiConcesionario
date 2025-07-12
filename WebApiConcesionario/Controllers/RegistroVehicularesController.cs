using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiConcesionario.Models;

namespace WebApiConcesionario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroVehicularesController : ControllerBase
    {
        private readonly DbConcesionarioContext _context;

        public RegistroVehicularesController(DbConcesionarioContext context)
        {
            _context = context;
        }

        // GET: api/RegistroVehiculares
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegistroVehiculares>>> GetRegistroVehiculares()
        {
            return await _context.RegistroVehiculares.ToListAsync();
        }

        // GET: api/RegistroVehiculares/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegistroVehiculares>> GetRegistroVehiculares(int id)
        {
            var registroVehiculares = await _context.RegistroVehiculares.FindAsync(id);

            if (registroVehiculares == null)
            {
                return NotFound();
            }

            return registroVehiculares;
        }

        // PUT: api/RegistroVehiculares/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistroVehiculares(int id, RegistroVehiculares registroVehiculares)
        {
            if (id != registroVehiculares.Id)
            {
                return BadRequest();
            }

            _context.Entry(registroVehiculares).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistroVehicularesExists(id))
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

        // POST: api/RegistroVehiculares
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RegistroVehiculares>> PostRegistroVehiculares(RegistroVehiculares registroVehiculares)
        {
            _context.RegistroVehiculares.Add(registroVehiculares);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegistroVehiculares", new { id = registroVehiculares.Id }, registroVehiculares);
        }

        // DELETE: api/RegistroVehiculares/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistroVehiculares(int id)
        {
            var registroVehiculares = await _context.RegistroVehiculares.FindAsync(id);
            if (registroVehiculares == null)
            {
                return NotFound();
            }

            _context.RegistroVehiculares.Remove(registroVehiculares);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RegistroVehicularesExists(int id)
        {
            return _context.RegistroVehiculares.Any(e => e.Id == id);
        }
    }
}
