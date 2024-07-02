using Microsoft.AspNetCore.Mvc;

namespace collaborative_feedback_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("create")]
        public async Task<ActionResult<string>> CreateUser([FromBody] User newUser)
        {
            try
            {
                var fullName = await _userService.CreateUserAsync(newUser);
                return Ok(fullName);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao criar usuário: {ex.Message}");
            }
        }
    }
}
