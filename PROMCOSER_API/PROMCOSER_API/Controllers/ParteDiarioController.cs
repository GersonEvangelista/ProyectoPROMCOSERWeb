using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROMCOSER_DOMAIN.Core.Interfaces;

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

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var parteDiarios = await _parteDiarioRepository.GetParteDiarios();
            return Ok(parteDiarios);
        }
    }
}
