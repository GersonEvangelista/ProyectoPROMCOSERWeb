using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using PROMCOSER_DOMAIN.Core.Entities;
using PROMCOSER_DOMAIN.Infrastructure.Repositories;
using PROMCOSER_DOMAIN.Core.DTO;

namespace PROMCOSER_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaquinariaController : ControllerBase
    {
        private readonly IMaquinariaRepository _maquinariaRepository;

        public MaquinariaController(IMaquinariaRepository maquinariaRepository)
        {
            _maquinariaRepository = maquinariaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Maquinaria>>> GetMaquinarias()
        {
            var maquinarias = await _maquinariaRepository.GetMaquinarias();
            return Ok(maquinarias);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Maquinaria>> GetMaquinariaById(int id)
        {
            var maquinaria = await _maquinariaRepository.GetMaquinariaById(id);
            if (maquinaria == null)
                return NotFound();
            return Ok(maquinaria);
        }

        [HttpGet("marca/{marca}")]
        public async Task<ActionResult<Maquinaria>> GetMaquinariaByMarca(string marca)
        {
            var maquinaria = await _maquinariaRepository.GetMaquinariaByMarca(marca);
            if (maquinaria == null)
                return NotFound();
            return Ok(maquinaria);
        }

        [HttpGet("modelo/{modelo}")]
        public async Task<ActionResult<Maquinaria>> GetMaquinariaByModelo(string modelo)
        {
            var maquinaria = await _maquinariaRepository.GetMaquinariaByModelo(modelo);
            if (maquinaria == null)
                return NotFound();
            return Ok(maquinaria);
        }

        [HttpGet("placa/{placa}")]
        public async Task<ActionResult<Maquinaria>> GetMaquinariaByPlaca(string placa)
        {
            var maquinaria = await _maquinariaRepository.GetMaquinariaByPlaca(placa);
            if (maquinaria == null)
                return NotFound();
            return Ok(maquinaria);
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


        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Maquinaria maquinaria)
        {
            var updated = await _maquinariaRepository.Update(maquinaria);
            if (!updated)
                return BadRequest();
            return Ok();
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
