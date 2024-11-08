using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROMCOSER_DOMAIN.Core.DTO;
using PROMCOSER_DOMAIN.Core.Interfaces;

namespace PROMCOSER_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleParteDiarioController : ControllerBase
    {
        private readonly IDetalleParteDiarioService _detalleParteDiarioService;

        public DetalleParteDiarioController(IDetalleParteDiarioService detalleParteDiarioService)
        {
            _detalleParteDiarioService = detalleParteDiarioService;
        }

        // Obtener todos los detalles
        [HttpGet]
        public async Task<IActionResult> GetDetalles()
        {
            var detalles = await _detalleParteDiarioService.GetDetalles();
            return Ok(detalles);
        }

        // Obtener un detalle por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetalleById(long id)
        {
            var detalle = await _detalleParteDiarioService.GetDetalleById(id);
            if (detalle == null)
            {
                return NotFound();
            }
            return Ok(detalle);
        }

        // Obtener detalles por ID de parte diario
        [HttpGet("ByParteDiario/{parteDiarioId}")]
        public async Task<IActionResult> GetDetallesByParteDiarioId(long parteDiarioId)
        {
            var detalles = await _detalleParteDiarioService.GetDetallesByParteDiarioId(parteDiarioId);
            return Ok(detalles);
        }

        // Crear un nuevo detalle
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DetalleParteDiarioDTO detalleParteDiarioDTO)
        {
            long detalleId = await _detalleParteDiarioService.Insert(detalleParteDiarioDTO);
            return Ok(detalleId);
        }

        // Actualizar un detalle existente
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] DetalleParteDiarioDTO detalleParteDiarioDTO)
        {
            if (id != detalleParteDiarioDTO.IdDetalleParteDiario) return BadRequest();

            var result = await _detalleParteDiarioService.Update(detalleParteDiarioDTO);
            if (!result) return NotFound();

            return Ok(result);
        }

        // Eliminar un detalle
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _detalleParteDiarioService.Delete(id);
            if (!result) return NotFound();

            return Ok(result);
        }
    }
}
