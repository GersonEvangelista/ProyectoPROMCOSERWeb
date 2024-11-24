using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("GetOperadores")]
        public async Task<IActionResult> GetOperadores()
        {
            var operadores = await _personalService.GetOperadores();
            return Ok(operadores);
        }
        //ARON
        [HttpGet]
        public async Task<IActionResult> GetPersonal()
        {
            var personal = await _personalService.GetPersonal();
            return Ok(personal);
        }

        [HttpGet("GetPersonalDialog")]
        public async Task<IActionResult> GetPersonalDialog()
        {
            var personal = await _personalService.GetPersonalDialog();
            return Ok(personal);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonalById(int id)
        {
            var personal = await _personalService.GetPersonalyById(id);
            if (personal == null)
                return NotFound();
            return Ok(personal);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PersonalDTOfrontEnd2 personalDTO)
        {
            int personalId = await _personalService.Insert(personalDTO);
            return Ok(personalId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PersonalDTOfrontEnd2 personalDTO)
        {
            if (id != personalDTO.IdPersonal) return BadRequest();
            var result = await _personalService.Update(personalDTO);
            if (!result) return NotFound();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _personalService.Delete(id);
            if (!result) return NotFound();
            return Ok(result);
        }

    }

    
}
