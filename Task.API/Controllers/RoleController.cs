using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Task.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "RequireAdmin")]
    public class RoleController : ControllerBase
    {
        [HttpGet("admin")]
        public IActionResult AdminOnlyAction()
        {
            return Ok("This action is only for admins");
        }
    }
}
