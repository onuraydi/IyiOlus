using IyiOlus.Application.Features.Authentications.Commands.Register;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IyiOlus.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegisterCommand registerCommand)
        {
            var result = await Mediator.Send(registerCommand);
            return Ok(result);
        }
    }
}
