using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROMCOSER.CLIENTE.DOMAIN.Core.DTO;
using PROMCOSER.CLIENTE.DOMAIN.Core.Interfaces;

namespace PROMCOSER.CLIENTE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            var clientes = await _clienteService.GetClientes();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClienteById(int id)
        {
            var cliente = await _clienteService.GetClienteyById(id);
            if (cliente == null)
                return NotFound();
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ClienteDTO1 clienteDTO)
        {
            int clienteId = await _clienteService.Insert(clienteDTO);
            return Ok(clienteId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ClienteDTO clienteDTO)
        {
            if (id != clienteDTO.IdCliente) return BadRequest();
            var result = await _clienteService.Update(clienteDTO);
            if (!result) return NotFound();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _clienteService.Delete(id);
            if (!result) return NotFound();
            return Ok(result);
        }



    }
}
