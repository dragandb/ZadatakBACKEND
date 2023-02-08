using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ZadatakAPI.Models;
using ZadatakAPI.Models.DTO;

namespace ZadatakAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApiUser> _userManager;        
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper _mapper;

        public AccountController(UserManager<ApiUser> userManager, ILogger<AccountController> logger, IMapper mapper)
        {
            _userManager = userManager;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserDTO userDTO)
        {
            try
            {
                _logger.LogInformation($"Registration attempt for: {userDTO.Email}");
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid object sent from client.");
                    return BadRequest();
                }
                var user = _mapper.Map<ApiUser>(userDTO);
                var result = await _userManager.CreateAsync(user, userDTO.Password);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.TryAddModelError(error.Code, error.Description);
                    }
                    return Ok();
                }
                await _userManager.AddToRoleAsync(user, "Visitor");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        //[HttpPost]
        //[Route("login")]
        //public async Task<IActionResult> LoginUser([FromBody] UserLoginDTO userDTO)
        //{
        //    try
        //    {
        //        _logger.LogInformation($"Registration attempt for: {userDTO.UserName}");
        //        if (!ModelState.IsValid)
        //        {
        //            _logger.LogError("Invalid object sent from client.");
        //            return BadRequest();
        //        }

        //        var createdUser = await _signInManager.PasswordSignInAsync(userDTO.UserName, userDTO.Password, false, false);
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Something went wrong: {ex.Message}");
        //        return StatusCode(500, "Internal server error");
        //    }
        //}
    }
}
