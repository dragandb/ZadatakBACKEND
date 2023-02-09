using Microsoft.AspNetCore.Mvc;
using ZadatakAPI.Models.DTO;
using ZadatakAPI.Services;

namespace ZadatakAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private IUserService _userService;
 

        public AuthController(IUserService userService)
        {
            _userService = userService;
            
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody]RegisterUserModel model)
        {
            if(ModelState.IsValid)
            {
                var result = await _userService.RegisterUserAsync(model);

                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);
            }
            
            return BadRequest("Something is wrong");
        }
    }
}
