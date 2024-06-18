using Microsoft.AspNetCore.Mvc;
using Services.IServices;

namespace BaseWeb.Controllers
{
    [Route("api/routines")]
    [ApiController]
    public class RoutinesController(IRoutineService routineService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await routineService.GetRoutinesAsync();

            return Ok(response);
        }
    }
}
