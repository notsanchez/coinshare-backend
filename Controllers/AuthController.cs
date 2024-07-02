using Microsoft.AspNetCore.Mvc;

namespace collaborative_feedback_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login([FromBody] UserLogin userLogin)
        {
            try
            {
                var loginService = await _authService.Login(userLogin.email, userLogin.password);

                if (loginService == null)
                {
                    return StatusCode(404, new { success = false, message = "Credenciais inválidas", data = (User)null });
                }

                return StatusCode(200, new { success = true, message = "Login efetuado com sucesso", data = loginService });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = $"Erro ao realizar login: {ex.Message}", data = (User)null });
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register([FromBody] UserRegister userRegister)
        {
            try
            {
                var user = await _authService.Register(userRegister.fullName, userRegister.email, userRegister.password);

                return StatusCode(201, new { success = true, message = "Usuário cadastrado com sucesso", data = user });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = $"Erro ao cadastrar usuário: {ex.Message}", data = (User)null });
            }
        }
    }

}
