using IyiOlus.Application.Features.Settings.Commands.Create;
using IyiOlus.Application.Features.Settings.Commands.Delete;
using IyiOlus.Application.Features.Settings.Commands.Update;
using IyiOlus.Application.Features.Settings.Dtos.Responses;
using IyiOlus.Application.Features.Settings.Queries.GetList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IyiOlus.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSettingCommand createSettingCommand)
        {
            var result = await Mediator.Send(createSettingCommand);
            return Created("",result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSettingCommand updateSettingCommand)
        {
            var result = await Mediator.Send(updateSettingCommand);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]Guid id)
        {
            var command = new DeleteSettingCommand { SettingId = id };
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]Guid id)
        {
            var query = new UpdateSettingCommand { SettingId = id };
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery]GetListSettingQuery getListSettingQuery)
        {
            var result = await Mediator.Send(getListSettingQuery);
            return Ok(result);
        }
    }
}
