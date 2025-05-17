using IyiOlus.Application.Features.Contacts.Commands.Create;
using IyiOlus.Application.Features.Contacts.Commands.Delete;
using IyiOlus.Application.Features.Contacts.Queries.GetById;
using IyiOlus.Application.Features.Contacts.Queries.GetList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IyiOlus.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateContactCommand createContactCommand)
        {
            var result = await Mediator.Send(createContactCommand);
            return Created("",result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]Guid id)
        {
            var command = new DeleteContactCommand { id = id };
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]Guid id)
        {
            var query = new GetByIdContactQuery { id = id };
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetListContactQuery getListContactQuery)
        {
            var result = await Mediator.Send(getListContactQuery);
            return Ok(result);
        }
    }
}
