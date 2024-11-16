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
    public class PersonalsConSController : ControllerBase
    {
        private readonly PromcoserContext _context;

        public PersonalsConSController(PromcoserContext context)
        {
            _context = context;
        }

        // GET: api/PersonalsConS
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Personal>>> GetPersonal()
        {
            return await _context.Personal.ToListAsync();
        }

        // GET: api/PersonalsConS/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Personal>> GetPersonal(int id)
        {
            var personal = await _context.Personal.FindAsync(id);

            if (personal == null)
            {
                return NotFound();
            }

            return personal;
        }

        // PUT: api/PersonalsConS/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonal(int id, Personal personal)
        {
            if (id != personal.IdPersonal)
            {
                return BadRequest();
            }

            _context.Entry(personal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalExists(id))
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

        // POST: api/PersonalsConS
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Personal>> PostPersonal(Personal personal)
        {
            _context.Personal.Add(personal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonal", new { id = personal.IdPersonal }, personal);
        }

        // DELETE: api/PersonalsConS/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonal(int id)
        {
            var personal = await _context.Personal.FindAsync(id);
            if (personal == null)
            {
                return NotFound();
            }

            _context.Personal.Remove(personal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonalExists(int id)
        {
            return _context.Personal.Any(e => e.IdPersonal == id);
        }
    }
}
