using IyiOlus.Application.Features.Users.Commands.Create;
using IyiOlus.Application.Features.Users.Commands.Delete;
using IyiOlus.Application.Features.Users.Commands.Update;
using IyiOlus.Application.Features.Users.Queries.GetById;
using IyiOlus.Application.Features.Users.Queries.GetList;
using Microsoft.AspNetCore.Mvc;

namespace IyiOlus.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateUserCommand createUserCommand)
        {
            var result = await Mediator.Send(createUserCommand);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]UpdateUserCommand updateUserCommand)
        {
            var result = await Mediator.Send(updateUserCommand);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]Guid id)
        {
            var command = new DeleteUserCommand { UserId = id };
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]Guid id)
        {
            var query = new GetByIdUserQuery { UserId = id };
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery]GetListUserQuery getListUserQuery)
        {
            var result = await Mediator.Send(getListUserQuery);
            return Ok(result);
        }
    }
}
