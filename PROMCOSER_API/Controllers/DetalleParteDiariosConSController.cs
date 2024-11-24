        using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROMCOSER_DOMAIN.CORE.Entities;
using PROMCOSER_DOMAIN.INFRASTRUCTURE.Data;

namespace PROMCOSER_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleParteDiariosConSController : ControllerBase
    {
        private readonly PromcoserContext _context;

        public DetalleParteDiariosConSController(PromcoserContext context)
        {
            _context = context;
        }

        // GET: api/DetalleParteDiarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleParteDiario>>> GetDetalleParteDiario()
        {
            return await _context.DetalleParteDiario.ToListAsync();
        }

        // GET: api/DetalleParteDiarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleParteDiario>> GetDetalleParteDiario(int id)
        {
            var detalleParteDiario = await _context.DetalleParteDiario.FindAsync(id);

            if (detalleParteDiario == null)
            {
                return NotFound();
            }

            return detalleParteDiario;
        }

        // PUT: api/DetalleParteDiarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleParteDiario(int id, DetalleParteDiario detalleParteDiario)
        {
            if (id != detalleParteDiario.IdDetalleParteDiario)
            {
                return BadRequest();
            }

            _context.Entry(detalleParteDiario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleParteDiarioExists(id))
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

        // POST: api/DetalleParteDiarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetalleParteDiario>> PostDetalleParteDiario(DetalleParteDiario detalleParteDiario)
        {
            _context.DetalleParteDiario.Add(detalleParteDiario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalleParteDiario", new { id = detalleParteDiario.IdDetalleParteDiario }, detalleParteDiario);
        }

        // DELETE: api/DetalleParteDiarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleParteDiario(int id)
        {
            var detalleParteDiario = await _context.DetalleParteDiario.FindAsync(id);
            if (detalleParteDiario == null)
            {
                return NotFound();
            }

            _context.DetalleParteDiario.Remove(detalleParteDiario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetalleParteDiarioExists(int id)
        {
            return _context.DetalleParteDiario.Any(e => e.IdDetalleParteDiario == id);
        }
    }
}
