using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROMCOSER_API___Rol__Ubigeo.Core.DTO;
using PROMCOSER_API___Rol__Ubigeo.Core.Entities;
using PROMCOSER_API___Rol__Ubigeo.Core.Interfaces;
using PROMCOSER_API___Rol__Ubigeo.Infraestructure.Data;

namespace PROMCOSER_API___Rol__Ubigeo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UbigeoController : ControllerBase
    {
        private readonly IUbigeoService _ubigeoService;

        public UbigeoController(IUbigeoService ubigeoService)
        {
            _ubigeoService = ubigeoService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllUbigeo()
        {
            var ubigeo = await _ubigeoService.GetAllUbigeo();
            return Ok(ubigeo);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetUbigeoById(int id)
        {
            var ubigeo = await _ubigeoService.GetUbigeoById(id);
            if(ubigeo == null)
            {
                return BadRequest();
            }
            return Ok(ubigeo);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UbigeoDTO ubigeoDTO)
        {
            int ubigeoId = await _ubigeoService.Insert(ubigeoDTO);
            return Ok(ubigeoId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UbigeoDTO ubigeoDTO)
        {
            if (id != ubigeoDTO.IdUbigeo) return BadRequest();
            var result = await _ubigeoService.Update(ubigeoDTO);
            if (!result) return NotFound();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _ubigeoService.Delete(id);
            if (!result) return NotFound();
            return Ok(result);
        }

    }
}
