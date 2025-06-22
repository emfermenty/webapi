using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController(AccountService accountService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]User request, CancellationToken cancellationToken)
        {
            await accountService.Register(request.UserName, request.Email, request.PasswordHash, cancellationToken);
            return NoContent();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model, CancellationToken cancellationToken)
        {
            var token = await accountService.Login(model.Username, model.Password, cancellationToken);
            HttpContext.Response.Cookies.Append("myToken", token, new CookieOptions
            {
                HttpOnly = true
            });
            return Ok(token);
        }
    }
}
