using IyiOlus.Application.Features.UserAccounts.Commands.Create;
using IyiOlus.Application.Features.UserAccounts.Commands.Delete;
using IyiOlus.Application.Features.UserAccounts.Commands.Update;
using IyiOlus.Application.Features.UserAccounts.Queries.GetById;
using IyiOlus.Application.Features.UserAccounts.Queries.GetList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IyiOlus.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Create([FromBody]CreateUserAccountCommand createUserAccountCommand)
        {
            var result = await Mediator.Send(createUserAccountCommand);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]UpdateUserAccountCommand updateUserAccountCommand)
        {
            var result = await Mediator.Send(updateUserAccountCommand);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]Guid id)
        {
            var command = new DeleteUserAccountCommand { UserAccountId = id };
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]Guid id)
        {
            var query = new GetByIdUserAccountQuery { UserAccountId = id };
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery]GetListUserAccountQuery getListUserAccountQuery)
        {
            var result = await Mediator.Send(getListUserAccountQuery);
            return Ok(result);
        }
    }
}
