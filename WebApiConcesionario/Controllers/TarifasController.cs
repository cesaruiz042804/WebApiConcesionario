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
    public class TarifasController : ControllerBase
    {
        private readonly DbConcesionarioContext _context;

        public TarifasController(DbConcesionarioContext context)
        {
            _context = context;
        }

        // GET: api/Tarifas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarifas>>> GetTarifas()
        {
            return await _context.Tarifas.ToListAsync();
        }

        // GET: api/Tarifas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tarifas>> GetTarifas(int id)
        {
            var tarifas = await _context.Tarifas.FindAsync(id);

            if (tarifas == null)
            {
                return NotFound();
            }

            return tarifas;
        }

        // PUT: api/Tarifas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTarifas(int id, Tarifas tarifas)
        {
            if (id != tarifas.Id)
            {
                return BadRequest();
            }

            _context.Entry(tarifas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TarifasExists(id))
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

        // POST: api/Tarifas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tarifas>> PostTarifas(Tarifas tarifas)
        {
            _context.Tarifas.Add(tarifas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTarifas", new { id = tarifas.Id }, tarifas);
        }

        // DELETE: api/Tarifas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarifas(int id)
        {
            var tarifas = await _context.Tarifas.FindAsync(id);
            if (tarifas == null)
            {
                return NotFound();
            }

            _context.Tarifas.Remove(tarifas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TarifasExists(int id)
        {
            return _context.Tarifas.Any(e => e.Id == id);
        }
    }
}
