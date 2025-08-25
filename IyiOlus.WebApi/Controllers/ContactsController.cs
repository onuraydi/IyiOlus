using IyiOlus.Application.Features.Contacts.Commands.Create;
using IyiOlus.Application.Features.Contacts.Commands.Delete;
using IyiOlus.Application.Features.Contacts.Queries.GetById;
using IyiOlus.Application.Features.Contacts.Queries.GetList;
using IyiOlus.Application.Features.Contacts.Queries.GetListByUserId;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IyiOlus.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : BaseController
    {
        [HttpPost]
        //[Authorize(Roles ="user")]
        public async Task<IActionResult> Create([FromBody]CreateContactCommand createContactCommand)
        {
            var result = await Mediator.Send(createContactCommand);
            return Created("",result);
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "admin,user")]
        public async Task<IActionResult> Delete([FromRoute]Guid id)
        {
            var command = new DeleteContactCommand { id = id };
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = "admin,user")]
        public async Task<IActionResult> GetById([FromRoute]Guid id)
        {
            var query = new GetByIdContactQuery { id = id };
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        //[Authorize(Roles ="admin")]
        public async Task<IActionResult> GetList([FromQuery] GetListContactQuery getListContactQuery)
        {
            var result = await Mediator.Send(getListContactQuery);
            return Ok(result);
        }

        [HttpGet("get")]
        //[Authorize(Roles ="user")]
        public async Task<IActionResult> Get([FromQuery] GetListByUserIdContactQuery getListByUserIdContactQuery)
        {
            var result = await Mediator.Send(getListByUserIdContactQuery);
            return Ok(result);
        }
    }
}
