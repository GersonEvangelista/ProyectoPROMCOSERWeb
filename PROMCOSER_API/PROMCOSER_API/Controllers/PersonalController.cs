using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROMCOSER_DOMAIN.Core.Entities;
using PROMCOSER_DOMAIN.Data;

namespace PROMCOSER_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalController : ControllerBase
    {
        private readonly PromcoserContext _promcoserContext;

        public PersonalController(PromcoserContext promcoserContext)
        {
            _promcoserContext = promcoserContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetPeople()
        {
            var people = await _promcoserContext.Personal.ToListAsync();
            return Ok(people);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonalById(int id)
        {
            return Ok(await _promcoserContext.Personal.Where(c => c.IdPersonal == id && c.Estado == "T").FirstOrDefaultAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Personal personal)
        {
            personal.Estado = "T";
            await _promcoserContext.Personal.AddAsync(personal);
            return Ok(await _promcoserContext.SaveChangesAsync());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Personal personal)
        {
            _promcoserContext.Personal.Update(personal);
            return Ok(await _promcoserContext.SaveChangesAsync());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var personal = await _promcoserContext
                            .Personal
                            .FirstOrDefaultAsync(c => c.IdPersonal== id);

            return Ok(_promcoserContext.Personal.Remove(personal));
        }

    }
}
