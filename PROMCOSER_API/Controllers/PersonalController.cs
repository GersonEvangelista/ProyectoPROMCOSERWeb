using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROMCOSER_DOMAIN.CORE.Interfaces;
using static PROMCOSER_DOMAIN.CORE.DTO.PersonalDTO;

namespace PROMCOSER_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalController : ControllerBase
    {
        private readonly IPersonalService _personalService;

        public PersonalController(IPersonalService personalService)
        {
            _personalService = personalService;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] UserRequestAuthDTO userRequestAuthDTO)
        {
            var result = await _personalService.SignUp(userRequestAuthDTO);
            if (!result) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] UserAuthDTO userAuthDTO)
        {
            if (userAuthDTO.Username == "" || userAuthDTO.Password == "") return BadRequest();
            //TODO: Mejorar el userService con DTO
            var result = await _personalService.SignIn(userAuthDTO.Username, userAuthDTO.Password);
            if (result == null) return NotFound();
            return Ok(result);
        }

    }

    
}
