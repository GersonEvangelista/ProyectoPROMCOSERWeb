using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROMCOSER_DOMAIN.CORE.DTO;
using PROMCOSER_DOMAIN.CORE.Entities;
using PROMCOSER_DOMAIN.CORE.Interfaces;
using PROMCOSER_DOMAIN.INFRASTRUCTURE.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROMCOSER_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DetalleParteDiarioController : ControllerBase
    {
        private readonly IDetalleParteDiarioRepository _detalleParteDiarioRepository;
        private readonly PromcoserContext _context;

        public DetalleParteDiarioController(IDetalleParteDiarioRepository detalleParteDiarioRepository)
        {
            _detalleParteDiarioRepository = detalleParteDiarioRepository;
        }
        /*
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleParteDiarioDTO>>> GetDetalleParteDiario()
        {
            var detalleParteDiario = await _detalleParteDiarioRepository.GetDetalleParteDiario();

            var detalleParteDiarioDTOs = detalleParteDiario.Select(x => new DetalleParteDiarioDTO
            {
                Horas = x.Horas,
                TrabajoEfectuado = x.TrabajoEfectuado,
                Descripcion = x.Descripcion
            }).ToList();
            return Ok(detalleParteDiarioDTOs);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleParteDiarioDTO>> GetDetalleParteDiarioById(int id)
        {
            var detalleParteDiario = await _detalleParteDiarioRepository.GetDetalleParteDiarioById(id);

            if (detalleParteDiario == null)
                return NotFound();

            var detalleParteDiarioDTO = new DetalleParteDiarioDTO
            {
                Horas = detalleParteDiario.Horas,
                TrabajoEfectuado = detalleParteDiario.TrabajoEfectuado,
                Descripcion = detalleParteDiario.Descripcion
            };

            return Ok(detalleParteDiarioDTO);
        }
        */
        [HttpPost]
        public async Task<ActionResult> Insert([FromBody] DetalleParteDiarioDTO2 detalleParteDiarioDTO)
        {
            if (detalleParteDiarioDTO == null)
            {
                return BadRequest("El objeto detalleParteDiarioDTO no puede ser nulo.");
            }

            if (detalleParteDiarioDTO.IdParteDiario <= 0)
            {
                return BadRequest("El IdParteDiario es requerido y debe ser mayor a 0.");
            }

            var detalleParteDiario = new DetalleParteDiario
            {
                Descripcion = detalleParteDiarioDTO.Descripcion,
                IdParteDiario = detalleParteDiarioDTO.IdParteDiario,
                Horas = detalleParteDiarioDTO.Horas,
                TrabajoEfectuado = detalleParteDiarioDTO.TrabajoEfectuado
            };

            try
            {
                var inserted = await _detalleParteDiarioRepository.Insert(detalleParteDiario);
                if (!inserted)
                {
                    return BadRequest("Error al insertar el detalle del parte diario.");
                }
                return Ok(inserted);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] DetalleParteDiarioDTO detalleParteDiarioDTO)
        {
            if (detalleParteDiarioDTO == null)
            {
                return BadRequest("El objeto detalleParteDiarioDTO no puede ser nulo.");
            }

            var existingDetalleParteDiario = await _detalleParteDiarioRepository.GetDetalleParteDiarioById(id);
            if (existingDetalleParteDiario == null)
            {
                return NotFound("DetalleParteDiario no encontrado.");
            }

            existingDetalleParteDiario.Horas = detalleParteDiarioDTO.Horas;
            existingDetalleParteDiario.TrabajoEfectuado = detalleParteDiarioDTO.TrabajoEfectuado;
            existingDetalleParteDiario.Descripcion = detalleParteDiarioDTO.Descripcion;

            try
            {
                var updated = await _detalleParteDiarioRepository.Update(id, existingDetalleParteDiario);
                if (!updated)
                {
                    return StatusCode(500, "Error al actualizar el detalle del parte diario.");
                }
                return Ok(existingDetalleParteDiario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var deleted = await _detalleParteDiarioRepository.Delete(id);
                if (!deleted)
                {
                    return NotFound("DetalleParteDiario no encontrado.");
                }
                return Ok("DetalleParteDiario eliminado correctamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

    }
}
