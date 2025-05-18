using IyiOlus.Application.Features.DailyMoods.Commands.Create;
using IyiOlus.Application.Features.DailyMoods.Queries.GetById;
using IyiOlus.Application.Features.DailyMoods.Queries.GetList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IyiOlus.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyMoodsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateDailyMoodCommand createDailyMoodCommand)
        {
            var result = await Mediator.Send(createDailyMoodCommand);
            return Created("", result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]Guid id)
        {
            var query = new GetByIdDailyMoodQuery { DailyMoodId = id };
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetListDailyMoodQuery getListDailyMoodQuery)
        {
            var result = await Mediator.Send(getListDailyMoodQuery);
            return Ok(result);
        }
    }
}
