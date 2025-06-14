using IyiOlus.Application.Features.ProfileTypes.Commands.Create;
using IyiOlus.Application.Features.ProfileTypes.Commands.Delete;
using IyiOlus.Application.Features.ProfileTypes.Commands.Update;
using IyiOlus.Application.Features.ProfileTypes.Queries.GetById;
using IyiOlus.Application.Features.ProfileTypes.Queries.GetList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace IyiOlus.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileTypesController : BaseController
    {
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create([FromBody]CreateProfileTypeCommand createProfileTypeCommand)
        {
            var result = await Mediator.Send(createProfileTypeCommand);
            return Created("", result);
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Update([FromBody]UpdateProfileTypeCommand updateProfileTypeCommand)
        {
            var result = await Mediator.Send(updateProfileTypeCommand);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete([FromRoute]Guid id)
        {
            var command = new DeleteProfileTypeCommand { ProfileTypeId = id };
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin,user")]   // buradaki roller değişiklik gösterebilir
        public async Task<IActionResult> GetById([FromRoute]Guid id)
        {
            var query = new GetByIdProfileTypeQuery { ProfileTypeId = id };
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Authorize(Roles = "admin,user")]   // buradaki roller değişiklik gösterebilir
        public async Task<IActionResult> GetList([FromQuery]GetListProfileTypeQuery getListProfileTypeQuery)
        {
            var result = await Mediator.Send(getListProfileTypeQuery);
            return Ok(result);
        }
    }
}
