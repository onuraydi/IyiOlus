using IyiOlus.Application.Features.Authentications.Login.Commands.Login;
using IyiOlus.Application.Features.Authentications.RefreshToken.Commands.RefreshToken;
using IyiOlus.Application.Features.Authentications.Register.Commands.Register;
using IyiOlus.Application.Features.Authentications.Revoke.Commands.Revoke;
using IyiOlus.Application.Features.Authentications.Verification.Commands.SendVerificationCode;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IyiOlus.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterCommand registerCommand)
        {
            var result = await Mediator.Send(registerCommand);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginCommand loginCommand)
        {
            var result = await Mediator.Send(loginCommand);
            return Ok(result);
        }

        [HttpPost("refreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody]RefreshTokenCommand refreshTokenCommand)
        {
            var result = await Mediator.Send(refreshTokenCommand);
            return Ok(result);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody]RevokeCommand revokeCommand)
        {
            var result = await Mediator.Send(revokeCommand);
            return Ok(result);
        }

        [HttpPost("sendVerificationCode")]
        public async Task<IActionResult> SendVerificationCode([FromBody]SendVerificationCodeCommand sendVerificationCodeCommand)
        {
            var result = await Mediator.Send(sendVerificationCodeCommand);
            return Ok(result);
        }
    }
}
