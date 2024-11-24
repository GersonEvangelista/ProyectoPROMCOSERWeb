using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROMCOSER_DOMAIN.CORE.DTO;
using PROMCOSER_DOMAIN.CORE.Entities;
using PROMCOSER_DOMAIN.CORE.Interfaces;

namespace PROMCOSER_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ParteDiarioController : ControllerBase
    {
        private readonly IParteDiarioRepository _parteDiarioRepository;

        public ParteDiarioController(IParteDiarioRepository parteDiarioRepository)
        {
            _parteDiarioRepository = parteDiarioRepository;
        }
        /*
                [HttpGet]
                public async Task<ActionResult<IEnumerable<ParteDiarioDTO>>> GetParteDiario()
                {
                    var parteDiario = await _parteDiarioRepository.GetParteDiario();

                    var parteDiarioDTO = parteDiario.Select(x => new ParteDiarioDTO
                    {
                        IdParteDiario = x.IdParteDiario,
                        Fecha = x.Fecha,
                        Firmas = x.Firmas,
                        HorometroInicio = x.HorometroInicio,
                        HorometroFinal = x.HorometroFinal,
                        IdCliente = x.IdCliente,
                        IdPersonal = x.IdPersonal,
                        IdMaquinaria = x.IdMaquinaria,
                        LugarTrabajo = x.LugarTrabajo,
                        Petroleo = x.Petroleo,
                        Aceite = x.Aceite,
                        ProximoMantenimiento = x.ProximoMantenimiento
                    }).ToList();
                    return Ok(parteDiarioDTO);
                }

                [HttpGet("{id}")]
                public async Task<ActionResult<ParteDiarioDTO>> GetParteDiarioById(int id)
                {
                    var parteDiario = await _parteDiarioRepository.GetParteDiarioById(id);

                    if (parteDiario == null)
                        return NotFound();

                    var parteDiarioDTO = new ParteDiarioDTO
                    {
                        IdParteDiario = parteDiario.IdParteDiario,
                        Fecha = parteDiario.Fecha,
                        Firmas = parteDiario.Firmas,
                        HorometroInicio = parteDiario.HorometroInicio,
                        HorometroFinal = parteDiario.HorometroFinal,
                        IdCliente = parteDiario.IdCliente,
                        IdPersonal = parteDiario.IdPersonal,
                        IdMaquinaria = parteDiario.IdMaquinaria,
                        LugarTrabajo = parteDiario.LugarTrabajo,
                        Petroleo = parteDiario.Petroleo,
                        Aceite = parteDiario.Aceite,
                        ProximoMantenimiento = parteDiario.ProximoMantenimiento
                    };

                    return Ok(parteDiarioDTO);
                }

                [HttpPost]
                public async Task<ActionResult> Insert([FromBody] ParteDiarioDTO parteDiarioDTO)
                {
                    if (parteDiarioDTO == null)
                    {
                        return BadRequest("El objeto parteDiarioDTO no puede ser nulo.");
                    }

                    var parteDiario = new ParteDiario
                    {
                        Serie = null,
                        Fecha = parteDiarioDTO.Fecha,
                        Firmas = parteDiarioDTO.Firmas,
                        HorometroInicio = parteDiarioDTO.HorometroInicio,
                        HorometroFinal = parteDiarioDTO.HorometroFinal,
                        IdCliente = parteDiarioDTO.IdCliente,
                        IdPersonal = parteDiarioDTO.IdPersonal,
                        IdMaquinaria = parteDiarioDTO.IdMaquinaria,
                        LugarTrabajo = parteDiarioDTO.LugarTrabajo,
                        Petroleo = parteDiarioDTO.Petroleo,
                        Aceite = parteDiarioDTO.Aceite,
                        ProximoMantenimiento = parteDiarioDTO.ProximoMantenimiento
                    };

                    try
                    {
                        var inserted = await _parteDiarioRepository.Insert(parteDiario);
                        if (!inserted)
                        {
                            return BadRequest("Error al insertar el parte diario.");
                        }
                        return Ok(parteDiario);
                    }
                    catch (Exception ex)
                    {
                        return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                    }
                }
        */

        [HttpPost("getIdparaPostDetalles")]
        public async Task<ActionResult> Insert2([FromBody] ParteDiarioDTO parteDiarioDTO)
        {
            if (parteDiarioDTO == null)
            {
                return BadRequest("El objeto parteDiarioDTO no puede ser nulo.");
            }

            var parteDiario = new ParteDiario
            {
                Serie = null,
                Fecha = parteDiarioDTO.Fecha,
                Firmas = parteDiarioDTO.Firmas,
                HorometroInicio = parteDiarioDTO.HorometroInicio,
                HorometroFinal = parteDiarioDTO.HorometroFinal,
                IdCliente = parteDiarioDTO.IdCliente,
                IdPersonal = parteDiarioDTO.IdPersonal,
                IdMaquinaria = parteDiarioDTO.IdMaquinaria,
                LugarTrabajo = parteDiarioDTO.LugarTrabajo,
                Petroleo = parteDiarioDTO.Petroleo,
                Aceite = parteDiarioDTO.Aceite,
                ProximoMantenimiento = parteDiarioDTO.ProximoMantenimiento
            };

            try
            {
                var inserted = await _parteDiarioRepository.Insert2(parteDiario);
                if (inserted == null)
                {
                    return BadRequest("Error al insertar el parte diario.");
                }
                return Ok(parteDiario.IdParteDiario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Insert([FromBody] ParteDiarioDTO parteDiarioDTO)
        {
            if (parteDiarioDTO == null)
            {
                return BadRequest("El objeto parteDiarioDTO no puede ser nulo.");
            }

            var parteDiario = new ParteDiario
            {
                Serie = null,
                Fecha = parteDiarioDTO.Fecha,
                Firmas = parteDiarioDTO.Firmas,
                HorometroInicio = parteDiarioDTO.HorometroInicio,
                HorometroFinal = parteDiarioDTO.HorometroFinal,
                IdCliente = parteDiarioDTO.IdCliente,
                IdPersonal = parteDiarioDTO.IdPersonal,
                IdMaquinaria = parteDiarioDTO.IdMaquinaria,
                LugarTrabajo = parteDiarioDTO.LugarTrabajo,
                Petroleo = parteDiarioDTO.Petroleo,
                Aceite = parteDiarioDTO.Aceite,
                ProximoMantenimiento = parteDiarioDTO.ProximoMantenimiento
            };

            try
            {
                var inserted = await _parteDiarioRepository.Insert(parteDiario);
                if (!inserted)
                {
                    return BadRequest("Error al insertar el parte diario.");
                }
                return Ok(parteDiario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] ParteDiarioDTO parteDiarioDTO)
        {
            if (parteDiarioDTO == null)
            {
                return BadRequest("El objeto parteDiarioDTO no puede ser nulo.");
            }

            var parteDiario = new ParteDiario
            {
                Fecha = parteDiarioDTO.Fecha,
                Firmas = parteDiarioDTO.Firmas,
                HorometroInicio = parteDiarioDTO.HorometroInicio,
                HorometroFinal = parteDiarioDTO.HorometroFinal,
                IdCliente = parteDiarioDTO.IdCliente,
                IdPersonal = parteDiarioDTO.IdPersonal,
                IdMaquinaria = parteDiarioDTO.IdMaquinaria,
                LugarTrabajo = parteDiarioDTO.LugarTrabajo,
                Petroleo = parteDiarioDTO.Petroleo,
                Aceite = parteDiarioDTO.Aceite,
                ProximoMantenimiento = parteDiarioDTO.ProximoMantenimiento
            };

            try
            {
                var updated = await _parteDiarioRepository.Update(id, parteDiario);
                if (!updated)
                {
                    return NotFound("ParteDiario no encontrado.");
                }
                return Ok(parteDiario);
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
                var deleted = await _parteDiarioRepository.Delete(id);
                if (!deleted)
                {
                    return NotFound("ParteDiario no encontrado.");
                }
                return Ok("ParteDiario eliminado correctamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpDelete("logical/{id}")]

        public async Task<ActionResult> LogicalDelete(int id)
        {
            try
            {
                var deleted = await _parteDiarioRepository.LogicalDelete(id);
                if (!deleted)
                {
                    return NotFound("ParteDiario no encontrado.");
                }
                return Ok("ParteDiario marcado como eliminado correctamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }



    }
}
