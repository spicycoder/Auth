using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SimpleAuth.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    [Authorize]
    [HttpGet("me")]
    public async Task<IActionResult> Me()
    {
        if (User?.Identity?.IsAuthenticated ?? false)
        {
            var userInfo = new
            {
                User.Identity.Name,
                Claims = User.Claims.Select(c => new { c.Type, c.Value })
            };
            return Ok(userInfo);
        }

        return Unauthorized();
    }
}
