using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROMCOSER_DOMAIN.Core.DTO;
using PROMCOSER_DOMAIN.CORE.Entities;
using PROMCOSER_DOMAIN.CORE.Interfaces;

namespace PROMCOSER_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MaquinariaController : ControllerBase
    {
        private readonly IMaquinariaRepository _maquinariaRepository;
        private readonly MaquinariaDTO _maquinariaDTO;

        public MaquinariaController(IMaquinariaRepository maquinariaRepository)
        {
            _maquinariaRepository = maquinariaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaquinariaDTO>>> GetMaquinarias()
        {
            var maquinarias = await _maquinariaRepository.GetMaquinarias();

            var maquinariasDto = maquinarias.Select(m => new MaquinariaDTO
            {
                IdMaquinaria = m.IdMaquinaria,
                Placa = m.Placa,
                Modelo = m.Modelo,
                Marca = m.Marca,
                AnioCompra = m.AnioCompra,
                HorometroCompra = m.HorometroCompra,
                HorometroActual = m.HorometroActual,
                Estado = m.Estado
            }).ToList();

            return Ok(maquinariasDto);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<MaquinariaDTO>> GetMaquinariaById(int id)
        {
            var maquinaria = await _maquinariaRepository.GetMaquinariaById(id);
            if (maquinaria == null)
                return NotFound();

            var maquinariaDto = new MaquinariaDTO
            {
                IdMaquinaria = maquinaria.IdMaquinaria,
                Placa = maquinaria.Placa,
                Modelo = maquinaria.Modelo,
                Marca = maquinaria.Marca,
                AnioCompra = maquinaria.AnioCompra,
                HorometroCompra = maquinaria.HorometroCompra,
                HorometroActual = maquinaria.HorometroActual,
                Estado = maquinaria.Estado
            };

            return Ok(maquinariaDto);
        }


        [HttpGet("marca/{marca}")]
        public async Task<ActionResult<IEnumerable<MaquinariaDTO>>> GetMaquinariasByMarca(string marca)
        {
            var maquinarias = await _maquinariaRepository.GetMaquinariasByMarca(marca);
            var maquinariasDto = maquinarias.Select(m => new MaquinariaDTO
            {
                IdMaquinaria = m.IdMaquinaria,
                Placa = m.Placa,
                Modelo = m.Modelo,
                Marca = m.Marca,
                AnioCompra = m.AnioCompra,
                HorometroCompra = m.HorometroCompra,
                HorometroActual = m.HorometroActual,
                Estado = m.Estado
            }).ToList();

            return Ok(maquinariasDto);
        }


        [HttpGet("modelo/{modelo}")]
        public async Task<ActionResult<IEnumerable<MaquinariaDTO>>> GetMaquinariasByModelo(string modelo)
        {
            var maquinarias = await _maquinariaRepository.GetMaquinariasByModelo(modelo);
            var maquinariasDto = maquinarias.Select(m => new MaquinariaDTO
            {
                IdMaquinaria = m.IdMaquinaria,
                Placa = m.Placa,
                Modelo = m.Modelo,
                Marca = m.Marca,
                AnioCompra = m.AnioCompra,
                HorometroCompra = m.HorometroCompra,
                HorometroActual = m.HorometroActual,
                Estado = m.Estado
            }).ToList();

            return Ok(maquinariasDto);
        }


        [HttpGet("placa/{placa}")]
        public async Task<ActionResult<MaquinariaDTO>> GetMaquinariaByPlaca(string placa)
        {
            var maquinaria = await _maquinariaRepository.GetMaquinariaByPlaca(placa);
            if (maquinaria == null)
                return NotFound();

            var maquinariaDto = new MaquinariaDTO
            {
                IdMaquinaria = maquinaria.IdMaquinaria,
                Placa = maquinaria.Placa,
                Modelo = maquinaria.Modelo,
                Marca = maquinaria.Marca,
                AnioCompra = maquinaria.AnioCompra,
                HorometroCompra = maquinaria.HorometroCompra,
                HorometroActual = maquinaria.HorometroActual,
                Estado = maquinaria.Estado
            };

            return Ok(maquinariaDto);
        }



        [HttpPost]
        public async Task<ActionResult> Insert([FromBody] MaquinariaDTO maquinariaDto)
        {
            var maquinaria = new Maquinaria
            {
                Placa = maquinariaDto.Placa,
                Modelo = maquinariaDto.Modelo,
                Marca = maquinariaDto.Marca,
                AnioCompra = maquinariaDto.AnioCompra,
                HorometroCompra = maquinariaDto.HorometroCompra,
                HorometroActual = maquinariaDto.HorometroActual,
                Estado = maquinariaDto.Estado
            };

            var inserted = await _maquinariaRepository.Insert(maquinaria);
            if (!inserted)
                return BadRequest();
            return Ok();
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] MaquinariaDTO maquinariaDto)
        {
            var maquinaria = new Maquinaria
            {
                Placa = maquinariaDto.Placa,
                Modelo = maquinariaDto.Modelo,
                Marca = maquinariaDto.Marca,
                AnioCompra = maquinariaDto.AnioCompra,
                HorometroCompra = maquinariaDto.HorometroCompra,
                HorometroActual = maquinariaDto.HorometroActual,
                Estado = maquinariaDto.Estado
            };

            var updated = await _maquinariaRepository.Update(id, maquinaria);

            if (!updated)
                return BadRequest("No se pudo actualizar la maquinaria.");

            return Ok("Maquinaria actualizada exitosamente.");
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _maquinariaRepository.Delete(id);
            if (!deleted)
                return NotFound();
            return Ok();
        }

        [HttpDelete("{id}/logical-delete")]
        public async Task<ActionResult> LogicalDelete(int id)
        {
            var deleted = await _maquinariaRepository.LogicalDelete(id);
            if (!deleted)
                return NotFound();
            return Ok();
        }

    }
}
