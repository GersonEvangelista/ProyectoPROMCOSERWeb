using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROMCOSER_API___Rol__Ubigeo.Core.DTO;
using PROMCOSER_API___Rol__Ubigeo.Core.Interfaces;
using PROMCOSER_API___Rol__Ubigeo.Core.Services;

namespace PROMCOSER_API___Rol__Ubigeo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IRolService _rolService;

        public RolController(IRolService rolService)
        {
            _rolService = rolService;   
        }

        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            var detalles = await _rolService.GetRoles();
            return Ok(detalles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRolById(int id)
        {
            var ubigeo = await _rolService.GetRolById(id);
            if (ubigeo == null)
            {
                return BadRequest();
            }
            return Ok(ubigeo);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RolDTO rolDTO)
        {
            int categoryId = await _rolService.Insert(rolDTO);
            return Ok(categoryId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RolDTO rolDTO)
        {
            if (id != rolDTO.IdRol) return BadRequest();
            var result = await _rolService.Update(rolDTO);
            if (!result) return NotFound();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _rolService.Delete(id);
            if (!result) return NotFound();
            return Ok(result);
        }


    }
}
