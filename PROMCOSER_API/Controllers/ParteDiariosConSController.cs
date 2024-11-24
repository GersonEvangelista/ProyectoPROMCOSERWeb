using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROMCOSER_DOMAIN.CORE.Entities;
using PROMCOSER_DOMAIN.INFRASTRUCTURE.Data;

namespace PROMCOSER_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ParteDiariosController : ControllerBase
    {
        private readonly PromcoserContext _context;

        public ParteDiariosController(PromcoserContext context)
        {
            _context = context;
        }

        // GET: api/ParteDiarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParteDiario>>> GetParteDiario()
        {
            return await _context.ParteDiario.ToListAsync();
        }

        // GET: api/ParteDiarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ParteDiario>> GetParteDiario(int id)
        {
            var parteDiario = await _context.ParteDiario.FindAsync(id);

            if (parteDiario == null)
            {
                return NotFound();
            }

            return parteDiario;
        }

        // PUT: api/ParteDiarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParteDiario(int id, ParteDiario parteDiario)
        {
            if (id != parteDiario.IdParteDiario)
            {
                return BadRequest();
            }

            _context.Entry(parteDiario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParteDiarioExists(id))
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

        // POST: api/ParteDiarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ParteDiario>> PostParteDiario(ParteDiario parteDiario)
        {
            _context.ParteDiario.Add(parteDiario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParteDiario", new { id = parteDiario.IdParteDiario }, parteDiario);
        }

        // DELETE: api/ParteDiarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParteDiario(int id)
        {
            var parteDiario = await _context.ParteDiario.FindAsync(id);
            if (parteDiario == null)
            {
                return NotFound();
            }

            _context.ParteDiario.Remove(parteDiario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParteDiarioExists(int id)
        {
            return _context.ParteDiario.Any(e => e.IdParteDiario == id);
        }
    }
}
