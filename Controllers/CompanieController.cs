using Microsoft.AspNetCore.Mvc;

namespace collaborative_feedback_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanieController : ControllerBase
    {
        private readonly CompanieService _companieService;

        public CompanieController(CompanieService companieService)
        {
            _companieService = companieService;
        }

        [HttpGet("getMyCompanieDetails")]
        public async Task<ActionResult<Companie>> getMyCompanieDetails()
        {
            try
            {
                string authorizationHeader = Request.Headers["Authorization"];

                string userId = authorizationHeader;

                var getMyCompanieService = await _companieService.GetMyCompanie(userId);

                if (getMyCompanieService == null)
                {
                    return StatusCode(200, new { success = true, message = "Nenhuma workspace encontrada", data = (Companie)null });
                }

                return StatusCode(200, new { success = true, message = "Workspace encontrada", data = getMyCompanieService });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = $"Erro ao encontrar workspace: {ex.Message}", data = (Companie)null });
            }
        }

    }

}
